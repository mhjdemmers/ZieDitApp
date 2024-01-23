using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ZieDitApp.Model;

namespace ZieDitApp.ViewModel
{
    public class ScheduleViewModel
    {
        public ObservableCollection<Activity> Activities { get; set; }

        public ScheduleViewModel()
        {
            var activities = new List<Activity>
            {
                new Activity { Name = "Activity 1", Time = new DateTime(2022, 12, 1), Description = "Location 1" },
                new Activity { Name = "Activity 2", Time = new DateTime(2022, 12, 2), Description = "Location 2" },
                new Activity { Name = "Activity 3", Time = new DateTime(2022, 12, 2), Description = "Location 2" },
                new Activity { Name = "Activity 4", Time = new DateTime(2022, 12, 2), Description = "Location 2" },
                new Activity { Name = "Activity 5", Time = new DateTime(2022, 12, 2), Description = "Location 2" },
                new Activity { Name = "Activity 6", Time = new DateTime(2022, 12, 2), Description = "Location 2" },

                // More events here
            };

            // Sort activities by time
            activities.Sort((a, b) => a.Time.CompareTo(b.Time));

            Activities = new ObservableCollection<Activity>(activities);
        }
    }
}