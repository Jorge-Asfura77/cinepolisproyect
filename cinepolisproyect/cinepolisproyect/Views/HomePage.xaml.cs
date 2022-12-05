using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cinepolisproyect.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {

        // creamos una variable que invoque a toda la interfaz de Authentication
        Authentication authentication;
        public HomePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            //Se invoca la funcionalidad de la interfaz nativa desde el código compartido.
            authentication = DependencyService.Get<Authentication>();
        }

        //cerrar sesion, navega hacia el LoginPage()
        private async void btn_signOut_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Cerrar sesión", "¿Desea cerrar sesión en su cuenta?", "Si", "No");
            Debug.WriteLine("Answer: " + answer);

            if(answer == true)
            {
                var signOut = authentication.SignOut();

                if (signOut)
                {
                    Application.Current.MainPage = new NavigationPage(new StartPage());
                }
            }
            
         
        }
    }
}