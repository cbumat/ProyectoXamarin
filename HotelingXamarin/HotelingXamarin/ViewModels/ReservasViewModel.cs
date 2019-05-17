using HotelingXamarin.Base;
using HotelingXamarin.Models;
using HotelingXamarin.Repositories;
using HotelingXamarin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HotelingXamarin.ViewModels
{
    public class ReservasViewModel:ViewModelBase
    {
        RepositoryHoteles repo;
        public ReservasViewModel()
        {
            this.repo = new RepositoryHoteles();
            Task.Run(async () => {
                MessagingCenter.Subscribe<ReservasViewModel>(this, "RESERVAS", async (sender) =>
                {
                    MiPerfil view = new MiPerfil();
                    await Application.Current.MainPage.Navigation.PushAsync(view);
                    await this.CargarReservas();
                });
                await this.CargarReservas();
            });

        }

        private async Task CargarReservas()
        {
            String token = App.Locator.SessionService.Sesion.token;
            int idusuario = App.Locator.SessionService.Sesion.usuario.ID_USUARIO;
            List<Reserva> lista = await this.repo.GetReservas(idusuario, token);
            this.Reservas = new ObservableCollection<Reserva>(lista);
        }

        private ObservableCollection<Reserva> _Reservas;

        public ObservableCollection<Reserva> Reservas
        {
            get { return this._Reservas; }
            set
            {
                this._Reservas = value;
                OnPropertyChanged("Reservas");
            }
        }

        public Command EliminarReserva
        {
            get
            {
                return new Command(async (Reservax) =>
                {
                    Reserva reserva = Reservax as Reserva;
                    await this.repo.EliminarReserva(reserva.ID_RESERVA, App.Locator.SessionService.Sesion.token);
                    MessagingCenter.Send<ReservasViewModel>(App.Locator.ReservasViewModel, "RESERVAS");
                    
                });
            }
        }
    }
}
