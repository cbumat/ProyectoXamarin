using HotelingXamarin.Base;
using HotelingXamarin.Models;
using HotelingXamarin.Repositories;
using HotelingXamarin.Services;
using HotelingXamarin.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HotelingXamarin.ViewModels {
    public class UsuarioViewModel : ViewModelBase {
        RepositoryHoteles repo;
        public UsuarioViewModel() {
            this.repo = new RepositoryHoteles();
            if (Usuario == null) {
                Usuario = new Usuario();
            }
        }

        private Usuario _Usuario;
        public Usuario Usuario {
            get { return this._Usuario; }
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
                        MessagingCenter.Send<PrincipalMaster>(App.Locator.PrincipalMaster, "INICIAR");
                    }
                    else {
                        MessagingCenter.Send<Login>(App.Locator.Login, "MAL");
                    }
                });
            }
        }

    }
}
