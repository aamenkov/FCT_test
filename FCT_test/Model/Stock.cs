using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT_test.Model
{
    public class Stock
    {
        private static Stock instanceStock; 
        private string Name { get; }
        public int Capacity { get; private set; }
        public int MaxCapacity { get; }

        private Stock(string name, int maxCapacity)
        {
            Name = name;
            Capacity = 0;
            MaxCapacity = maxCapacity;
        }

        public static Stock GetInstance(string name)
        {
            if (instanceStock == null)
            {
                instanceStock = new Stock(name, 1000);
            }
            return instanceStock;
        }

        public void Put(Product product)
        {
            Capacity += product.Weight;
        }

        public override string ToString()
        {
            return $"[StockName: {Name}, Capacity: {Capacity}, MaxCapacity: {MaxCapacity}]";
        }
    }
}
