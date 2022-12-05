using Newtonsoft.Json;
using SkiaSharp;
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
    public partial class ButacaPage : ContentPage
    {
        Button btn;
        public Models.pelihorario butacadata;
        public Models.Butaca listabutaca;
        public Models.Butaca listabutacas;
        public Models.Butaca Selecciono;
        public int cantasientos = 0;
        
        public ButacaPage(/*Ticket ticket*/)
        {

            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            /*SelectedTicket = ticket;
            Init();
            this.BindingContext = this;*/

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            refresh();

        }
        public async void refresh()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await DisplayAlert("Sin Internet", "Por favor active su conexion a internet", "Ok");
                return;
            }
            else
            {
                await DisplayAlert("Alerta", "Cargando Butacas...", "OK");
                butacadata = new Models.pelihorario
                {
                    idpeli = this.txtidpeli.Text,
                    idhorario = this.txtidhorario.Text
                };
                List<Models.Butaca> listbutacas = await cinepolisproyect.Controllers.ButacasController.GetListButaca();
                ListView lstbtc = new ListView();
                lstbtc.ItemsSource = listbutacas;
                Models.Butaca btc;

                #region
                //                                              Tegus
                if (txtidcine.Text == "Tegucigalpa")
                {
                    if (txtidpeli.Text == "1")
                    {
                        //peli 1
                        if (txtidhorario.Text == "1")
                        {
                            //horario 1
                            btc = listbutacas[0];
                        }
                        else if (txtidhorario.Text == "2")
                        {
                            //horario 2
                            btc = listbutacas[1];
                        }
                        else
                        {
                            //horario 3
                            btc = listbutacas[2];
                        }
                    }
                    else if (txtidpeli.Text == "2")
                    {
                        //peli 2
                        if (txtidhorario.Text == "1")
                        {
                            //horario 1
                            btc = listbutacas[3];
                        }
                        else if (txtidhorario.Text == "2")
                        {
                            //horario 2
                            btc = listbutacas[4];
                        }
                        else
                        {
                            //horario 3
                            btc = listbutacas[5];
                        }
                    }
                    else
                    {
                        //peli 3
                        if (txtidhorario.Text == "1")
                        {
                            //horario 1
                            btc = listbutacas[6];
                        }
                        else if (txtidhorario.Text == "2")
                        {
                            //horario 2
                            btc = listbutacas[7];
                        }
                        else
                        {
                            //horario 3
                            btc = listbutacas[8];
                        }
                    }
                }
                //                                              SPS
                else
                {
                    if (txtidpeli.Text == "1")
                    {
                        //peli 1
                        if (txtidhorario.Text == "1")
                        {
                            //horario 1
                            btc = listbutacas[9];
                        }
                        else if (txtidhorario.Text == "2")
                        {
                            //horario 2
                            btc = listbutacas[10];
                        }
                        else
                        {
                            //horario 3
                            btc = listbutacas[11];
                        }
                    }
                    else if (txtidpeli.Text == "2")
                    {
                        //peli 2
                        if (txtidhorario.Text == "1")
                        {
                            //horario 1
                            btc = listbutacas[12];
                        }
                        else if (txtidhorario.Text == "2")
                        {
                            //horario 2
                            btc = listbutacas[13];
                        }
                        else
                        {
                            //horario 3
                            btc = listbutacas[14];
                        }
                    }
                    else
                    {
                        //peli 3
                        if (txtidhorario.Text == "1")
                        {
                            //horario 1
                            btc = listbutacas[15];
                        }
                        else if (txtidhorario.Text == "2")
                        {
                            //horario 2
                            btc = listbutacas[16];
                        }
                        else
                        {
                            //horario 3
                            btc = listbutacas[17];
                        }
                    }
                }
                #endregion
                listabutaca = new Models.Butaca
                {
                    idbutaca = btc.idbutaca,
                    a1 = btc.a1,
                    a2 = btc.a2,
                    a3 = btc.a3,
                    a4 = btc.a4,
                    a5 = btc.a5,
                    a6 = btc.a6,
                    a7 = btc.a7,
                    b1 = btc.b1,
                    b2 = btc.b2,
                    b3 = btc.b3,
                    b4 = btc.b4,
                    b5 = btc.b5,
                    b6 = btc.b6,
                    b7 = btc.b7,
                    c1 = btc.c1,
                    c2 = btc.c2,
                    c3 = btc.c3,
                    c4 = btc.c4,
                    c5 = btc.c5,
                    c6 = btc.c6,
                    c7 = btc.c7,
                    d1 = btc.d1,
                    d2 = btc.d2,
                    d3 = btc.d3,
                    d4 = btc.d4,
                    d5 = btc.d5,
                    d6 = btc.d6,
                    d7 = btc.d7,
                    e1 = btc.e1,
                    e2 = btc.e2,
                    e3 = btc.e3,
                    e4 = btc.e4,
                    e5 = btc.e5,
                    e6 = btc.e6,
                    e7 = btc.e7,
                    f1 = btc.f1,
                    f2 = btc.f2,
                    f3 = btc.f3,
                    f4 = btc.f4,
                    f5 = btc.f5,
                };

                listabutacas = new Models.Butaca
                {
                    a1 = listabutaca.a1,
                    a2 = listabutaca.a2,
                    a3 = listabutaca.a3,
                    a4 = listabutaca.a4,
                    a5 = listabutaca.a5,
                    a6 = listabutaca.a6,
                    a7 = listabutaca.a7,
                    b1 = listabutaca.b1,
                    b2 = listabutaca.b2,
                    b3 = listabutaca.b3,
                    b4 = listabutaca.b4,
                    b5 = listabutaca.b5,
                    b6 = listabutaca.b6,
                    b7 = listabutaca.b7,
                    c1 = listabutaca.c1,
                    c2 = listabutaca.c2,
                    c3 = listabutaca.c3,
                    c4 = listabutaca.c4,
                    c5 = listabutaca.c5,
                    c6 = listabutaca.c6,
                    c7 = listabutaca.c7,
                    d1 = listabutaca.d1,
                    d2 = listabutaca.d2,
                    d3 = listabutaca.d3,
                    d4 = listabutaca.d4,
                    d5 = listabutaca.d5,
                    d6 = listabutaca.d6,
                    d7 = listabutaca.d7,
                    e1 = listabutaca.e1,
                    e2 = listabutaca.e2,
                    e3 = listabutaca.e3,
                    e4 = listabutaca.e4,
                    e5 = listabutaca.e5,
                    e6 = listabutaca.e6,
                    e7 = listabutaca.e7,
                    f1 = listabutaca.f1,
                    f2 = listabutaca.f2,
                    f3 = listabutaca.f3,
                    f4 = listabutaca.f4,
                    f5 = listabutaca.f5,
                };

                Selecciono = new Models.Butaca
                {
                    a1 = "",
                    a2 = "",
                    a3 = "",
                    a4 = "",
                    a5 = "",
                    a6 = "",
                    a7 = "",
                    b1 = "",
                    b2 = "",
                    b3 = "",
                    b4 = "",
                    b5 = "",
                    b6 = "",
                    b7 = "",
                    c1 = "",
                    c2 = "",
                    c3 = "",
                    c4 = "",
                    c5 = "",
                    c6 = "",
                    c7 = "",
                    d1 = "",
                    d2 = "",
                    d3 = "",
                    d4 = "",
                    d5 = "",
                    d6 = "",
                    d7 = "",
                    e1 = "",
                    e2 = "",
                    e3 = "",
                    e4 = "",
                    e5 = "",
                    e6 = "",
                    e7 = "",
                    f1 = "",
                    f2 = "",
                    f3 = "",
                    f4 = "",
                    f5 = "",
                };

                this.txtidbutaca.Text = btc.idbutaca;

                #region Fila A
                if (listabutaca.a1 == "1")
                    this.seat1.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat1.BackgroundColor = Color.Transparent;

                if (listabutaca.a2 == "1")
                    this.seat2.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat2.BackgroundColor = Color.Transparent;

                if (listabutaca.a3 == "1")
                    this.seat3.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat3.BackgroundColor = Color.Transparent;

                if (listabutaca.a4 == "1")
                    this.seat4.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat4.BackgroundColor = Color.Transparent;

                if (listabutaca.a5 == "1")
                    this.seat5.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat5.BackgroundColor = Color.Transparent;

                if (listabutaca.a6 == "1")
                    this.seat6.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat6.BackgroundColor = Color.Transparent;

                if (listabutaca.a7 == "1")
                    this.seat7.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat7.BackgroundColor = Color.Transparent;
                #endregion
                #region Fila B
                if (listabutaca.b1 == "1")
                    this.seat8.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat8.BackgroundColor = Color.Transparent;

                if (listabutaca.b2 == "1")
                    this.seat9.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat9.BackgroundColor = Color.Transparent;

                if (listabutaca.b3 == "1")
                    this.seat10.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat10.BackgroundColor = Color.Transparent;

                if (listabutaca.b4 == "1")
                    this.seat11.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat11.BackgroundColor = Color.Transparent;

                if (listabutaca.b5 == "1")
                    this.seat12.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat12.BackgroundColor = Color.Transparent;

                if (listabutaca.b6 == "1")
                    this.seat13.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat13.BackgroundColor = Color.Transparent;

                if (listabutaca.b7 == "1")
                    this.seat14.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat14.BackgroundColor = Color.Transparent;
                #endregion
                #region Fila C
                if (listabutaca.c1 == "1")
                    this.seat15.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat15.BackgroundColor = Color.Transparent;

                if (listabutaca.c2 == "1")
                    this.seat16.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat16.BackgroundColor = Color.Transparent;

                if (listabutaca.c3 == "1")
                    this.seat17.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat17.BackgroundColor = Color.Transparent;

                if (listabutaca.c4 == "1")
                    this.seat18.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat18.BackgroundColor = Color.Transparent;

                if (listabutaca.c5 == "1")
                    this.seat19.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat19.BackgroundColor = Color.Transparent;

                if (listabutaca.c6 == "1")
                    this.seat20.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat20.BackgroundColor = Color.Transparent;

                if (listabutaca.c7 == "1")
                    this.seat21.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat21.BackgroundColor = Color.Transparent;
                #endregion
                #region Fila D
                if (listabutaca.d1 == "1")
                    this.seat22.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat22.BackgroundColor = Color.Transparent;

                if (listabutaca.d2 == "1")
                    this.seat23.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat23.BackgroundColor = Color.Transparent;

                if (listabutaca.d3 == "1")
                    this.seat24.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat24.BackgroundColor = Color.Transparent;

                if (listabutaca.d4 == "1")
                    this.seat25.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat25.BackgroundColor = Color.Transparent;

                if (listabutaca.d5 == "1")
                    this.seat26.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat26.BackgroundColor = Color.Transparent;

                if (listabutaca.d6 == "1")
                    this.seat27.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat27.BackgroundColor = Color.Transparent;

                if (listabutaca.d7 == "1")
                    this.seat28.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat28.BackgroundColor = Color.Transparent;
                #endregion
                #region Fila E
                if (listabutaca.e1 == "1")
                    this.seat29.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat29.BackgroundColor = Color.Transparent;

                if (listabutaca.e2 == "1")
                    this.seat30.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat30.BackgroundColor = Color.Transparent;

                if (listabutaca.e3 == "1")
                    this.seat31.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat31.BackgroundColor = Color.Transparent;

                if (listabutaca.e4 == "1")
                    this.seat32.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat32.BackgroundColor = Color.Transparent;

                if (listabutaca.e5 == "1")
                    this.seat33.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat33.BackgroundColor = Color.Transparent;

                if (listabutaca.e6 == "1")
                    this.seat34.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat34.BackgroundColor = Color.Transparent;

                if (listabutaca.e7 == "1")
                    this.seat35.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat35.BackgroundColor = Color.Transparent;
                #endregion
                #region Fila F
                if (listabutaca.f1 == "1")
                    this.seat36.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat36.BackgroundColor = Color.Transparent;

                if (listabutaca.f2 == "1")
                    this.seat37.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat37.BackgroundColor = Color.Transparent;

                if (listabutaca.f3 == "1")
                    this.seat38.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat38.BackgroundColor = Color.Transparent;

                if (listabutaca.f4 == "1")
                    this.seat39.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat39.BackgroundColor = Color.Transparent;

                if (listabutaca.f5 == "1")
                    this.seat40.BackgroundColor = Color.FromHex("#FECA30");
                else
                    this.seat40.BackgroundColor = Color.Transparent;
                #endregion
            }
        }

        #region
        private async void btncomprar_Clicked(object sender, EventArgs e)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await DisplayAlert("Sin Internet", "Por favor active su conexion a internet", "Ok");
                return;
            }
            else
            {
                if (cantasientos > 0)
                {
                    String asientosSelected = "";
                    #region guardar_asientos_seleccionados
                    if (Selecciono.a1 == "1")
                    {
                        asientosSelected = asientosSelected + "A1 ";
                    }
                    if (Selecciono.a2 == "1")
                    {
                        asientosSelected = asientosSelected + "A2 ";
                    }
                    if (Selecciono.a3 == "1")
                    {
                        asientosSelected = asientosSelected + "A3 ";
                    }
                    if (Selecciono.a4 == "1")
                    {
                        asientosSelected = asientosSelected + "A4 ";
                    }
                    if (Selecciono.a5 == "1")
                    {
                        asientosSelected = asientosSelected + "A5 ";
                    }
                    if (Selecciono.a6 == "1")
                    {
                        asientosSelected = asientosSelected + "A6 ";
                    }
                    if (Selecciono.a7 == "1")
                    {
                        asientosSelected = asientosSelected + "A7 ";
                    }
                    if (Selecciono.b1 == "1")
                    {
                        asientosSelected = asientosSelected + "B1 ";
                    }
                    if (Selecciono.b2 == "1")
                    {
                        asientosSelected = asientosSelected + "B2 ";
                    }
                    if (Selecciono.b3 == "1")
                    {
                        asientosSelected = asientosSelected + "B3 ";
                    }
                    if (Selecciono.b4 == "1")
                    {
                        asientosSelected = asientosSelected + "B4 ";
                    }
                    if (Selecciono.b5 == "1")
                    {
                        asientosSelected = asientosSelected + "B5 ";
                    }
                    if (Selecciono.b6 == "1")
                    {
                        asientosSelected = asientosSelected + "B6 ";
                    }
                    if (Selecciono.b7 == "1")
                    {
                        asientosSelected = asientosSelected + "B7 ";
                    }
                    if (Selecciono.c1 == "1")
                    {
                        asientosSelected = asientosSelected + "C1 ";
                    }
                    if (Selecciono.c2 == "1")
                    {
                        asientosSelected = asientosSelected + "C2 ";
                    }
                    if (Selecciono.c3 == "1")
                    {
                        asientosSelected = asientosSelected + "C3 ";
                    }
                    if (Selecciono.c4 == "1")
                    {
                        asientosSelected = asientosSelected + "C4 ";
                    }
                    if (Selecciono.c5 == "1")
                    {
                        asientosSelected = asientosSelected + "C5 ";
                    }
                    if (Selecciono.c6 == "1")
                    {
                        asientosSelected = asientosSelected + "C6 ";
                    }
                    if (Selecciono.c7 == "1")
                    {
                        asientosSelected = asientosSelected + "C7 ";
                    }
                    if (Selecciono.d1 == "1")
                    {
                        asientosSelected = asientosSelected + "D1 ";
                    }
                    if (Selecciono.d2 == "1")
                    {
                        asientosSelected = asientosSelected + "D2 ";
                    }
                    if (Selecciono.d3 == "1")
                    {
                        asientosSelected = asientosSelected + "D3 ";
                    }
                    if (Selecciono.d4 == "1")
                    {
                        asientosSelected = asientosSelected + "D4 ";
                    }
                    if (Selecciono.d5 == "1")
                    {
                        asientosSelected = asientosSelected + "D5 ";
                    }
                    if (Selecciono.d6 == "1")
                    {
                        asientosSelected = asientosSelected + "D6 ";
                    }
                    if (Selecciono.d7 == "1")
                    {
                        asientosSelected = asientosSelected + "D7 ";
                    }
                    if (Selecciono.e1 == "1")
                    {
                        asientosSelected = asientosSelected + "E1 ";
                    }
                    if (Selecciono.e2 == "1")
                    {
                        asientosSelected = asientosSelected + "E2 ";
                    }
                    if (Selecciono.e3 == "1")
                    {
                        asientosSelected = asientosSelected + "E3 ";
                    }
                    if (Selecciono.e4 == "1")
                    {
                        asientosSelected = asientosSelected + "E4 ";
                    }
                    if (Selecciono.e5 == "1")
                    {
                        asientosSelected = asientosSelected + "E5 ";
                    }
                    if (Selecciono.e6 == "1")
                    {
                        asientosSelected = asientosSelected + "E6 ";
                    }
                    if (Selecciono.e7 == "1")
                    {
                        asientosSelected = asientosSelected + "E7 ";
                    }
                    if (Selecciono.f1 == "1")
                    {
                        asientosSelected = asientosSelected + "F1 ";
                    }
                    if (Selecciono.f2 == "1")
                    {
                        asientosSelected = asientosSelected + "F2 ";
                    }
                    if (Selecciono.f3 == "1")
                    {
                        asientosSelected = asientosSelected + "F3 ";
                    }
                    if (Selecciono.f4 == "1")
                    {
                        asientosSelected = asientosSelected + "F4 ";
                    }
                    if (Selecciono.f5 == "1")
                    {
                        asientosSelected = asientosSelected + "F5 ";
                    }
                    #endregion
                    var but = new Models.Butaca
                    {
                        idbutaca = this.txtidbutaca.Text,
                        a1 = listabutacas.a1,
                        a2 = listabutacas.a2,
                        a3 = listabutacas.a3,
                        a4 = listabutacas.a4,
                        a5 = listabutacas.a5,
                        a6 = listabutacas.a6,
                        a7 = listabutacas.a7,
                        b1 = listabutacas.b1,
                        b2 = listabutacas.b2,
                        b3 = listabutacas.b3,
                        b4 = listabutacas.b4,
                        b5 = listabutacas.b5,
                        b6 = listabutacas.b6,
                        b7 = listabutacas.b7,
                        c1 = listabutacas.c1,
                        c2 = listabutacas.c2,
                        c3 = listabutacas.c3,
                        c4 = listabutacas.c4,
                        c5 = listabutacas.c5,
                        c6 = listabutacas.c6,
                        c7 = listabutacas.c7,
                        d1 = listabutacas.d1,
                        d2 = listabutacas.d2,
                        d3 = listabutacas.d3,
                        d4 = listabutacas.d4,
                        d5 = listabutacas.d5,
                        d6 = listabutacas.d6,
                        d7 = listabutacas.d7,
                        e1 = listabutacas.e1,
                        e2 = listabutacas.e2,
                        e3 = listabutacas.e3,
                        e4 = listabutacas.e4,
                        e5 = listabutacas.e5,
                        e6 = listabutacas.e6,
                        e7 = listabutacas.e7,
                        f1 = listabutacas.f1,
                        f2 = listabutacas.f2,
                        f3 = listabutacas.f3,
                        f4 = listabutacas.f4,
                        f5 = listabutacas.f5,
                    };
                    String JsonContent2 = JsonConvert.SerializeObject(but);
                    String JsonContent = "{\"butaca\":[" + JsonContent2 + "]}";
                    //await Controllers.ButacasController.UpdateSitio(but);
                    //await DisplayAlert("Logrado", "Actualizado Exitosamente", "Ok");

                    Models.pelicula classdata = new Models.pelicula
                    {
                        IdCine = this.txtidcine.Text,
                        IdPelicula = this.txtidpeli.Text,
                        IdHorario = this.txtidhorario.Text,
                        ContButaca = cantasientos.ToString(),
                        asientosSelected = asientosSelected,
                        JsonButaca = JsonContent
                    };
                    var page = new Views.TiendaPage();
                    page.BindingContext = classdata;
                    await Navigation.PushAsync(page);

                }
                else
                {
                    await DisplayAlert("Alerta", "Seleccione al menos 1 butaca", "OK");
                }
            }
        }

        private void seat1_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.a1 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.a1 = "1";
                    cantasientos += 1;
                    Selecciono.a1 = "1";
                }

                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.a1 = "0";
                }
            }
        }

        private void seat2_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.a2 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.a2 = "1";
                    cantasientos += 1;
                    Selecciono.a2 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.a2 = "0";
                }
            }

        }

        private void seat3_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.a3 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.a3 = "1";
                    cantasientos += 1;
                    Selecciono.a3 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.a3 = "0";
                }
            }
        }

        private void seat4_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.a4 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.a4 = "1";
                    cantasientos += 1;
                    Selecciono.a4 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.a4 = "0";
                }
            }
        }

        private void seat5_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.a5 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.a5 = "1";
                    cantasientos += 1;
                    Selecciono.a5 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.a5 = "0";
                }
            }
        }

        private void seat6_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.a6 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.a6 = "1";
                    cantasientos += 1;
                    Selecciono.a6 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.a6 = "0";
                }
            }

        }

        private void seat7_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.a7 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.a7 = "1";
                    cantasientos += 1;
                    Selecciono.a7 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.a7 = "0";
                }
            }

        }

        private void seat8_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.b1 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.b1 = "1";
                    cantasientos += 1;
                    Selecciono.b1 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.b1 = "0";
                }
            }
        }

        private void seat9_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.b2 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.b2 = "1";
                    cantasientos += 1;
                    Selecciono.b2 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.b2 = "0";
                }
            }
        }

        private void seat10_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.b3 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.b3 = "1";
                    cantasientos += 1;
                    Selecciono.b3 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.b3 = "0";
                }
            }
        }

        private void seat11_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.b4 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.b4 = "1";
                    cantasientos += 1;
                    Selecciono.b4 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.b4 = "0";
                }
            }
        }

        private void seat12_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.b5 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.b5 = "1";
                    cantasientos += 1;
                    Selecciono.b5 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.b5 = "0";
                }
            }
        }

        private void seat13_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.b6 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.b6 = "1";
                    cantasientos += 1;
                    Selecciono.b6 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.b6 = "0";
                }
            }
        }

        private void seat14_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.b7 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.b7 = "1";
                    cantasientos += 1;
                    Selecciono.b7 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.b7 = "0";
                }
            }
        }

        private void seat15_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.c1 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.c1 = "1";
                    cantasientos += 1;
                    Selecciono.c1 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.c1 = "0";
                }
            }
        }

        private void seat16_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.c2 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.c2 = "1";
                    cantasientos += 1;
                    Selecciono.c2 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.c2 = "0";
                }
            }
        }

        private void seat17_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.c3 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.c3 = "1";
                    cantasientos += 1;
                    Selecciono.c3 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.c3 = "0";
                }
            }
        }

        private void seat18_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.c4 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.c4 = "1";
                    cantasientos += 1;
                    Selecciono.c4 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.c4 = "0";
                }
            }
        }

        private void seat19_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.c5 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.c5 = "1";
                    cantasientos += 1;
                    Selecciono.c5 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.c5 = "0";
                }
            }
        }

        private void seat20_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.c6 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.c6 = "1";
                    cantasientos += 1;
                    Selecciono.c6 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.c6 = "0";
                }
            }
        }

        private void seat21_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.c7 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.c7 = "1";
                    cantasientos += 1;
                    Selecciono.c7 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.c7 = "0";
                }
            }
        }

        private void seat22_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.d1 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.d1 = "1";
                    cantasientos += 1;
                    Selecciono.d1 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.d1 = "0";
                }
            }
        }

        private void seat23_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.d2 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.d2 = "1";
                    cantasientos += 1;
                    Selecciono.d2 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.d2 = "0";
                }
            }
        }

        private void seat24_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.d3 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.d3 = "1";
                    cantasientos += 1;
                    Selecciono.d3 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.d3 = "0";
                }
            }
        }

        private void seat25_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.d4 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.d4 = "1";
                    cantasientos += 1;
                    Selecciono.d4 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.d4 = "0";
                }
            }
        }

        private void seat26_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.d5 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.d5 = "1";
                    cantasientos += 1;
                    Selecciono.d5 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.d5 = "0";
                }
            }
        }

        private void seat27_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.d6 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.d6 = "1";
                    cantasientos += 1;
                    Selecciono.d6 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.d6 = "0";
                }
            }
        }

        private void seat28_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.d7 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.d7 = "1";
                    cantasientos += 1;
                    Selecciono.d7 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.d7 = "0";
                }
            }
        }

        private void seat29_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.e1 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.e1 = "1";
                    cantasientos += 1;
                    Selecciono.e1 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.e1 = "0";
                }
            }
        }

        private void seat30_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.e2 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.e2 = "1";
                    cantasientos += 1;
                    Selecciono.e2 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.e2 = "0";
                }
            }
        }

        private void seat31_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.e3 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.e3 = "1";
                    cantasientos += 1;
                    Selecciono.e3 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.e3 = "0";
                }
            }
        }

        private void seat32_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.e4 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.e4 = "1";
                    cantasientos += 1;
                    Selecciono.e4 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.e4 = "0";
                }
            }
        }

        private void seat33_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.e5 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.e5 = "1";
                    cantasientos += 1;
                    Selecciono.e5 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.e5 = "0";
                }
            }
        }

        private void seat34_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.e6 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.e6 = "1";
                    cantasientos += 1;
                    Selecciono.e6 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.e6 = "0";
                }
            }
        }

        private void seat35_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.e7 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.e7 = "1";
                    cantasientos += 1;
                    Selecciono.e7 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.e7 = "0";
                }
            }
        }

        private void seat36_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.f1 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.f1 = "1";
                    cantasientos += 1;
                    Selecciono.f1 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.f1 = "0";
                }
            }
        }

        private void seat37_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.f2 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.f2 = "1";
                    cantasientos += 1;
                    Selecciono.f2 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.f2 = "0";
                }
            }
        }

        private void seat38_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.f3 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.f3 = "1";
                    cantasientos += 1;
                    Selecciono.f3 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.f3 = "0";
                }
            }
        }

        private void seat39_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.f4 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.f4 = "1";
                    cantasientos += 1;
                    Selecciono.f4 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.f4 = "0";
                }
            }
        }

        private void seat40_Clicked(object sender, EventArgs e)
        {
            if (listabutaca.f5 == "1")
                DisplayAlert("Advertencia", "El asiento ya esta ocupado", "Ok");
            else
            {
                btn = (Button)sender;
                if (btn.BackgroundColor.Equals(Color.Transparent))
                {
                    btn.BackgroundColor = Color.FromHex("#002069");
                    listabutacas.f5 = "1";
                    cantasientos += 1;
                    Selecciono.f5 = "1";
                }
                else
                {
                    btn.BackgroundColor = Color.Transparent;
                    cantasientos -= 1;
                    Selecciono.f5 = "0";
                }
            }
        }
    }
    #endregion //botones
}