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
using System.Windows.Input;

namespace ZieDitApp.ViewModel
{
    public class EventViewModel :BaseViewModel
    {
        public string Registered {  get; set; }
        public Guid Code { get; set; }
        public string QRVisible { get; set; }
        public Event Event { get; set; }
        private ActivityRepository _activityRepository;
        private EventUserRepository _eventUserRepository;
        public ObservableCollection<Activity> Activities { get; set; }
        public ICommand RefreshCommand { get; }
        public ICommand UpdateRegisteredQRCommand { get; }
        public ICommand RegisterCommand { get; }
        public ICommand UnregisterCommand { get; }

        public EventViewModel(Event eventItem)
        {
            Activities = new ObservableCollection<Activity>();
            _activityRepository = new ActivityRepository();
            _eventUserRepository = new EventUserRepository();
            Event = eventItem;

            RefreshEvents();

            RefreshCommand = new Command(RefreshEvents);

            //var activities = _activityRepository.GetAllActivities();
            //if (activities != null)
            //{
            //    Activities = new ObservableCollection<Activity>(activities);
            //}
            //else
            //{
            //    Activities = new ObservableCollection<Activity>();
            //}

            UpdateRegisteredQR();

            //UpdateRegisteredQRCommand = new Command(UpdateRegisteredQR);

            RegisterCommand = new Command(Register);
            UnregisterCommand = new Command(Unregister);

            //Registered = IsRegistered(Event);
            //Code = GetCode(Event);
            //QRVisible = Code != Guid.Empty ? "True" : "False";
        }

        public string IsRegistered(Event eventItem)
        {
            int userId = App.CurrentUser.Id;
            int eventId = eventItem.Id;
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

        public Guid GetCode(Event eventItem)
        {
            int userId = App.CurrentUser.Id;
            int eventId = eventItem.Id;
            EventUser eventUser = _eventUserRepository.CheckRegisteredUser(userId, eventId);

            if (eventUser != null)
            {
                return eventUser.Code;
            }
            else
            {
                return Guid.Empty;
            }
        }

        private void RefreshEvents()
        {
            var activities = _activityRepository.GetAllActivities();

            Activities = new ObservableCollection<Activity>(activities);

        }

        private void UpdateRegisteredQR()
        {
            Registered = IsRegistered(Event);
            Code = GetCode(Event);
            QRVisible = Code != Guid.Empty ? "True" : "False";
        }

        private void Register()
        {
            EventUser eventUser = new EventUser()
            {
                Event = Event.Id,
                User = App.CurrentUser.Id,
                Code = Guid.NewGuid()
            };
            _eventUserRepository.AddEventUser(eventUser);
            UpdateRegisteredQR();
        }

        private void Unregister()
        {
            int userId = App.CurrentUser.Id;
            int eventId = Event.Id;
            EventUser eventUser = _eventUserRepository.CheckRegisteredUser(userId, eventId);

            if (eventUser != null)
            {
                _eventUserRepository.DeleteEventUser(eventUser);
                UpdateRegisteredQR();
            }
        }

    }
}