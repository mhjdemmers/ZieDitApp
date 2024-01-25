namespace ZieDitApp.View;
using ZieDitApp.ViewModel;

public partial class EventPage : ContentPage
{
	public EventPage()
	{
		InitializeComponent();
        BindingContext = new EventViewModel();
    }

    public void OnFrameTapped(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ActivityPage());
    }

    public void OnAddActivityButtonClicked(object sender, EventArgs e)
    {

    }
}