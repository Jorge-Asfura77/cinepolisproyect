using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cinepolisproyect.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistorialPage : ContentPage
    {
        //Esta clase nos guardara los datos de todos los usuarios
        public Models.ApiUsuario usuariosdata;
        //esta lista nos reflejara cada uno de los registros hechos por el usuario
        public List<Models.ApiCard> lsttarjeta { get; private set; } = new List<Models.ApiCard>();
        //esta variable nos ayuda a retornar el UID de Firebase del usuario
        Authentication authentication;
        public HistorialPage()
        {
            InitializeComponent();
            //Esto tambien ayuda en el retorno del UID de Firebase del usuario
            authentication = DependencyService.Get<Authentication>();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //llamamos la funcion para mandar a llamar el ID del usuario por su IUD de Firebase
            ValidarInternet();

        }
        public async void ValidarInternet()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await DisplayAlert("Sin Internet", "Se ha perdido la conexion a internet", "Ok");
                txtNodata.Text = "--por favor active el internet--";
                return;
            }
            else
            {
                txtNodata.Text = "";
                traerID();

            }
        }
        public async void traerID()
        {
            //traemos en una variable el UID
            string userUid = await authentication.Uid();
            //Llamamos la funcion GetListUsuarios para traer todos los usuarios
            List<Models.ApiUsuario> listclientes = await cinepolisproyect.Controllers.UsuariosController.GetListUsuarios();
            //declaramos un sentinela para buscar entre los registros con un while
            int sent = 1;
            //declaramos un contador que nos sirve de posicionamiento dinamico de List
            int cont = 0;
            //este while nos servira para poder encontrar el ID del usuario por su UID de Firebase
            while (sent==1)
            {
                //Comparamos cada uno de los UID con el del Usuario que estamos buscando
                if (listclientes[cont].us_uid == userUid)
                {
                    //caso de ser al que buscamos seteamos su informacion en usuariodata
                    usuariosdata = listclientes[cont];
                    //le declaramos valor 0 al sentinela para que termine el while
                    sent = 0;
                }
                //caso opuesto de no ser lo que buscamos
                else
                {
                    //incrementamos en 1 el contador para buscar en la siguiente posicion
                    cont += 1;
                }
            }
            //traemos todos los registros de compra de todos los usuarios
            List<Models.ApiCard> listtarjeta = await cinepolisproyect.Controllers.CardController.GetListTarjeta();
            //seteamos de nuevo el valor del sentinela para el nuevo while
            sent = 1;
            //asi mismo lo hacemos con el contador
            cont = 0;
            //declaramos este numero para funcionar como indice de cada registro 
            int num = 1;
            //obtenemos la cantidad de registros del list<> en la variable cantlimite para no excedernos en la busqueda por posicion
            int cantlimite = listtarjeta.Count - 1;
            //mediante este while podremos buscar cada uno de los registros pertenecientes al usuario 
            while (sent == 1)
            {
                //en el caso de que el ID coincida con el registro entonces setearemos esos valores para mostraerlos
                if (listtarjeta[cont].us_id == usuariosdata.us_id)
                {
                    //seteamos todos esos valores en variables de texto
                    string vartrj_ntarjeta = num.ToString();
                    num += 1;
                    string vartrj_fchvencimiento = listtarjeta[cont].trj_fchvencimiento;
                    string vartrj_cdgseguridad = listtarjeta[cont].trj_cdgseguridad;
                    string varus_id = listtarjeta[cont].us_id;
                    string varIdCine = listtarjeta[cont].IdCine;
                    //en el caso de la pelicula setearemos solo el nombre y no su ID
                    string varIdPelicula;
                    if (listtarjeta[cont].IdPelicula == "1"){varIdPelicula = "Eternals";}
                    else if (listtarjeta[cont].IdPelicula == "2"){varIdPelicula = "Venom";}
                    else if (listtarjeta[cont].IdPelicula == "3"){varIdPelicula = "Black Widow";}
                    else {varIdPelicula = "Ninguna";}
                    //tambien en horario seria nombre en vez de ID
                    string varIdHorario;
                    if (listtarjeta[cont].IdHorario == "1") { varIdHorario = "3 00PM"; }
                    else if (listtarjeta[cont].IdHorario == "2") { varIdHorario = "5 00PM"; }
                    else if (listtarjeta[cont].IdHorario == "3") { varIdHorario = "7 00PM"; }
                    else { varIdHorario = "Ninguna"; }
                    //Igualmente si no seteamos su ID sino su nombre
                    string varIdCombo;
                    if (listtarjeta[cont].IdCombo == "1") { varIdCombo = "Combo 1 -> Palomitas de maíz y Dos refrescos"; }
                    else if (listtarjeta[cont].IdCombo == "2") { varIdCombo = "Combo 2 -> Palomitas de maíz y Un refresco"; }
                    else if (listtarjeta[cont].IdCombo == "3") { varIdCombo = "Combo 3 -> Nachos y Un refresco"; }
                    else { varIdCombo = "Ninguna"; }
                    //en el caso de los refrescos seteamos ningun refresco extra en el caso de ser 00
                    string varRefrescoExtra;
                    if (listtarjeta[cont].RefrescoExtra == "00") { varRefrescoExtra = "Ningun Refresco Extra"; }
                    else { varRefrescoExtra = listtarjeta[cont].RefrescoExtra; }
                    //terminamos de setear los demas datos
                    string varContButaca = listtarjeta[cont].ContButaca;
                    string varasientosSelected = listtarjeta[cont].asientosSelected;
                    string vartotalpagar = listtarjeta[cont].totalpagar;

                    //ahora añadiamos este nuevo registro en el list<> mediante el uso de las variables
                    lsttarjeta.Add(new Models.ApiCard()
                    {
                        trj_ntarjeta = vartrj_ntarjeta,
                        trj_fchvencimiento = vartrj_fchvencimiento,
                        trj_cdgseguridad = vartrj_cdgseguridad,
                        us_id = varus_id,
                        IdCine = varIdCine,
                        IdPelicula = varIdPelicula,
                        IdHorario = varIdHorario,
                        IdCombo = varIdCombo,
                        RefrescoExtra = varRefrescoExtra,
                        ContButaca = varContButaca,
                        asientosSelected = varasientosSelected,
                        totalpagar = vartotalpagar
                    });
                }
                //en el caso de llegar al limite de los registros segun la variable cantlimite con la variable cont
                if (cont >= cantlimite)
                {
                    //seteamos el valor 0 al sentinela para que detenga el while
                    sent = 0;
                }
                //incrementamos en 1  el contador para que pasemos al siguiente posicion de los registros
                cont += 1;
            }
            //en el caso de que no hayan registros se notifica al usuario en pantalla
            if(lsttarjeta.Count < 1)
            {
                await DisplayAlert("Alerta", "No tiene ningun Registro", "OK");
                txtNodata.Text = "--No ha realizado ninguna compra--";
            }
            //caso opuesto se le carga los datos en el listview
            else
            {
                BindingContext = this;
                await DisplayAlert("Alerta", "Actualizando...", "OK");
            }
            
        }

        private async void btn_Refresh_Clicked(object sender, EventArgs e)
        {
            //este boton sirve para recargar entonces realmente ejecutamos la misma funcion que al iniciar el contentpage
            ValidarInternet();
        }
    }
}