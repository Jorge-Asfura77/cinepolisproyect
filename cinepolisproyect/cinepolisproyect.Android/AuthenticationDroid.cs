using Android.App;
using Android.Content;
using Android.Gms.Extensions;
using Android.OS;
using Android.Runtime;
using Android.Views;
using cinepolisproyect.Droid;
using Firebase.Auth;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(AuthenticationDroid))]
namespace cinepolisproyect.Droid
{
    /// Creamos una clase llamada AuthenticationDroid la cual tendra como base de desarrollo la interfaz Authentication
    /// implementamos la interfaz en dicha clase
    public class AuthenticationDroid : Authentication
    {

        // Obtener el usuario actual en la plataforma de Firebase
        public bool IsSignIn()
        {
            // creamos una variable que sera igual a la clase pública abstracta FirebaseAuth para
            //obtener una instancia de esta clase llamando Instance, por ultimo llamamos CurrentUser para obtener un FirebaseUser objeto,
            //que contiene información sobre el usuario que inició sesión. Y retornara esta informacion si el user es distinto de nulo. 
            var user = Firebase.Auth.FirebaseAuth.Instance.CurrentUser;
            var signedIn = user != null;
            return signedIn;

        }

        //Inicio de sesion en una instancia de Firebase
        public async Task<string> LoginWithEmailAndPassword(string email, string password)
        {
            try
            {
                //creamos una variable que mandara a llamar una instancia en Firebase con Instance y dada una instancia
                //llamaremos el metodo SignInWithEmailAndPasswordAsync para iniciar sesión con la dirección de correo electrónico y la contraseña proporcionadas.

                await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                var user = Firebase.Auth.FirebaseAuth.Instance.CurrentUser;

                //creamos una variable que obtendrá el el usuario actual en firebase y le preguntamos si el correo ha sido verificado 
                var update = user.IsEmailVerified;
                if (update == true)
                {
                     await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                }
                else
                {
                    return string.Empty;
                }

                //Obtener token que es un identificador unico para cada usuario y que se obtiene una vez que se ha iniciado sesion
                var token = user.GetIdToken(false);
                return (string)token;
            }
            catch (FirebaseAuthInvalidUserException e)
            {
                e.PrintStackTrace();
                return string.Empty;
            }
            catch (FirebaseAuthInvalidCredentialsException e)
            {
                e.PrintStackTrace();
                return string.Empty;
            }
        }

        //Restablecer contraseña con un correo electronico
        //public async Task ResetPassword(string email)
        //{
            
        //}



        //Cierre de sesion 
        public bool SignOut()
        {
            try
            {
                ///SignOut() cierra una sesion activa en una instancia en Firebase
                Firebase.Auth.FirebaseAuth.Instance.SignOut();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }


        //Crear una cuenta en firebase con un email y un password
        public async Task<string> SignUpWithEmailAndPassword(string nombre, string apellido, string email, string password)
        {
            try
            {
                //Se crea una variable llamada newUser para invocar una instancia en la plataforma de Firebase
                //le pasamos el metodo asincrono CreateUserWithEmailAndPasswordAsync con los parametros correspondientes,
                //para crear un usuario con un correo y una contraseña.  
                var newUser = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);

                //Un vez creado el usuario debemos saber si este realmente existe, por lo que se crea una nueva variable que sera
                //igual a la variable que obtiene la instancia y la creacion del usuario newUser y le indicamos que queremos acceder
                //al usuario creado con User. 
                var user = newUser.User;


                // Obtenemos el UID del usuario creado para almacenarlo en MySQL
                var uid = FirebaseAuth.Instance.CurrentUser.Uid;

                // Enviamos todos los datos necesarios para la tabla usuario
                var postususario = new Models.ApiUsuario
                {
                    us_uid = uid,
                    us_nombre = nombre,
                    us_apellido = apellido,
                    us_email = email
                };

                await Controllers.UsuariosController.CrearUsuario(postususario); // Envia a UsuariosController

                // Una vez que obtenemos el usuario le asignamos el metodo SendEmailVerification que sera el encargado de enviar
                //un enlace de verificar al correo de dicho usuario. 
                await user.SendEmailVerification();

                //Obtener token que es un identificador unico para cada usuario y que se obtiene una vez que se ha iniciado sesion
                var token = newUser.User.GetIdToken(false);

                return (string)token;
            }
            catch (FirebaseAuthInvalidUserException e)
            {
                e.PrintStackTrace();
                return string.Empty;
            }
            catch (FirebaseAuthInvalidCredentialsException e)
            {
                e.PrintStackTrace();
                return string.Empty;
            }
        }

        public async Task ResetPassword(string email)
        {
            //Primero debemos de mandar a llamar una instancia de Firebase
            //para saber si el correo electronico que se proporciona tiene una sesion activa en la plataforma
            //luego le pasamos el metodo SendPasswordResetEmailAsync que enviara un enlace al email proporcionado.
    
                await FirebaseAuth.Instance.SendPasswordResetEmailAsync(email);


        }

        public async Task<string> Uid()
        {
            var user = FirebaseAuth.Instance.CurrentUser;
            string userUid = user.Uid;
            return (string)userUid;

        }
    }
}
