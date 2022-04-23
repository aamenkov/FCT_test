using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT_test.Model
{
    /// <summary>
    /// Синглтон класс для склада
    /// </summary>
    public class Stock
    {
        private static Stock instanceStock; 
        private string Name { get; }
        public int Capacity { get; private set; }
        public int MaxCapacity { get; }
        private ConcurrentDictionary<string, int> Dictionary { get; }

        private Stock(string name, int maxCapacity)
        {
            Name = name;
            Capacity = 0;
            MaxCapacity = maxCapacity;
            Dictionary = new ConcurrentDictionary<string, int>();
        }

        public static Stock GetInstance(string name)
        {
            if (instanceStock == null)
            {
                instanceStock = new Stock(name, 1000);
            }
            return instanceStock;
        }

        /// <summary>
        /// Метод для добавления новой продукции на склад
        /// </summary>
        /// <param name="transaction"></param>
        public void Put(Transaction transaction)
        {
            bool isExist = false;
            foreach (KeyValuePair<string, int> pair in Dictionary)
            {
                if (transaction.ProductName.Equals(pair.Key))
                {
                    isExist = true;
                }
            }
            if (isExist == false)
            {
                Dictionary.TryAdd(transaction.ProductName, transaction.Count);
            }
            Capacity += transaction.TotalWeight;

            if (Capacity > MaxCapacity)
            {
                Capacity = MaxCapacity;
            }
        }

        public override string ToString()
        {
            return $"[StockName: {Name}, Capacity: {Capacity}, MaxCapacity: {MaxCapacity}]";
        }
    }
}
