using ZieDitApp.Model;
using ZieDitApp.Repositories;
using ZieDitApp.ViewModel;
namespace ZieDitApp.View;

public partial class ActivityPage : ContentPage
{
    private Activity _activity;
    private ActivityUserRepository _activityUserRepository;

    public ActivityPage(Activity activity)
    {
        InitializeComponent();
        BindingContext = activity;
        _activity = activity;
        _activityUserRepository = new ActivityUserRepository();
    }

    private void OnInschrijvenButtonClicked(object sender, EventArgs e)
    {
        ActivityUser activityUser = new ActivityUser()
        {
            Activity = _activity.Id,
            User = App.CurrentUser.Id
        };
        _activityUserRepository.AddActivityUser(activityUser);
    }
}
