using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZieDitApp.ViewModel
{

    class AddEventViewModel
    {
        public DateTime MinimumDate = new DateTime(2018, 1, 1);
        public DateTime MaximumDate = new DateTime(2030, 12, 31);
        public DateTime Date = DateTime.Now;
    }
}
