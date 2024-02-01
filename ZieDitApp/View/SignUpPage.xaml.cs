using ZieDitApp.ViewModel;

namespace ZieDitApp.View;

public partial class SignUpPage : ContentPage
{
    public SignUpPage()
    {
        InitializeComponent();
        BindingContext = new SignUpViewModel(Navigation);
    }
}