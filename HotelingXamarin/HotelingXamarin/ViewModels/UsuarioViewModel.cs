using HotelingXamarin.Base;
using HotelingXamarin.Models;
using HotelingXamarin.Repositories;
using HotelingXamarin.Services;
using HotelingXamarin.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HotelingXamarin.ViewModels {
    public class UsuarioViewModel : ViewModelBase {
        RepositoryHoteles repo;
        public UsuarioViewModel() {
            this.repo = new RepositoryHoteles();
            if (Usuario == null) {
                Usuario = new Usuario();
            }

            if (App.Locator.SessionService.Sesion.usuario != null)
            {
                this.Usuario = App.Locator.SessionService.Sesion.usuario;
            }

            MessagingCenter.Subscribe<UsuarioViewModel>(this, "MODIFICADO", async (sender) =>
            {
                MiPerfil view = new MiPerfil();
                await Application.Current.MainPage.Navigation.PushAsync(view);
                await this.CargarPerfil();
            });

        }

        private Usuario _Usuario;
        public Usuario Usuario {
            get {
                return this._Usuario;
            }
            set {
                this._Usuario = value;
                OnPropertyChanged("Usuario");
            }
        }

        public Command CerrarSesion {
            get {
                return new Command( () => {
                    App.Locator.SessionService.Sesion = new Sesion();
                    MessagingCenter.Send<PrincipalMaster>(App.Locator.PrincipalMaster, "INICIAR");
                });
            }
        }

        public Command Register {
            get {
                return new Command(async () => {
                    await this.repo.InsertarUsuario(this.Usuario);
                    MessagingCenter.Send<PrincipalMaster>(App.Locator.PrincipalMaster, "REGISTRO");
                });
            }
        }

        public Command Login {
            get {
                return new Command(async () => {
                    String token = await this.repo.GetToken(Usuario.EMAIL, Usuario.CONTRASEÑA);
                    if(token != null) {
                        Usuario usuario1 = await this.repo.PerfilUsuario(token);
                        SessionService session = App.Locator.SessionService;
                        session.Sesion.token = token;
                        session.Sesion.usuario = usuario1;
                        await this.CargarPerfil();
                        MessagingCenter.Send<PrincipalMaster>(App.Locator.PrincipalMaster, "INICIAR");
                    }
                    else {
                        MessagingCenter.Send<Login>(App.Locator.Login, "MAL");
                    }
                });
            }
        }

        public Command ModificarPerfil
        {
            get
            {
                return new Command(async () =>
                {
                    await this.repo.ModificarDoctor(this.Usuario.ID_USUARIO, this.Usuario, App.Locator.SessionService.Sesion.token);
                    MessagingCenter.Send<UsuarioViewModel>(App.Locator.UsuarioViewModel, "MODIFICADO");
                });
            }
        }

        public async Task CargarPerfil()
        {
            Usuario user = await this.repo.GetUsuarioNum(App.Locator.SessionService.Sesion.usuario.ID_USUARIO,App.Locator.SessionService.Sesion.token);
            this.Usuario = user;
        }

    }
}
