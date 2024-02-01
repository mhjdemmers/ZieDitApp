using ZieDitApp.Model;
using ZieDitApp.Repositories;

namespace ZieDitApp.View;

public partial class AddActivityPage : ContentPage
{
	public AddActivityPage()
	{
		InitializeComponent();
	}

    public void OnAddButtonClicked(object sender, EventArgs e)
    {
        var activity = new Activity
        {
            Name = NameEntry.Text,
            Description = DescriptionEntry.Text,
            Time = DateTime.Parse(TimeEntry.Text)
        };

        var activityRepository = new ActivityRepository();
        activityRepository.AddActivity(activity);

        // Clear the fields
        NameEntry.Text = string.Empty;
        DescriptionEntry.Text = string.Empty;
        TimeEntry.Text = string.Empty;

        // Go back to the previous page
        Navigation.PopAsync();
    }
}