using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace cinepolisproyect.Controllers
{
    class ButacasController
    {
        //public class ApiSitio
        //{
        //    public const String CrearSitio = "https://cinepolishn.000webhostapp.com/RestAPI/crear.php";
        //}


        //METODO GET
        public async static Task<List<Models.Butaca>> GetListButaca()
        {
            List<Models.Butaca> listbutaca = new List<Models.Butaca>();
            using (HttpClient cliente = new HttpClient())
            {
                var response = await cliente.GetAsync(Models.ApiButaca.GETButacaList);
            
                if (response.IsSuccessStatusCode)
                {
                    var JsonContent = response.Content.ReadAsStringAsync().Result;
                    var ButacaDes = JsonConvert.DeserializeObject<Models.ButacaRoot>(JsonContent);
                    listbutaca = ButacaDes.butaca as List<Models.Butaca>;
                }
            }
            return listbutaca;
        }

        ////METODO GET

        //public async static Task<List<Models.butaca>> GetListSitios()
        //{
        //    List<Models.butaca> listsitio = new List<Models.butaca>();
        //    using (HttpClient client = new HttpClient())
        //    {
        //        var response = await client.GetAsync(Models.ApiSitio.GETSitioList);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var JsonContent = response.Content.ReadAsStringAsync().Result;
        //            var SitioDes = JsonConvert.DeserializeObject<Models.SitioRoot>(JsonContent);
        //            listsitio = SitioDes.sitios as List<Models.Sitio>;
        //        }
        //    }
        //    return listsitio;
        //}

        //METODO UPDATE
        public async static Task UpdateSitio(string butaca)
        {
            
            StringContent contenido = new StringContent(butaca, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            using (HttpClient client = new HttpClient())
            {
                response = await client.PostAsync(Models.ApiButaca.UPDATEButacaList, contenido);
            }
            if (response.IsSuccessStatusCode)
            {
                var respuesta = response.Content.ReadAsStringAsync().Result;
                Debug.WriteLine("Butaca Actulizada");
            }
            else
            {
                Debug.WriteLine("ERROR");
            }
        }

    }
}
