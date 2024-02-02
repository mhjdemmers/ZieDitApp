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
            // Other methods...

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


        }
}
