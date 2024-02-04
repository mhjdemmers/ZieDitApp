using ZieDitApp.Model;
using ZieDitApp.Repositories;

namespace ZieDitApp.View;

public partial class AddActivityPage : ContentPage
{
    private Event _event ;
	public AddActivityPage(Event eventItem)
	{
        _event = eventItem;
		InitializeComponent();
	}

    public void OnAddButtonClicked(object sender, EventArgs e)
    {
        var activity = new Activity
        {
            Name = NameEntry.Text,
            Description = DescriptionEntry.Text,
            Time = TimePicker.Time,
            EventId = _event.Id,
            PresenterId = App.CurrentUser.Id
            //Time = DateTime.Parse(TimeEntry.Text)
        };

        var activityRepository = new ActivityRepository();
        activityRepository.AddActivity(activity);

        // Clear the fields
        NameEntry.Text = string.Empty;
        DescriptionEntry.Text = string.Empty;

        // Go back to the previous page
        Navigation.PopAsync();
    }
}