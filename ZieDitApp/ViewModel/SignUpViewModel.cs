using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ZieDitApp.Model;
using ZieDitApp.Repositories;

namespace ZieDitApp.ViewModel
{
    public class SignUpViewModel : BaseViewModel
    {
        private string _userName;
        private string _password;
        private UserRepository _userRepository;
        private INavigation _navigation;

        public SignUpViewModel(INavigation navigation)
        {
            _userRepository = new UserRepository();
            _navigation = navigation;
            SignUpCommand = new Command(OnSignUpClicked);
        }

        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public ICommand SignUpCommand { get; }

        private async void OnSignUpClicked()
        {
            var newUser = new User { Name = UserName, Password = Password };
            try
            {
                _userRepository.AddUser(newUser);
                // User added. Navigate back to the LoginPage.
                await _navigation.PopAsync();
            }
            catch (Exception ex)
            {
                // User not added. Display an error message.
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }

}
