using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZieDitApp.Model;

namespace ZieDitApp.ViewModel
{
    public class UpdateEventViewModel : BaseViewModel
    {
        public Event Event { get; set; }
        public UpdateEventViewModel(Event eventItem)
        {
            Event = eventItem;
        }
    }
}
