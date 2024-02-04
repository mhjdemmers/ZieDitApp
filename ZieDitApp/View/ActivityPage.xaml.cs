using ZieDitApp.Model;
using ZieDitApp.Repositories;
using ZieDitApp.ViewModel;
namespace ZieDitApp.View;

public partial class ActivityPage : ContentPage
{
    private Activity _activity;
    private ActivityRepository _activityRepository;
    private ActivityUserRepository _activityUserRepository;

    public ActivityPage(Activity activity)
    {
        InitializeComponent();
        _activity = activity;
        _activityUserRepository = new ActivityUserRepository();
        _activityRepository = new ActivityRepository();
        BindingContext = new ActivityViewModel(activity); 
    }

    private void OnDeleteActivityButtonClicked(object sender, EventArgs e)
    {
        _activityRepository.DeleteActivity(_activity);
        Navigation.PopAsync();
    }

    private void OnUpdateActivityButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new UpdateActivityPage(_activity));
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

    private void OnUitschrijvenButtonClicked(object sender, EventArgs e)
    {
        int userId = App.CurrentUser.Id;
        int activityId = _activity.Id;
        ActivityUser activityUser = _activityUserRepository.CheckRegisteredUser(userId, activityId);

        if (activityUser != null)
        {
            _activityUserRepository.DeleteActivityUser(activityUser);

            //// Update the Registered property
            //var viewModel = BindingContext as ActivityViewModel;
            //if (viewModel != null)
            //{
            //    viewModel.Registered = viewModel.IsRegistered(_activity);
            //}
        }
    }
}


