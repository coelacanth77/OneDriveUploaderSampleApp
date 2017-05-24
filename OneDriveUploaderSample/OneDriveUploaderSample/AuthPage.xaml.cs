using OneDriveUploaderSample.Model;
using OneDriveUploaderSample.Model.OneDrive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OneDriveUploaderSample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthPage : ContentPage
    {
        private readonly OneDriveService _service;

        public AuthPage()
        {
            InitializeComponent();

            _service = ((App)Application.Current).ServiceInstance;

            // 認証ページを表示
            this.webView.Source = _service.GetStartUri();

            webView.Navigated += WebView_Navigated;

        }

        private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            if (_service.CheckRedirectUrl(e.Url))
            {
                _service.ContinueGetTokens(new Uri(e.Url));
            }
        }
    }
}
