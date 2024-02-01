namespace ZieDitApp.View;

using ZieDitApp.Model;
using ZieDitApp.ViewModel;

public partial class EventPage : ContentPage
{
	public EventPage(Event eventItem)
	{
        InitializeComponent();
        BindingContext = new EventViewModel(eventItem);
        InitializeComponent();
    }


    public void OnFrameTapped(object sender, EventArgs e)
    {
        var frame = (Frame)sender;
        var activity = (Activity)frame.BindingContext;
        Navigation.PushAsync(new ActivityPage(activity));
    }

    public void OnAddActivityButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddActivityPage());
    }
}