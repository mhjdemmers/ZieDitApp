using ZieDitApp.ViewModel;

namespace ZieDitApp.View;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = new LoginViewModel(this.Navigation);
    }
    void OnLoginClicked(object sender, EventArgs e)
    {
        //Navigation.PushAsync(new HomePage());
    }

    async void OnSignUpClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SignUpPage());
    }
}
