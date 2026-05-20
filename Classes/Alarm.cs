using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteFlexo
{
    public class Alarm
    {
        public DateTime Date { get; set; }
        public string AlarmType { get; set; }
        private string _description;
        public string Description { get; set; }
        public bool IsWarning { get; set; }
        public string AlarmName { get; set; }
    }
}
