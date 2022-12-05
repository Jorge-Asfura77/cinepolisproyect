using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace cinepolisproyect.Controllers
{
    public class UsuariosController
    {
        public class UrlApiUsusario
        {
            public const String CrearSitio = "https://cinepolishn.000webhostapp.com/Cinepolis/InsertUser.php";
        }

        //METODO POST USUARIOS
        public async static Task CrearUsuario(Models.ApiUsuario postusuario)
        {
            String json = JsonConvert.SerializeObject(postusuario);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            using (HttpClient cliente = new HttpClient())
            {
                response = await cliente.PostAsync(Models.UrlApiUsusario.POSTUsuarioList, content);
            }
            if (response.IsSuccessStatusCode)
            {
                var respuesta = response.Content.ReadAsStringAsync().Result;
                Debug.WriteLine("Usuario Guardado");
            }
            else
            {
                Debug.WriteLine("ERROR");
            }
        }
        //METODO GET USUARIOS
        public async static Task<List<Models.ApiUsuario>> GetListUsuarios()
        {
            List<Models.ApiUsuario> listbutaca = new List<Models.ApiUsuario>();
            using (HttpClient cliente = new HttpClient())
            {
                var response = await cliente.GetAsync(Models.UrlApiUsusario.GETUsuarioList);

                if (response.IsSuccessStatusCode)
                {
                    var JsonContent = response.Content.ReadAsStringAsync().Result;
                    var ButacaDes = JsonConvert.DeserializeObject<Models.ApiUsuarioRoot>(JsonContent);
                    listbutaca = ButacaDes.usuario as List<Models.ApiUsuario>;
                    var abc = JsonContent;
                }
            }
            return listbutaca;
        }
    }
}
