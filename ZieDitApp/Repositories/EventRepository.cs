using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZieDitApp.Model;

namespace ZieDitApp.Repositories
{
    internal class EventRepository : BaseRepository<Event>
    {
        public Event GetEventById(int id)
        {
            try
            {
                return connection.Table<Event>().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }
        public List<Event> GetAllEvents()
        {
            try
            {
                return connection.Table<Event>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        public void AddEvent(Event eventItem)
        {
            try
            {
                SaveEntity(eventItem);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }
        public void DeleteEvent(Event eventItem)
        {
            try
            {
                DeleteEntity(eventItem);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }
    }
}
