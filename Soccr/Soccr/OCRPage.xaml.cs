using Soccr.Services;

namespace Soccr;

public partial class OCRPage : ContentPage
{
    public OCRPage()
    {
        InitializeComponent();
    }

    private void CameraView_Loaded(object sender, EventArgs e)
    {
        if (cameraView.Cameras.Count > 0)
        {
            cameraView.Camera = cameraView.Cameras.First();

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await cameraView.StopCameraAsync();
                await cameraView.StartCameraAsync();
            });
        }
    }

    private void FlashButton_Clicked(object sender, EventArgs e)
    {
        cameraView.TorchEnabled = !cameraView.TorchEnabled;

        if (cameraView.TorchEnabled)
        {
            flashButton.BackgroundColor = Color.FromRgb(60, 60, 60);
        }
        else
        {
            flashButton.BackgroundColor = Color.FromRgb(48, 48, 48);
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        cameraView.Opacity = 0.8;

        MainThread.BeginInvokeOnMainThread(async () =>
        {
            var stream = await cameraView.TakePhotoAsync(Camera.MAUI.ImageFormat.JPEG);
            cameraView.TorchEnabled = false;
            await Navigation.PushAsync(new DetailsPage(stream));
        });
    }
}