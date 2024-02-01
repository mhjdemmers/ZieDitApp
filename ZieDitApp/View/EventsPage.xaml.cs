namespace ZieDitApp.View;
using ZieDitApp.Model;  
using ZieDitApp.ViewModel;

public partial class EventsPage : ContentPage
{
	public EventsPage()
	{
		InitializeComponent();
        BindingContext = new EventsViewModel();
    }

    public void OnFrameTapped(object sender, EventArgs e)
    {
        var frame = (Frame)sender;
        var eventItem = (Event)frame.BindingContext;
        Navigation.PushAsync(new EventPage(eventItem));
    }

    public void OnAddEventButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddEventPage());
    }
}