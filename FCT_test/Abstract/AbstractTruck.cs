using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT_test.Model
{
    /// <summary>
    /// Абстрактный класс для грузовых машин, осуществляющих доставку
    /// </summary>
    public abstract class AbstractTruck
    {
        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int MaxCapacity { get; private set; }
        public ConcurrentDictionary<Product, int> Dictionary { get; private set; }
        protected AbstractTruck(string name, int maxCapacity)
        {
            Name = name;
            Capacity = 0;
            MaxCapacity = maxCapacity;
            Dictionary = new ConcurrentDictionary<Product, int>();
        }

        public void AddProduct(Product product)
        {
            if (Dictionary.TryGetValue(product, out var val))
            {
                Dictionary[product] = val + 1;
            }
            else
            {
                Dictionary.TryAdd(product, 1);
            }

            Capacity += product.Weight;

            if (Capacity > MaxCapacity)
            {
                Capacity = MaxCapacity;
            }
        }
        public string InfoToString()
        {
            return $"[TruckName: {Name}, Capacity: {Capacity}, MaxCapacity: {MaxCapacity}]";
        }
        public override string ToString()
        {
            var dictionaryString = InfoToString() + " Dictionary: {";
            foreach (var keyValues in Dictionary)
            {
                dictionaryString += keyValues.Key + " : " + keyValues.Value + ", ";
            }
            return dictionaryString.TrimEnd(',', ' ') + "}";
        }
    }
}
