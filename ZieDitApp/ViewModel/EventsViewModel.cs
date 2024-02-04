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
using System.Windows.Input;

namespace ZieDitApp.ViewModel
{
    public class EventsViewModel : BaseViewModel
    {
        public ObservableCollection<Event> Events { get; set; }
        private EventRepository _eventRepository;
        public ICommand RefreshCommand { get; }

        public EventsViewModel()
        {
            Events = new ObservableCollection<Event>();
            _eventRepository = new EventRepository();
            RefreshEvents();

            RefreshCommand = new Command(RefreshEvents);
        }

        private void RefreshEvents()
        {
            var events = _eventRepository.GetAllEvents();

            Events = new ObservableCollection<Event>(events);

        }
    }
}
