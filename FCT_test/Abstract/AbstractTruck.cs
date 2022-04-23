using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT_test.Model
{
    /// <summary>
    /// Абстрактный класс для грузовых машин
    /// </summary>
    public abstract class AbstractTruck
    {
        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int MaxCapacity { get; private set; }

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
