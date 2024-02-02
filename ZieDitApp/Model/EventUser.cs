using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ZieDitApp.Model
{
    class EventUser
    {
        [PrimaryKey, AutoIncrement]
        public int EventUserId { get; set; }

        public int EventId { get; set; }

        public int UserId { get; set; }
    }
}
