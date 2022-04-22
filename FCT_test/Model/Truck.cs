using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT_test.Model
{
    public class Truck : AbstractTruck
    {
        public Truck(string name, int maxCapacity) : base(name, maxCapacity) { }
    }
}
