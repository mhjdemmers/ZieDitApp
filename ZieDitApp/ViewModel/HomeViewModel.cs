using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZieDitApp.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        private string _userName;

        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        public HomeViewModel()
        {
            UserName = App.CurrentUser.Name;
        }
    }
}
