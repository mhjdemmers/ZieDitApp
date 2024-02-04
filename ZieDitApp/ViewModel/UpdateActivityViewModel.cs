using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZieDitApp.Model;

namespace ZieDitApp.ViewModel
{
    public class UpdateActivityViewModel : BaseViewModel
    {
        public Activity Activity { get; set; }
        public UpdateActivityViewModel(Activity activity)
        {
            Activity = activity;
        }
        
    }
}
