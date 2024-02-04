using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ZieDitApp.Abstractions;


namespace ZieDitApp.Model
{
    [SQLite.Table("Rooms")]
    class Room : TableData
    {
        public string? Name { get; set; }
        public int MaxVisitors { get; set; }
        public string? Description { get; set; }
    }
}
