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

namespace ZieDitApp.ViewModel
{
    public class EventsViewModel : BaseViewModel
    {
        public ObservableCollection<Event> Events { get; set; }
        private EventRepository _eventRepository;

        public EventsViewModel()
        {
            _eventRepository = new EventRepository();
            var events = _eventRepository.GetAllEvents();
            if (events != null)
            {
                Events = new ObservableCollection<Event>(events);
            }
            else
            {
                Events = new ObservableCollection<Event>();
            }
        }
    }
}
