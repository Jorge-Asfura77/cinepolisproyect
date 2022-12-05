using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace cinepolisproyect.Controllers
{
    public class CardController
    {

        //METODO POST TARJETA
        public async static Task CrearTarjeta(Models.ApiCard postcard)
        {
            String json = JsonConvert.SerializeObject(postcard);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            using (HttpClient cliente = new HttpClient())
            {
                response = await cliente.PostAsync(Models.UrlApiCard.POSTCardList, content);
            }
            if (response.IsSuccessStatusCode)
            {
                var respuesta = response.Content.ReadAsStringAsync().Result;
                Debug.WriteLine("Tarjeta Guardada");
            }
            else
            {
                Debug.WriteLine("ERROR");
            }
        }
        //METODO GET TARJETA
        public async static Task<List<Models.ApiCard>> GetListTarjeta()
        {
            List<Models.ApiCard> listbutaca = new List<Models.ApiCard>();
            using (HttpClient cliente = new HttpClient())
            {
                var response = await cliente.GetAsync(Models.UrlApiCard.GETCardList);

                if (response.IsSuccessStatusCode)
                {
                    var JsonContent = response.Content.ReadAsStringAsync().Result;
                    var ButacaDes = JsonConvert.DeserializeObject<Models.RootApiCard>(JsonContent);
                    listbutaca = ButacaDes.tarjeta as List<Models.ApiCard>;
                    var abc = JsonContent;
                }
            }
            return listbutaca;
        }
    }
}
