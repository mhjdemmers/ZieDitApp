using ZieDitApp.ViewModel;

namespace ZieDitApp.View;

public partial class ScanPage : ContentPage
{
	public ScanPage()
	{
		InitializeComponent();
    }
    private void cameraView_CamerasLoaded(object sender, EventArgs e)
    {
        cameraView.Camera = cameraView.Cameras.First();

        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await cameraView.StopCameraAsync();
            await cameraView.StartCameraAsync();
        });
    }

    private void cameraView_BarcodeDetected(object sender, 
        Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            barcodeResult.Text = $"{args.Result[0].BarcodeFormat} : {args.Result[0].Text}";
        });
    }

    //private void Button_Clicked(object sender, EventArgs e)
    //{
    //    myImage.Source = cameraView.GetSnapShot();
    //}
}