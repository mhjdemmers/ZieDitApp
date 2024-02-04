using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ZieDitApp.Abstractions;

namespace ZieDitApp.Model
{
    [SQLite.Table("Activities")]
    public class Activity : TableData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan Time { get; set; }

        
        public int PresenterId { get; set; }
        public int EventId { get; set; }
    }
}
