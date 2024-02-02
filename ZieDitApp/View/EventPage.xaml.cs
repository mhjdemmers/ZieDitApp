namespace ZieDitApp.View;

using ZieDitApp.Model;
using ZieDitApp.Repositories;
using ZieDitApp.ViewModel;

public partial class EventPage : ContentPage
{
    private Event _eventItem;
    private EventUserRepository _eventUserRepository;
    public EventPage(Event eventItem)
	{
        InitializeComponent();
        _eventUserRepository = new EventUserRepository();
        _eventItem = eventItem;
        BindingContext = new EventViewModel(eventItem);
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

    private void OnInschrijvenButtonClicked(object sender, EventArgs e)
    {
        EventUser eventUser = new EventUser()
        {
            Event = _eventItem.Id,
            User = App.CurrentUser.Id
        };
        _eventUserRepository.AddEventUser(eventUser);

    }
}