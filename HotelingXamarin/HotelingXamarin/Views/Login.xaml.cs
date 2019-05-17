using HotelingXamarin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HotelingXamarin.Views {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage {
        
		public Login () {
			InitializeComponent ();
            MessagingCenter.Subscribe<Login>(this, "MAL", async (sender) => {
                this.incorrecto.Text = "Usuario/Password incorrecto";
            });
            
        }
	}
}