using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLitePCL;

namespace ZieDitApp.Model
{
    class Organizer : User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int EventId { get; set; }
    }
}
