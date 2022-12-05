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
    public partial class RegistroPage : ContentPage
    {
        // creamos una variable que invoque a toda la interfaz de Authentication
        Authentication authentication;
        public RegistroPage()
        {
            InitializeComponent();

            //Se invoca la funcionalidad de la interfaz nativa desde el código compartido.
            authentication = DependencyService.Get<Authentication>();
        }


        //Validar los campos de los formularios
        private async Task<bool> validarFormulario()
        {
            //Valida conexión a Internet
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await this.DisplayAlert("Sin Internet", "Se ha perdido la conexion a internet", "Ok");
                return false;
            }

            //Valida si el valor en los Entry se encuentra vacio o es igual a Null
            if (String.IsNullOrWhiteSpace(ttname.Text) || String.IsNullOrWhiteSpace(ttlastname.Text) || String.IsNullOrWhiteSpace(ttemail.Text) || String.IsNullOrWhiteSpace(ttpassword.Text))
            {
                await this.DisplayAlert("Advertencia", "Todos los campos son obligatorios.", "OK");
                return false;
            }

            ///Valida que solo se ingresen letras en los campos nombre y apellido con Regex.IsMatch
            ///Indica si la expresión regular encuentra una coincidencia en la cadena de entrada.
            string letras = @"^[a-zA-Z_ ]*$";
            bool resultado = Regex.IsMatch(ttname.Text, letras, RegexOptions.IgnoreCase);
            if (!resultado)
            {
                await this.DisplayAlert("Advertencia", "Solo se admiten letras en el campo nombre. ", "OK");
                return false;
            }

            string solo_letras = @"^[a-zA-Z_ ]*$";
            bool resultado_letras = Regex.IsMatch(ttlastname.Text, solo_letras, RegexOptions.IgnoreCase);
            if (!resultado_letras)
            {
                await this.DisplayAlert("Advertencia", "Solo se admiten letras en el campo apellido. ", "OK");
                return false;
            }


            ///Valida un formato correcto de correo electronico 
            bool isEmail = Regex.IsMatch(ttemail.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (!isEmail)
            {
                await this.DisplayAlert("Advertencia", "El formato del correo electrónico es incorrecto, revíselo e intente de nuevo.", "OK");
                return false;
            }

            //Valida que la contraseña sea mayor a 8 digitos 
            if (ttpassword.Text.Length < 8)
            {
                await this.DisplayAlert("Advertencia", "La contraseña debe ser mayor o igual a 8 dígitos. ", "OK");
                return false;
            }

            return true;
        }


        //Navegar hacia la pagina del LoginPage()
        private void btn_enviologin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }

        //Registrar un usuario
        private async void btn_registrar_Clicked(object sender, EventArgs e)
        {
            //Confirma que los campos esten validados
            if (await validarFormulario())
            {
              
                try
                {
                    //Ya validados los campos, se crea una variable user donde se invoca al task SignUpWithEmailAndPassword y el contenido de los entry
                    //del email y password, requeridos para crear la cuenta de usuario
                    var user = await authentication.SignUpWithEmailAndPassword(ttname.Text, ttlastname.Text, ttemail.Text, ttpassword.Text);
                    if (user != string.Empty)
                    {
                        
                        //Si la variable user es distinto de nulo, es porque en efecto se creo el usuario
                        //le salta un alerta al usuario de lo que ha sucedido. 
                        await DisplayAlert("Exito", "Usuario creado correctamente", "Ok");
                      

                        var signOut = authentication.SignOut();

                        if (signOut)
                        {
                            await Navigation.PushAsync(new LoginPage());
                        }

                        //Se le indica que en la task SignUpWithEmailAndPassword se ha disparado el metodo SendEmailVerification.
                        await this.DisplayAlert("Alerta", "Hemos enviado un enlace a tu direccion de correo electronico para verificar tu cuenta. ", "OK");
                        ClearScreen();                      
                    }
                   

                    ///Si la variable user es igual a nulo, hubo un error en la creacion del usuario y salta una alerta 
                    ///informando del problema
                    else
                    {
                        await DisplayAlert("Error", "Error al crear usuario. El correo electronico que proporcionaste esta siendo usando por otra cuenta.", "Ok");
                    }
                }
                catch(Exception exception)
                {
                    if (exception.Message.Contains("EMAIL_EXISTS"))
                    {
                        await DisplayAlert("Error", exception.Message, "Ok");
                    }
                    else
                    {
                        await DisplayAlert("Alerta", "La direccion de correo electronico ya esta siendo usada por otra cuenta. Intente usando otro correo electrónico. ", "Ok");

                    }
                }
               

            }
        }


        /// Funcion para vaciar las cajas de texto
        private void ClearScreen()
        {
            this.ttname.Text = String.Empty;
            this.ttlastname.Text = String.Empty;
            this.ttemail.Text = String.Empty;
            this.ttpassword.Text = String.Empty;

        }
    }
}