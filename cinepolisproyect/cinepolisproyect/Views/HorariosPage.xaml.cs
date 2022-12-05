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
    public partial class HorariosPage : ContentPage
    {
        public HorariosPage()
        {
            InitializeComponent();
        }
        //Este evento Clicked es cuando seleccionan el primer horario de las 3 00pm
        private async void btntrespm_Clicked(object sender, EventArgs e)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await DisplayAlert("Sin Internet", "Por favor active su conexion a internet", "Ok");
                return;
            }
            else
            {
                //aqui cargamos los datos que se enviaran al sigueinte ContentPage que es ButacaPage
                Models.pelicula classdata = new Models.pelicula
                {
                    IdCine = this.txtidcine.Text,
                    IdPelicula = this.txtidpeli.Text,
                    Pelicula = this.txtpeli.Text,
                    Imagepeli = this.txtimage.Text,
                    Fechapeli = this.txtdate.Text,
                    IdHorario = "1",
                    Horario = this.btntrespm.Text,
                };
                //Creamos una variable page para referenciar a ButacaPage
                var page = new Views.ButacaPage();
                //Mediante BindingContext enviamos la clase classdata hacia a ButacaPage mediante la variable page
                page.BindingContext = classdata;
                //Por ultimo enviamos la variable Page referenciado a ButacaPage con los datos de la clase mediante un Navigation.PushAsync
                await Navigation.PushAsync(page);
            }
        }
        //Este evento Clicked es cuando seleccionan el segundo horario de las 5 00pm
        private async void btncincopm_Clicked(object sender, EventArgs e)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await DisplayAlert("Sin Internet", "Por favor active su conexion a internet", "Ok");
                return;
            }
            else
            {
                //aqui cargamos los datos que se enviaran al sigueinte ContentPage que es ButacaPage
                Models.pelicula classdata = new Models.pelicula
                {
                    IdCine = this.txtidcine.Text,
                    IdPelicula = this.txtidpeli.Text,
                    Pelicula = this.txtpeli.Text,
                    Imagepeli = this.txtimage.Text,
                    Fechapeli = this.txtdate.Text,
                    IdHorario = "2",
                    Horario = this.btncincopm.Text,
                };
                //Creamos una variable page para referenciar a ButacaPage
                var page = new Views.ButacaPage();
                //Mediante BindingContext enviamos la clase classdata hacia a ButacaPage mediante la variable page
                page.BindingContext = classdata;
                //Por ultimo enviamos la variable Page referenciado a ButacaPage con los datos de la clase mediante un Navigation.PushAsync
                await Navigation.PushAsync(page);
            }
        }
        //Este evento Clicked es cuando seleccionan el tercer horario de las 7 00pm
        private async void btnsietepm_Clicked(object sender, EventArgs e)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await DisplayAlert("Sin Internet", "Por favor active su conexion a internet", "Ok");
                return;
            }
            else
            {
                //aqui cargamos los datos que se enviaran al sigueinte ContentPage que es ButacaPage
                Models.pelicula classdata = new Models.pelicula
                {
                    IdCine = this.txtidcine.Text,
                    IdPelicula = this.txtidpeli.Text,
                    Pelicula = this.txtpeli.Text,
                    Imagepeli = this.txtimage.Text,
                    Fechapeli = this.txtdate.Text,
                    IdHorario = "3",
                    Horario = this.btnsietepm.Text,
                };
                //Creamos una variable page para referenciar a ButacaPage
                var page = new Views.ButacaPage();
                //Mediante BindingContext enviamos la clase classdata hacia a ButacaPage mediante la variable page
                page.BindingContext = classdata;
                //Por ultimo enviamos la variable Page referenciado a ButacaPage con los datos de la clase mediante un Navigation.PushAsync
                await Navigation.PushAsync(page);
            }
        }
    }
}