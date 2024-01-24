using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZieDitApp.Model
{
    class Visitor : User
    {
        public List<Event>? EnrolledEvents { get; set; }
        public List<Activity>? EnrolledActivities { get; set; }
    }
}
