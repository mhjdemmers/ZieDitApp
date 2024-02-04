using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ZieDitApp.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZieDitApp.Model
{
    [SQLite.Table("EventUsers")]
    public class EventUser : TableData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int Event { get; set; }
        
        public int User { get; set; }

        public Guid Code { get; set; }
    }
}
