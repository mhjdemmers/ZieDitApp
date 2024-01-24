using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;

namespace ZieDitApp.Model
{
    class Organizer : User
    {
        public List<Event>? OwnedEvents { get; set; }
    }
}
