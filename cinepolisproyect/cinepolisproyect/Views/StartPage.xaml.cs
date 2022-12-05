using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Xamarin.Essentials;

namespace cinepolisproyect.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            
        }

        
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await DisplayAlert("Sin Internet", "Por favor active su conexion a internet", "Ok");
                return;
            }
            else
            {
                //await DisplayAlert("", "Bienvenido", "Ok");
                Navigation.PushAsync(new RegistroPage());
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await DisplayAlert("Sin Internet", "Por favor active su conexion a internet", "Ok");
                return;
            }
            else
            {
                //await DisplayAlert("", "Bienvenido", "Ok");
                Navigation.PushAsync(new LoginPage());
            }
            
            
        }
    }
}