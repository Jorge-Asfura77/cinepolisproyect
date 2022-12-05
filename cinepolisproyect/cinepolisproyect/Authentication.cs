using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace cinepolisproyect
{
    //Creamos una interfaz de que contendran los Task o tareas que seran invocadas en la clase de AuthenticationDroid
    public interface Authentication
    {
        //Creamos una tarea de tipo string, llamada LoginWithEmailAndPassword que tendra dos parametros de tipo string,
        //el email y la contraseña para iniciar sesion. 
        Task<string> LoginWithEmailAndPassword(string email, string password);

        //Creamos una tarea de tipo string, llamada SignUpWithEmailAndPassword que tendra dos parametros de tipo string,
        //el email y la contraseña para crear una cuenta de usuario. 
        Task<string> SignUpWithEmailAndPassword(string nombre, string apellido, string email, string password);


        //Creamos una tarea llamada ResetPassword que tendra un unico parametro de tipo string,
        //el email para enviar un enlace por correo electronico para restablecer contraseña. 
        Task ResetPassword(string email);

        //Obtener el Uid del usuario
        Task<string> Uid();

        //Una funcion de tipo booleano para cerrar sesion
        bool SignOut();

        //Una funcion de tipo booleano para obtener el usuario actual
        bool IsSignIn();
    }
}
