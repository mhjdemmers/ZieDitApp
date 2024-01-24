using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZieDitApp.Model
{
    class Presenter : User
    {
        public List<Activity>? OwnedActivities { get; set; }
    }
}
