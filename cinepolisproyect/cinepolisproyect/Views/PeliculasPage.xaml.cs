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
    public partial class PeliculasPage : ContentPage
    {
        //esta lista contendra los valores del Combobox del cine seleccionado
        List<CineItemCmbClass> nombre;
        //este String contendra un no si no se a tocado el Combobox del cine o un si en caso opuesto
        string selectedcine= "no";
        public PeliculasPage()
        {
            InitializeComponent();
            //declaramos la clase InitApp() para llenar el Combobox
            InitApp();
        }
        //esta clase nos permite llenar el Combobox del Cine
        private void InitApp()
        {
            nombre = new List<CineItemCmbClass>();
            nombre.Add(new CineItemCmbClass { name = "Tegucigalpa" });
            nombre.Add(new CineItemCmbClass { name = "SPS" });
            foreach (var cinevar in nombre) { CmbCine.Items.Add(cinevar.name); }
        }
        //este evento Selected es cuando seleccionamos una de las dos opciones del Combobox
        private void CmbCine_SelectedIndexChanged(object sender, EventArgs e)
        {
            //traemos a un int llamado position la posicion seleccionada de las opciones de cine
            int position = CmbCine.SelectedIndex;
            //realizamos un if donde si realmente esta seleccionado un valor o sea su posicion 
            if (position > -1)
            {
                //ya que confirmamos que fue seleccionado una opcion del Combobox, la variable selectedcine le asignamos el si
                selectedcine = "si";
                //traemos a un String llamado namecine el unico valor seleccionado siendo el cine
                String namecine = nombre[position].name;
                //cargamos el cine seleccionado a un label que nos servira para enviar por binding dicho valor desde la variable namecine
                txtidcine.Text = namecine;
            }
        }
        //este evento Tapped es cuando seleccionamos la primera pelicula
        private async void StackPeli1_Tapped(object sender, EventArgs e)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await DisplayAlert("Sin Internet", "Por favor active su conexion a internet", "Ok");
                return;
            }
            else
            {
                //validamos primero que se ha seleccionado una opcion del combobox
                if (selectedcine == "si") { 
                    //pasamos a cargarlos valores a la clase para enviarlos al siguiente ContentPage HorariosPage por medio de BindingContext
                    Models.pelicula classdata = new Models.pelicula
                    {
                        IdCine = this.txtidcine.Text,
                        IdPelicula = "1",
                        Pelicula = this.lblpeli1.Text,
                        Imagepeli = "cartelera1.jpg",
                        Fechapeli = this.lbldate1.Text,
                    };
                    //Creamos una variable page para referenciar a HorariosPage
                    var page = new Views.HorariosPage();
                    //Mediante BindingContext enviamos la clase classdata hacia a HorariosPage mediante la variable page
                    page.BindingContext = classdata;
                    //Por ultimo enviamos la variable Page referenciado a HorariosPage con los datos de la clase mediante un Navigation.PushAsync
                    await Navigation.PushAsync(page);
                }
                else
                {
                    await DisplayAlert("Alerta", "Seleccione su cine", "OK");
                }
            }
        }
        //este evento Tapped es cuando seleccionamos la segunda pelicula
        private async void StackPeli2_Tapped(object sender, EventArgs e)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await DisplayAlert("Sin Internet", "Por favor active su conexion a internet", "Ok");
                return;
            }
            else
            {
                //validamos primero que se ha seleccionado una opcion del combobox
                if (selectedcine == "si")
                {
                    //pasamos a cargarlos valores a la clase para enviarlos al siguiente ContentPage HorariosPage por medio de BindingContext
                    Models.pelicula classdata = new Models.pelicula
                    {
                        IdCine = this.txtidcine.Text,
                        IdPelicula = "2",
                        Pelicula = this.lblpeli2.Text,
                        Imagepeli = "cartelera2.jpg",
                        Fechapeli = this.lbldate2.Text,
                    };
                    //Creamos una variable page para referenciar a HorariosPage
                    var page = new Views.HorariosPage();
                    //Mediante BindingContext enviamos la clase classdata hacia a HorariosPage mediante la variable page
                    page.BindingContext = classdata;
                    //Por ultimo enviamos la variable Page referenciado a HorariosPage con los datos de la clase mediante un Navigation.PushAsync
                    await Navigation.PushAsync(page);
                }
                else
                {
                    await DisplayAlert("Alerta", "Seleccione su cine", "OK");
                }
            }
        }
        //este evento Tapped es cuando seleccionamos la tercera pelicula
        private async void StackPeli3_Tapped(object sender, EventArgs e)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await DisplayAlert("Sin Internet", "Por favor active su conexion a internet", "Ok");
                return;
            }
            else
            {
                //validamos primero que se ha seleccionado una opcion del combobox
                if (selectedcine == "si")
                {
                    //pasamos a cargarlos valores a la clase para enviarlos al siguiente ContentPage HorariosPage por medio de BindingContext
                    Models.pelicula classdata = new Models.pelicula
                    {
                        IdCine = this.txtidcine.Text,
                        IdPelicula = "3",
                        Pelicula = this.lblpeli3.Text,
                        Imagepeli = "cartelera3.jpg",
                        Fechapeli = this.lbldate3.Text,
                    };
                    //Creamos una variable page para referenciar a HorariosPage
                    var page = new Views.HorariosPage();
                    //Mediante BindingContext enviamos la clase classdata hacia a HorariosPage mediante la variable page
                    page.BindingContext = classdata;
                    //Por ultimo enviamos la variable Page referenciado a HorariosPage con los datos de la clase mediante un Navigation.PushAsync
                    await Navigation.PushAsync(page);
                }
                else
                {
                    //en el caso que no se halla seleccionado un cine del combobox se le alerta al usuario mediante un DisplayAlert
                    await DisplayAlert("Alerta", "Seleccione su cine", "OK");
                }
            }
        }
    }
}