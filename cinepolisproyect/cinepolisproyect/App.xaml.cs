using cinepolisproyect.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cinepolisproyect
{
   
    public partial class App : Application
    {
        Authentication authentication;
        public App()
        {
            InitializeComponent();
            authentication = DependencyService.Get<Authentication>();

            if (authentication.IsSignIn())
            {
                MainPage = new NavigationPage(new DashboardPage());
            }
            else
            {
                MainPage = new NavigationPage(new StartPage());

            }
           
        }

        protected override void OnStart()
        {
           
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
