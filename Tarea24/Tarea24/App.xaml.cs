using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Tarea24.Controller;
using Tarea24.Views;

namespace Tarea24
{
    public partial class App : Application
    {

        static VideoDBController BaseDatos;

        public static VideoDBController BaseDatosObject
        {
            get
            {
                if (BaseDatos == null)
                {
                    BaseDatos = new VideoDBController(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "VideosDBApp.db3"));
                }
                return BaseDatos;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

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
