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
        public string Name { get; }
        public int Capacity { get; private set; }
        public int MaxCapacity { get; }
        private ConcurrentDictionary<Product, int> Dictionary { get; } 

        private Stock(string name, int maxCapacity)
        {
            Name = name;
            Capacity = 0;
            MaxCapacity = maxCapacity;
            Dictionary = new ConcurrentDictionary<Product, int>();
        }

        public static Stock GetInstance(string name, int maxCapacity)
        {
            if (instanceStock == null)
            {
                instanceStock = new Stock(name, maxCapacity);
            }
            return instanceStock;
        }

        /// <summary>
        /// Метод для добавления новой продукции на склад
        /// </summary>
        /// <param name="transaction"></param>
        public void Put(Transaction transaction)
        {
            if (Dictionary.TryGetValue(transaction.Product, out var val))
            {
                Dictionary[transaction.Product] = val + transaction.Count;
            }
            else
            {
                Dictionary.TryAdd(transaction.Product, transaction.Count);
            }

            Capacity += transaction.TotalWeight;

            if (Capacity > MaxCapacity)
            {
                Capacity = MaxCapacity;
            }

        }

        /// <summary>
        /// Метод загрузки машины до конца
        /// </summary>
        /// <param name="truck"></param>
        public void LoadCar(AbstractTruck truck)
        {
            foreach (var pair in Dictionary)
            {
                while (pair.Key.Weight < truck.MaxCapacity - truck.Capacity)
                {
                    if (pair.Value > 0)
                    { 
                        truck.AddProduct(pair.Key);
                        Dictionary.TryGetValue(pair.Key, out var val);
                        Dictionary[pair.Key] = val - 1;
                        Capacity = Capacity - pair.Key.Weight;
                    }
                }
            }
        }

        public override string ToString()
        {
            return $"[StockName: {Name}, Capacity: {Capacity}, MaxCapacity: {MaxCapacity}]";
        }

        public string FullInfoToString()
        {
            string dictionaryString = ToString() + " Dictionary: {";
            foreach (var keyValues in Dictionary)
            {
                dictionaryString += keyValues.Key + " : " + keyValues.Value + ", ";
            }
            return dictionaryString.TrimEnd(',', ' ') + "}";
        }

    }
}
