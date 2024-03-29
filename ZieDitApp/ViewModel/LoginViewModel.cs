﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ZieDitApp.Repositories;
using ZieDitApp.View;

namespace ZieDitApp.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private string _userName;
        private string _password;
        private UserRepository _userRepository;
        private INavigation _navigation;

        public LoginViewModel(INavigation navigation)
        {
            _userRepository = new UserRepository();
            _navigation = navigation;
            LoginCommand = new Command(OnLoginClicked);
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

        public ICommand LoginCommand { get; }

        private async void OnLoginClicked()
        {
            var user = _userRepository.GetUserByUsernameAndPassword(UserName, Password);
            if (user != null)
            {
                // User found. Set the CurrentUser property and navigate to the HomePage.
                App.CurrentUser = user;
                await _navigation.PushAsync(new HomePage());
            }
            else
            {
                // User not found. Display an error message.
                await App.Current.MainPage.DisplayAlert("Error", "Invalid username or password", "OK");
            }
        }
    }
}
