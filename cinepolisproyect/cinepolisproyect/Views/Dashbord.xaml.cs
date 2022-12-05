using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cinepolisproyect.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashbord : ContentPage
    {
        public Dashbord()
        {
            InitializeComponent();
            ToolbarItem item = new ToolbarItem
            {
                Text = "Example Item",
                IconImageSource = ImageSource.FromFile("LogoCinepolis.png"),
                Order = ToolbarItemOrder.Primary,
                Priority = 0
            };

            // "this" refers to a Page object
            this.ToolbarItems.Add(item);
        }
    }
}