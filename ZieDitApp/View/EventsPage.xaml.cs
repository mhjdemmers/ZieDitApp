namespace ZieDitApp.View;
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
        Navigation.PushAsync(new EventPage());
    }

    public void OnAddEventButtonClicked(object sender, EventArgs e)
    {
       
    }
}