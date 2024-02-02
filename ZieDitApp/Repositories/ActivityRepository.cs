using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZieDitApp.Model;

namespace ZieDitApp.Repositories
{
    internal class ActivityRepository : BaseRepository<Activity>
    {
        public Activity GetActivityById(int id)
        {
            try
            {
                return connection.Table<Activity>().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        public List<Activity> GetAllActivities()
        {
            try
            {
                return connection.Table<Activity>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }


        public void AddActivity(Activity activity)
        {
            try
            {
                SaveEntity(activity);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        public void DeleteActivity(Activity activity)
        {
            try
            {
                DeleteEntity(activity);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        public List<Activity> GetActivitiesByEvent(int eventId)
        {
            try
            {
                return connection.Table<Activity>().Where(x => x.EventId == eventId).ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }


        //public List<Activity> GetActivitiesByEventId(int eventId)
        //{
        //    try
        //    {
        //        return connection.Table<Activity>().Where(x => x.EventId == eventId).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        StatusMessage = $"Error: {ex.Message}";
        //    }
        //    return null;
        //}   
    }
}
