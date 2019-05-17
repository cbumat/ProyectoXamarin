using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HotelingXamarin.Views {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Registro : ContentPage {
		public Registro () {
			InitializeComponent ();
            MessagingCenter.Subscribe<Registro>(this, "REGISTRO", async (sender) => {
                MasterDetailPage view = new MasterDetailPage();
                await Application.Current.MainPage.Navigation.PushModalAsync(view);
            });
        }
	}
}