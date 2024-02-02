using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ZieDitApp.Model
{
    class ActivityUser
    {
        [PrimaryKey, AutoIncrement]
        public int ActivityUserId { get; set; }

        public int ActivityId { get; set; }

        public int UserId { get; set; }
    }
}
