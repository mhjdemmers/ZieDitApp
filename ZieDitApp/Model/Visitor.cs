using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ZieDitApp.Model
{
    class Visitor : User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public List<Event>? EnrolledEvents { get; set; }
        public List<Activity>? EnrolledActivities { get; set; }
    }
}
