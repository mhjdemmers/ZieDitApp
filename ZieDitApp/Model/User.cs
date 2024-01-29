using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ZieDitApp.Abstractions;

namespace ZieDitApp.Model
{
    [SQLite.Table("Users")]
    public class User : TableData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [SQLite.Column("name"), Indexed, SQLite.NotNull]
        public string? Name { get; set; }

        [Unique]
        public string? Password { get; set; }
    }
}
