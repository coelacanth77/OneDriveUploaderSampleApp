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

        // ここに文字列でアプリケーション IDを指定してください。例:"0000000desak0ui9"
        private const string _ONEDRIVE_APP_ID = "";

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
