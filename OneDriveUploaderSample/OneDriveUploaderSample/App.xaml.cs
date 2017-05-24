using OneDriveUploaderSample.Model.OneDrive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace OneDriveUploaderSample
{
    public partial class App : Application
    {
        public OneDriveService ServiceInstance
        {
            get;
            private set;
        }

        private const string _ONEDRIVE_APP_ID = "00000000401D9638";

        public App()
        {
            InitializeComponent();

            ServiceInstance = new OneDriveService(_ONEDRIVE_APP_ID);

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
