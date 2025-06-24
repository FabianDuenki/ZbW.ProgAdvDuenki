using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaggisache
{
    public class Mueter
    {
        public Mueter() { }
        public string Name { get; set; } = "dini";
        public int Age { get; set; } = 69;
        public string WakeUp()
        {
            return "LOH MI SCHLOFE!";
        }
        public bool AskForMoney(int amount)
        {
            return false;
        }
    }
}
