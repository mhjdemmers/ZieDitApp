using ZieDitApp.Model;
using ZieDitApp.Repositories;
using ZieDitApp.ViewModel;

namespace ZieDitApp.View;

public partial class UpdateEventPage : ContentPage
{
	private Event _event;
	public UpdateEventPage(Event eventItem)
	{
		_event = eventItem;
		InitializeComponent();
		BindingContext = new UpdateEventViewModel(eventItem);
	}

	public void OnEditButtonClicked(object sender, EventArgs e)
	{
        _event.Name = NameEntry.Text;
        _event.Location = LocationEntry.Text;
        _event.Description = DescriptionEntry.Text;
        _event.Date = DatePicker.Date;

        var eventRepository = new EventRepository();
        eventRepository.AddEvent(_event);
        Navigation.PopAsync();
    }
}