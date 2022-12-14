using System;
using System.Collections.Generic;
using System.Text;

namespace cinepolisproyect.Models
{
    public static class UrlApi
    {
        //public static string ip = "cinepolishn.000webhostapp.com";
        public static string ip = "ticketstorepm2.000webhostapp.com";
        public static string web = "Cinepolis";


        //Apis clase sitios
        public static string getEndPoint = "listabutaca.php"; //GET
        //public static string postEndPoint = "crear.php"; //POST
        public static string updateEndPoint = "actualizarbutaca.php"; //UPDATE
        //public static string deleteEndPoint = "eliminarsitio.php"; //DELETE
    }
    public static class ApiButaca
    {
        public static string GETButacaList = string.Format("http://{0}/{1}/{2}", UrlApi.ip, UrlApi.web, UrlApi.getEndPoint);
        //public static string POSTSitioList = string.Format("http://{0}/{1}/{2}", UrlApi.ip, UrlApi.web, UrlApi.postEndPoint);
        public static string UPDATEButacaList = string.Format("http://{0}/{1}/{2}", UrlApi.ip, UrlApi.web, UrlApi.updateEndPoint);
        //public static string DELETESitioList = string.Format("http://{0}/{1}/{2}", UrlApi.ip, UrlApi.web, UrlApi.deleteEndPoint);
    }
    public class Butaca
    {
        public string idbutaca { get; set; }
        public string a1 { get; set; }
        public string a2 { get; set; }
        public string a3 { get; set; }
        public string a4 { get; set; }
        public string a5 { get; set; }
        public string a6 { get; set; }
        public string a7 { get; set; }
        public string b1 { get; set; }
        public string b2 { get; set; }
        public string b3 { get; set; }
        public string b4 { get; set; }
        public string b5 { get; set; }
        public string b6 { get; set; }
        public string b7 { get; set; }
        public string c1 { get; set; }
        public string c2 { get; set; }
        public string c3 { get; set; }
        public string c4 { get; set; }
        public string c5 { get; set; }
        public string c6 { get; set; }
        public string c7 { get; set; }
        public string d1 { get; set; }
        public string d2 { get; set; }
        public string d3 { get; set; }
        public string d4 { get; set; }
        public string d5 { get; set; }
        public string d6 { get; set; }
        public string d7 { get; set; }
        public string e1 { get; set; }
        public string e2 { get; set; }
        public string e3 { get; set; }
        public string e4 { get; set; }
        public string e5 { get; set; }
        public string e6 { get; set; }
        public string e7 { get; set; }
        public string f1 { get; set; }
        public string f2 { get; set; }
        public string f3 { get; set; }
        public string f4 { get; set; }
        public string f5 { get; set; }
    }
    public class ButacaRoot
    {
        public IList<Butaca> butaca { get; set; }
    }
}
