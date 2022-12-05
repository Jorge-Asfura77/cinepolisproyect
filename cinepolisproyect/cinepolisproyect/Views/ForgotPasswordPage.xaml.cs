using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cinepolisproyect.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPasswordPage : ContentPage
    {
        Authentication authentication;
        public ForgotPasswordPage()
        {
            InitializeComponent();
            authentication = DependencyService.Get<Authentication>();
        }

        private async Task<bool> validarFormulario()
        {
            //Valida conexión a Internet
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await this.DisplayAlert("Sin Internet", "Se ha perdido la conexion a internet", "Ok");
                return false;
            }

            //Valida si el valor en el Entry se encuentra vacio o es igual a Null
            if (String.IsNullOrWhiteSpace(ttemail_user_recu.Text))
            {
                await this.DisplayAlert("Advertencia", "El campos es obligatorio.", "OK");
                return false;
            }

            ///Valida un formato correcto de correo electronico 
            bool isEmail = Regex.IsMatch(ttemail_user_recu.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (!isEmail)
            {
                await this.DisplayAlert("Advertencia", "El formato del correo electrónico es incorrecto, revíselo e intente de nuevo.", "OK");
                return false;
            }

            return true;
        }


        //Envio del enlace para restablecer contraseña
        private async void btn_restablecer_Clicked(object sender, EventArgs e)
        {
            //Confirma que los campos esten validados
            if (await validarFormulario())
            {

                    //Ya validados los campos, se invoca al task ResetPassword y el contenido del entry
                    //del email. 
                    await authentication.ResetPassword(ttemail_user_recu.Text);

                    //Un alert para indicarle que se ha enviado un enlace al correo proporcionado
                    await this.DisplayAlert("Alerta", "Hemos enviado un enlace a tu direccion de correo electronico para que puedas restablecer tu contraseña", "OK");
                    ClearScreen();

                    //Navegacion hacia la pagina del LoginPage()
                    await Navigation.PushAsync(new LoginPage());
            }
        }

        /// Funcion para vaciar las cajas de texto
        private void ClearScreen()
        {
            this.ttemail_user_recu.Text = String.Empty;

        }
    }
}