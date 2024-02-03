using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZieDitApp.Model;
using ZieDitApp.Repositories;

namespace ZieDitApp.ViewModel
{
    internal class ActivityViewModel : BaseViewModel
    {
        public string Registered { get; set; }
        public Activity Activity { get; set; }
        private ActivityRepository _activityRepository;
        private ActivityUserRepository _activityUserRepository;
        public ObservableCollection<Activity> Activities { get; set; }

        public ActivityViewModel(Activity activity)
        {
            _activityRepository = new ActivityRepository();
            _activityUserRepository = new ActivityUserRepository();
            Activity = activity;

            var activities = _activityRepository.GetAllActivities();
            if (activities != null)
            {
                Activities = new ObservableCollection<Activity>(activities);
            }
            else
            {
                Activities = new ObservableCollection<Activity>();
            }

            Registered = IsRegistered(Activity);
        }
        public string IsRegistered(Activity activity)
        {
            int userId = App.CurrentUser.Id;
            int activityId = activity.Id;
            ActivityUser activityUserRegistered = _activityUserRepository.CheckRegisteredUser(userId, activityId);

            if (activityUserRegistered != null)
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
