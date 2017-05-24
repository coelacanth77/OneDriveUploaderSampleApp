using OneDriveUploaderSample.Model.OneDrive;
using OneDriveUploaderSample.Model.OneDrive.Response;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OneDriveUploaderSample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UploadPage : ContentPage
    {
        private readonly OneDriveService _service = ((App)Application.Current).ServiceInstance;

        private MediaFile _photo;

        private ItemInfoResponse _response;

        public UploadPage()
        {
            InitializeComponent();
        }

        private async void selectImageButton_Clicked(object sender, EventArgs e)
        {
            if (CrossMedia.Current.IsPickPhotoSupported)
            {
                this._photo = await CrossMedia.Current.PickPhotoAsync();
                imageControll.Source = ImageSource.FromStream(() => this._photo.GetStream());

                this.uploadImageButton.IsVisible = true;

                Debug.WriteLine(_photo.AlbumPath);
                Debug.WriteLine(_photo.Path);
            }
            else
            {
                await DisplayAlert("エラー", "画像ファイルにアクセスできませんでした", "OK");
            }
        }

        private async void uploadImageButton_Clicked(object sender, EventArgs e)
        {
            var folder = await _service.GetAppRoot();

            using (var stream = this._photo.GetStream())
            {
                this._response = await _service.SaveFile(folder.Id, System.IO.Path.GetFileName(this._photo.Path), stream);

                Debug.WriteLine(this._response.WebUrl);

                await DisplayAlert("アップロード", "ファイルを以下のURLにアップロードしました。" + this._response.WebUrl, "OK");

                this.result.Text = this._response.WebUrl;
            }
        }
    }
}
