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
    public class EventViewModel
    {
        public Event Event { get; set; }
        public ObservableCollection<Activity> Activities { get; set; }

        public EventViewModel(Event eventItem)
        {
            Event = eventItem;
            Activities = new ObservableCollection<Activity>
            {
                new Activity { Name = "Activity 1", Time = new DateTime(2022, 12, 1), Description = "Location 1" },
                new Activity { Name = "Activity 2", Time = new DateTime(2022, 12, 2), Description = "Location 2" },
                // More events here
            };
        }
    }
}