using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ZieDitApp.Model
{
    class Employee : User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
