namespace ZieDitApp.View;
using ZieDitApp.ViewModel;

public partial class EventsPage : ContentPage
{
	public EventsPage()
	{
		InitializeComponent();
        BindingContext = new EventsViewModel();
    }
}