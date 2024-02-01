using System.Diagnostics;
using ZieDitApp.Model;
using ZieDitApp.Repositories;

namespace ZieDitApp.View;

public partial class AddEventPage : ContentPage
{
	public AddEventPage()
	{
		InitializeComponent();
	}

    public void OnAddButtonClicked(object sender, EventArgs e)
    {
        var eventItem = new Event
        {
            Name = NameEntry.Text,
            Location = LocationEntry.Text,
            Date = DateTime.Parse(DateEntry.Text)
        };

        var eventRepository = new EventRepository();
        eventRepository.AddEvent(eventItem);

        // Clear the fields
        NameEntry.Text = string.Empty;
        LocationEntry.Text = string.Empty;
        DateEntry.Text = string.Empty;

        // Go back to the previous page
        Navigation.PopAsync();
    }

}