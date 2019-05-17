using HotelingXamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HotelingXamarin.Views {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PrincipalMaster : MasterDetailPage {
        public List<MenuItemPage> MenuPaginas { get; set; }
        public PrincipalMaster() {
            InitializeComponent();

            MessagingCenter.Subscribe<PrincipalMaster>(this, "INICIAR", async (sender) => {
                PrincipalMaster view = new PrincipalMaster();
                await Application.Current.MainPage.Navigation.PushModalAsync(view);
            });

            this.MenuPaginas = new List<MenuItemPage>();
            Usuario usuario = App.Locator.SessionService.Sesion.usuario;

            if (usuario == null) {
                var page1 = new MenuItemPage() {
                    Titulo = "Login",
                    TipoPagina = typeof(Login)
                };
                this.MenuPaginas.Add(page1);
                var page2 = new MenuItemPage()
                {
                    Titulo = "Registro",
                    TipoPagina = typeof(Registro)
                };
                this.MenuPaginas.Add(page2);
            }
            else
            {
                var page1 = new MenuItemPage()
                {
                    Titulo = "Mi perfil",
                    TipoPagina = typeof(MiPerfil)
                };
                this.MenuPaginas.Add(page1);
                var page2 = new MenuItemPage()
                {
                    Titulo = "Mis reservas",
                    TipoPagina = typeof(MisReservas)
                };
                this.MenuPaginas.Add(page2);

                Button boton = new Button() {
                    Text = "Cerrar Sesión"
                };
                boton.SetBinding(Button.CommandProperty, "CerrarSesion");
                this.layout.Children.Add(boton);
                //this.layout = new StackLayout {
                //    Children = {
                //        boton
                //    }
                //};
            }
           
            var page3 = new MenuItemPage()
            {
                Titulo = "Inicio",
                TipoPagina = typeof(Inicio)
            };
            this.MenuPaginas.Add(page3);
            this.lsvmenu.ItemsSource = this.MenuPaginas;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Inicio)));
            IsPresented = false;
            this.lsvmenu.ItemSelected += CambiarPagina;
        }

        private void CambiarPagina(object sender, SelectedItemChangedEventArgs e) {
            MenuItemPage seleccionado = (MenuItemPage)e.SelectedItem;
            Detail = new NavigationPage((Page)Activator.CreateInstance(seleccionado.TipoPagina));
            IsPresented = false;
        }
    }
}