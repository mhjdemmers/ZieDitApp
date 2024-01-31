using ZieDitApp.Model;
namespace ZieDitApp.View;

public partial class ActivityPage : ContentPage
{
	public ActivityPage(Activity activity)
	{
		InitializeComponent();
        BindingContext = activity;
    }
}