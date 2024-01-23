namespace ZieDitApp.View;
using ZieDitApp.ViewModel;

public partial class SchedulePage : ContentPage
{
    public SchedulePage()
    {
        InitializeComponent();
        BindingContext = new ScheduleViewModel();
    }
}
