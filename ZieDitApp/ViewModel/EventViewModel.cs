using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ZieDitApp.Model;
using ZieDitApp.Repositories;
using Microsoft.Extensions.Logging;

namespace ZieDitApp.ViewModel
{
    public class EventViewModel :BaseViewModel
    {
        public string Registered {  get; set; }
        public Event Event { get; set; }
        private ActivityRepository _activityRepository;
        private EventUserRepository _eventUserRepository;
        public ObservableCollection<Activity> Activities { get; set; }

        public EventViewModel(Event eventItem)
        {
            _activityRepository = new ActivityRepository();
            _eventUserRepository = new EventUserRepository();
            Event = eventItem;
           
            var activities = _activityRepository.GetAllActivities();
            if (activities != null)
            {
                Activities = new ObservableCollection<Activity>(activities);
            }
            else
            {
                Activities = new ObservableCollection<Activity>();
            }

            Registered = IsRegistered(Event);
        }

        private string IsRegistered(Event eventIten)
        {
            int userId = App.CurrentUser.Id;
            int eventId = eventIten.Id;
            EventUser eventUserRegistered = _eventUserRepository.CheckRegisteredUser(userId, eventId);

            if (eventUserRegistered != null)
            {

                return "Je bent ingeschreven.";
            }
            else 
            {
                return "Je bent niet ingeschreven.";
            }

        }
        
    }
}