using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Tarea24.Views;
using Xam.Forms.VideoPlayer;
using Xamarin.Essentials;
using System.IO;

namespace Tarea24.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageVideoRecord : ContentPage
    {
        public string PhotoPath;
        

        public PageVideoRecord()
        {
            InitializeComponent();
        }

        private void btnRecordVideo_Clicked(object sender, EventArgs e)
        {
            RecorderVideoRealTime();
        }

        private void btnSaveVideo_Clicked(object sender, EventArgs e)
        {
            SaveVideoRecord();
        }

        private void videoPlayer_PlayCompletion(object sender, EventArgs e)
        {
        }

        public async void RecorderVideoRealTime()
        {
            try
            {
                var photo = await MediaPicker.CaptureVideoAsync();
                await LoadPhotoAsync(photo);
                Console.WriteLine($"CapturePhotoAsync COMPLETED: {PhotoPath}");
                //await DisplayAlert("as", PhotoPath, "ok");

                UriVideoSource uriVideoSurce = new UriVideoSource()
                {
                    Uri = PhotoPath
                };

                videoPlayer.Source = uriVideoSurce;
            }
            catch (FeatureNotSupportedException)
            {
            }
            catch (PermissionException)
            {
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
        }

        async Task LoadPhotoAsync(FileResult photo)
        {
            if (photo == null)
            {
                PhotoPath = null;
                return;
            }

            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);
            PhotoPath = newFile;
        }

        public async void SaveVideoRecord()
        {
            var videos = new Models.VideoModel
            {
                VideoUri = PhotoPath,
                VideoDescripcion = txtDescripcion.Text
            };

            var resultado = await App.BaseDatosObject.SaveVideoRecord(videos);

            if (resultado == 1)
            {
                await DisplayAlert("", "Video Guardado.", "ok");
                txtDescripcion.Text = "";
                videoPlayer.Source = null;
            }
            else
            {
                await DisplayAlert("Error", "No se pudo Guardar", "ok");
            }
        }


    }
}