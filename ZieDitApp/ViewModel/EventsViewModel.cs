using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ZieDitApp.Model;

namespace ZieDitApp.ViewModel
{
    public class EventsViewModel
    {
        public ObservableCollection<Event> Events { get; set; }

        public EventsViewModel()
        {
            Events = new ObservableCollection<Event>
        {
            new Event { Name = "Event 1", Date = new DateTime(2022, 12, 1), Location = "Location 1" },
            new Event { Name = "Event 2", Date = new DateTime(2022, 12, 2), Location = "Location 2" },
            // More events here
        };
        }
    }
}
