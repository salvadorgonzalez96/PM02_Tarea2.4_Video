using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Tarea24.Models;
using Tarea24.Views;

namespace Tarea24.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageVideoList : ContentPage
    {
        public PageVideoList()
        {
            InitializeComponent();
            LoadVideoList();
        }

        private async void listViewVideos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            listViewVideos.SelectedItem = null;
            try
            {
                Models.VideoModel item = (Models.VideoModel)e.Item;
                var newpage = new PageVideoPlay(item);
                newpage.BindingContext = item;
                await Navigation.PushAsync(newpage);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "Ok");
            }
        }

        private void listViewVideos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
        }

        private void SwipeItem_Invoked(object sender, EventArgs e)
        {
        }

        public async void LoadVideoList()
        {
            var lista = await App.BaseDatosObject.GetVideoList();
            listViewVideos.ItemsSource = lista;
        }
    }
}