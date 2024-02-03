using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZieDitApp.Model;

namespace ZieDitApp.Repositories
{
    internal class ActivityUserRepository : BaseRepository<ActivityUser>
    {
        public void AddActivityUser(ActivityUser activityUser)
        {
            try
            {
                SaveEntity(activityUser);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        public ActivityUser CheckRegisteredUser(int userId, int eventId)
        {
            try
            {
                return connection.Table<ActivityUser>().FirstOrDefault(x => x.User == userId && x.Activity == eventId);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
                return null;
            }
        }

    }
}

