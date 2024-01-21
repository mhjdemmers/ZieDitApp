namespace ZieDitApp.View;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}
	void OnEventsClicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new EventsPage());
	}

    void OnScanClicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new ScanPage());
    }

    void OnScheduleClicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new SchedulePage());
    }

    void OnDataClicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new DataPage());
    }
}