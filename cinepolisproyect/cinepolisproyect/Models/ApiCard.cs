using System;
using System.Collections.Generic;
using System.Text;

namespace cinepolisproyect.Models
{
    public class ApiCard
    {
        public string trj_ntarjeta { get; set; }
        public string trj_fchvencimiento { get; set; }
        public string trj_cdgseguridad { get; set; }
        public string us_id { get; set; }
        public string IdCine { get; set; }
        public string IdPelicula { get; set; }
        public string IdHorario { get; set; }
        public string IdCombo { get; set; }
        public string RefrescoExtra { get; set; }
        public string ContButaca { get; set; }
        public string asientosSelected { get; set; }
        public string totalpagar { get; set; }
    }
    public class RootApiCard
    {
        public IList<ApiCard> tarjeta { get; set; }
    }
    // Clase que contiene los datos HTTP
    public static class UrlApiCd
    {
        public static string ip = "cinepolishn.000webhostapp.com";
        public static string web = "Cinepolis";


        //Apis clase usuarios
        public static string postEndPoint = "InsertTarjeta.php"; //POST
        public static string getEndPoint = "listartarjeta.php"; //GET

    }
    public static class UrlApiCard
    {
        public static string POSTCardList = string.Format("http://{0}/{1}/{2}", UrlApiCd.ip, UrlApiCd.web, UrlApiCd.postEndPoint);
        public static string GETCardList = string.Format("http://{0}/{1}/{2}", UrlApiCd.ip, UrlApiCd.web, UrlApiCd.getEndPoint);
    }
}
