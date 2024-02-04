namespace ZieDitApp.View;

using System.Diagnostics;
using ZieDitApp.Model;
using ZieDitApp.Repositories;
using ZieDitApp.ViewModel;

public partial class EventPage : ContentPage
{
    private Event _eventItem;
    private EventUserRepository _eventUserRepository;
    private EventRepository _eventRepository;
    public EventPage(Event eventItem)
	{
        InitializeComponent();
        _eventUserRepository = new EventUserRepository();
        _eventRepository = new EventRepository();
        _eventItem = eventItem;
        BindingContext = new EventViewModel(eventItem);
    }

    public void OnFrameTapped(object sender, EventArgs e)
    {
        var frame = (Frame)sender;
        var activity = (Model.Activity)frame.BindingContext;
        Navigation.PushAsync(new ActivityPage(activity));
    }

    public void OnDeleteEventButtonClicked(object sender, EventArgs e)
    {
        _eventRepository.DeleteEvent(_eventItem);
        Navigation.PopAsync();
    }
    public void OnAddActivityButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddActivityPage(_eventItem));
    }

    private void OnInschrijvenButtonClicked(object sender, EventArgs e)
    {
        EventUser eventUser = new EventUser()
        {
            Event = _eventItem.Id,
            User = App.CurrentUser.Id,
            Code = Guid.NewGuid()
        };
        _eventUserRepository.AddEventUser(eventUser);

    }

    private void OnUitschrijvenButtonClicked(object sender, EventArgs e)
    {
        int userId = App.CurrentUser.Id;
        int eventId = _eventItem.Id;
        EventUser eventUser = _eventUserRepository.CheckRegisteredUser(userId, eventId);

        if (eventUser != null)
        {
            _eventUserRepository.DeleteEventUser(eventUser);

            //// Update the Registered property
            //var viewModel = BindingContext as EventViewModel;
            //    if (viewModel != null)
            //{
            //    viewModel.Registered = viewModel.IsRegistered(_eventItem);
            //}
        }
    }
}