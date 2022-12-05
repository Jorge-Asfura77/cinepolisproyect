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
    public partial class TiendaPage : ContentPage
    {
        public TiendaPage()
        {
            InitializeComponent();
        }

        private async void StackCombo1_Tapped(object sender, EventArgs e)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await DisplayAlert("Sin Internet", "Por favor active su conexion a internet", "Ok");
                return;
            }
            else
            {
                if(txtrefrescoextra.Text== "" || txtrefrescoextra.Text == "0")
                {
                    txtrefrescoextra.Text = "00";
                }
                    //pasamos a cargarlos valores a la clase para enviarlos al siguiente ContentPage HorariosPage por medio de BindingContext
                    Models.pelicula classdata = new Models.pelicula
                {
                    IdCine = this.txtidcine.Text,
                    IdPelicula = this.txtidpeli.Text,
                    IdHorario = this.txtidhorario.Text,
                    IdCombo = "1",
                    RefrescoExtra = this.txtrefrescoextra.Text,
                    ContButaca = this.txtcontbutaca.Text,
                    asientosSelected = this.txtasientosSelected.Text,
                    JsonButaca = txtjsonbutaca.Text
                };
                //Creamos una variable page para referenciar a HorariosPage
                var page = new Views.CardPage();
                //Mediante BindingContext enviamos la clase classdata hacia a HorariosPage mediante la variable page
                page.BindingContext = classdata;
                //Por ultimo enviamos la variable Page referenciado a HorariosPage con los datos de la clase mediante un Navigation.PushAsync
                await Navigation.PushAsync(page);
            }
        }

        private async void StackCombo2_Tapped(object sender, EventArgs e)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await DisplayAlert("Sin Internet", "Por favor active su conexion a internet", "Ok");
                return;
            }
            else
            {
                if (txtrefrescoextra.Text == "" || txtrefrescoextra.Text == "0")
                {
                    txtrefrescoextra.Text = "00";
                }
                //pasamos a cargarlos valores a la clase para enviarlos al siguiente ContentPage HorariosPage por medio de BindingContext
                Models.pelicula classdata = new Models.pelicula
                {
                    IdCine = this.txtidcine.Text,
                    IdPelicula = this.txtidpeli.Text,
                    IdHorario = this.txtidhorario.Text,
                    IdCombo = "2",
                    RefrescoExtra = this.txtrefrescoextra.Text,
                    ContButaca = this.txtcontbutaca.Text,
                    asientosSelected = this.txtasientosSelected.Text,
                    JsonButaca = txtjsonbutaca.Text
                };
                //Creamos una variable page para referenciar a HorariosPage
                var page = new Views.CardPage();
                //Mediante BindingContext enviamos la clase classdata hacia a HorariosPage mediante la variable page
                page.BindingContext = classdata;
                //Por ultimo enviamos la variable Page referenciado a HorariosPage con los datos de la clase mediante un Navigation.PushAsync
                await Navigation.PushAsync(page);
            }
        }

        private async void StackCombo3_Tapped(object sender, EventArgs e)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await DisplayAlert("Sin Internet", "Por favor active su conexion a internet", "Ok");
                return;
            }
            else
            {
                if (txtrefrescoextra.Text == "" || txtrefrescoextra.Text == "0")
                {
                    txtrefrescoextra.Text = "00";
                }
                //pasamos a cargarlos valores a la clase para enviarlos al siguiente ContentPage HorariosPage por medio de BindingContext
                Models.pelicula classdata = new Models.pelicula
                {
                    IdCine = this.txtidcine.Text,
                    IdPelicula = this.txtidpeli.Text,
                    IdHorario = this.txtidhorario.Text,
                    IdCombo = "3",
                    RefrescoExtra = this.txtrefrescoextra.Text,
                    ContButaca = this.txtcontbutaca.Text,
                    asientosSelected = this.txtasientosSelected.Text,
                    JsonButaca = txtjsonbutaca.Text
                };
                //Creamos una variable page para referenciar a HorariosPage
                var page = new Views.CardPage();
                //Mediante BindingContext enviamos la clase classdata hacia a HorariosPage mediante la variable page
                page.BindingContext = classdata;
                //Por ultimo enviamos la variable Page referenciado a HorariosPage con los datos de la clase mediante un Navigation.PushAsync
                await Navigation.PushAsync(page);
            }
        }

        private async void StackCombo0_Tapped(object sender, EventArgs e)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await DisplayAlert("Sin Internet", "Por favor active su conexion a internet", "Ok");
                return;
            }
            else
            {
                if (txtrefrescoextra.Text == "" || txtrefrescoextra.Text == "0")
                {
                    txtrefrescoextra.Text = "00";
                }
                //pasamos a cargarlos valores a la clase para enviarlos al siguiente ContentPage HorariosPage por medio de BindingContext
                Models.pelicula classdata = new Models.pelicula
                {
                    IdCine = this.txtidcine.Text,
                    IdPelicula = this.txtidpeli.Text,
                    IdHorario = this.txtidhorario.Text,
                    IdCombo = "0",
                    RefrescoExtra = this.txtrefrescoextra.Text,
                    ContButaca = this.txtcontbutaca.Text,
                    asientosSelected = this.txtasientosSelected.Text,
                    JsonButaca = txtjsonbutaca.Text
                };
                //Creamos una variable page para referenciar a HorariosPage
                var page = new Views.CardPage();
                //Mediante BindingContext enviamos la clase classdata hacia a HorariosPage mediante la variable page
                page.BindingContext = classdata;
                //Por ultimo enviamos la variable Page referenciado a HorariosPage con los datos de la clase mediante un Navigation.PushAsync
                await Navigation.PushAsync(page);
            }
        }
    }
}