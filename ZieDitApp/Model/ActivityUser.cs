﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ZieDitApp.Abstractions;

namespace ZieDitApp.Model
{
    [SQLite.Table("ActivityUsers")]
    class ActivityUser : TableData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int Activity { get; set; }

        public int User { get; set; }
    }
}
