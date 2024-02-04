using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ZieDitApp.Abstractions;

namespace ZieDitApp.Model
{
    [SQLite.Table("Events")]
    public class Event : TableData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public int OrganizerId { get; set; }
    }
}
