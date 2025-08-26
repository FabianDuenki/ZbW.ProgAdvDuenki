using Autofac.Core;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopper
{
    public class UsageCounter
    {
        private int _counter = 0;
        public UsageCounter() { }
        public void Use()
        {
            _counter++;
            Console.WriteLine($"{_counter} Verwendung(en)");
        }
    }
}
