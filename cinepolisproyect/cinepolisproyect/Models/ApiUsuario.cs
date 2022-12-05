using System;
using System.Collections.Generic;
using System.Text;

namespace cinepolisproyect.Models
{
    // Clase con los datos de usuario
    public class ApiUsuario
    {
        public string us_id { get; set; }
        public string us_uid { get; set; }
        public string us_nombre { get; set; }
        public string us_apellido { get; set; }
        public string us_email { get; set; }
    }
    public class ApiUsuarioRoot
    {
        public IList<ApiUsuario> usuario { get; set; }
    }

    // Clase que contiene los datos HTTP
    public static class UrlApiUs
    {
        public static string ip = "cinepolishn.000webhostapp.com";
        public static string web = "Cinepolis";


        //Apis clase usuarios
        public static string postEndPoint = "InsertUser.php"; //POST
        public static string getEndPoint = "listausuario.php"; //POST

    }
    public static class UrlApiUsusario
    {
        public static string POSTUsuarioList = string.Format("http://{0}/{1}/{2}", UrlApiUs.ip, UrlApiUs.web, UrlApiUs.postEndPoint);
        public static string GETUsuarioList = string.Format("http://{0}/{1}/{2}", UrlApiUs.ip, UrlApiUs.web, UrlApiUs.getEndPoint);
    }
}
