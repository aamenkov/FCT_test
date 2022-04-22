using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT_test.Model
{
    public abstract class AbstractTruck
    {
        private string Name { get; }
        public int Capacity { get; private set; }
        private int MaxCapacity { get; }

        protected AbstractTruck(string name, int maxCapacity)
        {
            Name = name;
            Capacity = 0;
            MaxCapacity = maxCapacity;
        }

        public override string ToString()
        {
            return $"[TruckName: {Name}, Capacity: {Capacity}, MaxCapacity: {MaxCapacity}]";
        }
    }
}
