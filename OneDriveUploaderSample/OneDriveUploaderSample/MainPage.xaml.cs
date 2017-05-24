using OneDriveUploaderSample.Model.OneDrive;
using System;
using Xamarin.Forms;

namespace OneDriveUploaderSample
{
    public partial class MainPage : ContentPage
    {
        private readonly OneDriveService _service = ((App)Application.Current).ServiceInstance;

        public MainPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void authButton_Clicked(object sender, EventArgs e)
        {
            if (!_service.CheckAuthenticate(
                async () =>
                {
                    await DisplayAlert("認証結果", "認証に成功しました", "OK");
                    await Navigation.PushAsync(new UploadPage());
                },
                async () =>
                {
                    await DisplayAlert("認証結果", "認証に失敗しました", "OK");
                    await Navigation.PopAsync();
                }))
            {
                Navigation.PushAsync(new AuthPage());
            }
        }
    }
}
