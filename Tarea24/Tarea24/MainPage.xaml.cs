using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea24.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tarea24
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            new NavigationPage(new PageVideoRecord());
        }

        private async void btnAddVideo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageVideoRecord());
        }

        private async void btnViewVideos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageVideoList());
        }

        private void btnPlay_Clicked(object sender, EventArgs e)
        {

        }
    }
}