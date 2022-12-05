using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace cinepolisproyect.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicketPage : ContentPage
    {
        //Declaracion de variable qr
        ZXingBarcodeImageView qr;
        public int show = 1;

        public TicketPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ValidarInternet();

        }
        public async void ValidarInternet()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await DisplayAlert("Sin Internet", "Se ha perdido la conexion a internet", "Ok");
                return;
            }
            else
            {
                generarQR();
            }
        }
        public  void generarQR()
        {
            if (show == 1)
            {

                qr = new ZXingBarcodeImageView
                {
                    //Propiedad para generar codigo QR
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };

                String IdCine = txtidcine.Text;
                String IdPelicula = txtidpeli.Text;
                String IdHorario = txtidhorario.Text;
                String IdCombo = txtIdCombo.Text;
                String RefrescoExtra = txtRefrescoExtra.Text;
                String ContButaca = txtcontbutaca.Text;
                String asientosSelected = txtasientosSelected.Text;

                String Url = "https://cinepolishn.000webhostapp.com/Cinepolis/Ticket.php/?IdCine=" + IdCine + "&IdPelicula=" + IdPelicula + "&IdHorario=" + IdHorario + "&asientosSelected=" + asientosSelected + "&IdCombo=" + IdCombo + "&RefrescoExtra=" + RefrescoExtra;

                //generar tipo de codigo que sera el QR_CODE 
                qr.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
                //propiedad de ancho del QR
                qr.BarcodeOptions.Width = 300;
                //propiedad de alto del QR
                qr.BarcodeOptions.Height = 300;
                //valor que va recibir el codigo QR para direccionar
                qr.BarcodeValue = Url;
                //colocamos el nombre al StackLayout y le damos el valor
                //qr del objeto creado que es
                stkQR.Children.Add(qr);

                if (IdPelicula == "1")
                {
                    imgpeli.Source = "cartelera1.jpg";
                }
                else if (IdPelicula == "2")
                {
                    imgpeli.Source = "cartelera2.jpg";
                }
                else
                {
                    imgpeli.Source = "cartelera3.jpg";
                }

                show = 0;
            }
        }

        private void btn_home_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new DashboardPage());
        }
    }
}