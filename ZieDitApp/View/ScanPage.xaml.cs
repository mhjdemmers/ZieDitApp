using ZieDitApp.Model;
using ZieDitApp.Repositories;
using ZieDitApp.ViewModel;

namespace ZieDitApp.View;

public partial class ScanPage : ContentPage
{
    private EventUserRepository _eventUserRepository;
    private EventRepository _eventRepository;
    private UserRepository _userRepository;
	public ScanPage()
	{
        _eventUserRepository = new EventUserRepository();
        _eventRepository = new EventRepository();
        _userRepository = new UserRepository();
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
            Tuple<Event, User> eventUserTuple = CheckCode(Guid.Parse(args.Result[0].Text));
            string user = eventUserTuple.Item2.Name;
            string eventName = eventUserTuple.Item1.Name;
            barcodeResult.Text = $"Valid QR for User {user} to event {eventName}";
        });
    }

    private Tuple<Event, User> CheckCode(Guid code)
    {
        EventUser eventUser = _eventUserRepository.CheckCode(code);
        Event eventItem = _eventRepository.GetEventById(eventUser.Event);
        User user = _userRepository.GetUserById(eventUser.User);

        return new Tuple<Event, User>(eventItem, user);
    }
}