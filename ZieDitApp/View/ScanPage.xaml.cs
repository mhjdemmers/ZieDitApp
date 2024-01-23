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

    private void Button_Clicked(object sender, EventArgs e)
    {
        myImage.Source = cameraView.GetSnapShot();
    }
}