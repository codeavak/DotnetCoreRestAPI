using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Models
{
    public class Command
    {
        public int ID { get; set; }
        public string HowTo { get; set; }
        public string Platform { get; set; }
        public string Commandline { get; set; }
    }
}
