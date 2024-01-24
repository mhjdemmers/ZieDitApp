namespace ZieDitApp.View;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        
    }
    void OnLoginClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new HomePage());
    }
}