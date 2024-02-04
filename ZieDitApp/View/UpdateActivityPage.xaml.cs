using ZieDitApp.Model;
using ZieDitApp.Repositories;
using ZieDitApp.ViewModel;

namespace ZieDitApp.View;

public partial class UpdateActivityPage : ContentPage
{
	private Activity _activity;
	public UpdateActivityPage(Activity activity)
	{
		_activity = activity;
		InitializeComponent();
		BindingContext = new UpdateActivityViewModel(activity);
	}

    public void OnEditButtonClicked(object sender, EventArgs e)
    {
        _activity.Name = NameEntry.Text;
        _activity.Description = DescriptionEntry.Text;
        _activity.Time = TimePicker.Time;

        var activityRepository = new ActivityRepository();
        activityRepository.AddActivity(_activity);
        Navigation.PopAsync();
    }
}