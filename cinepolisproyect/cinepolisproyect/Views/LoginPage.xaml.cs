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
    public partial class LoginPage : ContentPage
    {
        // creamos una variable que invoque a toda la interfaz de Authentication
        Authentication authentication;
        public LoginPage()
        {
            InitializeComponent();
            
            //Se invoca la funcionalidad de la interfaz nativa desde el código compartido.
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
            if (String.IsNullOrWhiteSpace(ttemail_user.Text) || String.IsNullOrWhiteSpace(ttpassword.Text))
            {
                await this.DisplayAlert("Advertencia", "Todos los campos son obligatorios.", "OK");
                return false;
            }

            //Se valida que el correo electronico tenga un formato de email correcto
            bool isEmail = Regex.IsMatch(ttemail_user.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (!isEmail)
            {
                await this.DisplayAlert("Advertencia", "El formato del correo electrónico es incorrecto, revíselo e intente de nuevo.", "OK");
                return false;
            }

            //Se valida que la contraseña sea mayor a 8 digitos
            if (ttpassword.Text.Length < 8)
            {
                await this.DisplayAlert("Advertencia", "La contraseña debe ser mayor o igual a 8 dígitos. ", "OK");
                return false;
            }

            return true;
        }

        //Navegar hacia la pagina del ForgotPasswordPage()
        private void btn_contraseña_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForgotPasswordPage());
        }

        //Navegar hacia la pagina del RegistroPage()
        private void btn_registrate_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistroPage());
        }

        //Iniciar sesion
        private async void btn_signIn_Clicked(object sender, EventArgs e)
        {
            //Confirma que los campos esten validados
            if (await validarFormulario())
            {
                //Ya validados los campos, se crea una variable de tipo string donde se invoca al task LoginWithEmailAndPassword y el contenido de los entry
                //del email y password, requeridos para iniciar sesion. 

                string token = await authentication.LoginWithEmailAndPassword(ttemail_user.Text, ttpassword.Text);

                //Si token es distinto de string.Empty, significa que no hubo errores en el proceso
                if (token != string.Empty)
                    {
                        //Se vacian los campos 
                        ClearScreen();
                   

                    //Se navega hacia la pagina DashboardPage()
                    Application.Current.MainPage = new NavigationPage(new DashboardPage()); 
                }
                else
                {
                        await DisplayAlert("Error de Autenticacion", "Contraseña o correo no existen, o la direccion de correo electronico no ha sido verificada. ", "Ok");
                }
               
            }
        }

        /// Funcion para vaciar las cajas de texto
        private void ClearScreen()
        {
            this.ttemail_user.Text = String.Empty;
            this.ttpassword.Text = String.Empty;

        }
    }
}