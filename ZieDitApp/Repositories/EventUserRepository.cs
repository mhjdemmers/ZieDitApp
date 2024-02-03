using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZieDitApp.Model;

namespace ZieDitApp.Repositories
{
   
    public class EventUserRepository : BaseRepository<EventUser>
    {

        public void AddEventUser(EventUser eventUser)
        {
            try
            {
                SaveEntity(eventUser);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

         public void DeleteEventUser(EventUser eventUser)
        {
            try
            {
                DeleteEntity(eventUser);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        public EventUser CheckRegisteredUser(int userId, int eventId)
        {
            try
            {
                return connection.Table<EventUser>().FirstOrDefault(x => x.User == userId && x.Event == eventId);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
                return null;
            }
        }

    }
}
