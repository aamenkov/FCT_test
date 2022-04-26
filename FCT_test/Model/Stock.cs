using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace FCT_test.Model
{
    /// <summary>
    /// Синглтон класс для склада
    /// </summary>
    public class Stock
    {
        private static Stock _instanceStock; 
        public string Name { get; }
        public int Capacity { get; private set; }
        public int MaxCapacity { get; }
        public ConcurrentDictionary<Product, int> Dictionary { get; } 
        public bool IsFull { get; private set; }
        public bool IsEmpty { get; private set; }
        private Stock(string name, int maxCapacity)
        {
            Name = name;
            Capacity = 0;
            MaxCapacity = maxCapacity;
            Dictionary = new ConcurrentDictionary<Product, int>();
            IsFull = false;
            IsEmpty = false;
        }

        public static Stock GetInstance(string name, int maxCapacity)
        {
            if (_instanceStock == null)
            {
                _instanceStock = new Stock(name, maxCapacity);
            }
            return _instanceStock;
        }

        public void SetFull()
        {
            IsFull = true;
        }

        public void SetEmpty()
        {
            IsEmpty = true;
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
                Dictionary.TryGetValue(pair.Key, out var val);
                while ((val > 0) && (truck.MaxCapacity - truck.Capacity >= pair.Key.Weight))
                {
                    truck.AddProduct(pair.Key);
                    Dictionary[pair.Key] = val - 1;
                    Capacity = Capacity - pair.Key.Weight;
                    Dictionary.TryGetValue(pair.Key, out val);
                }
            }
        }

        public override string ToString()
        {
            return $"[StockName: {Name}, Capacity: {Capacity}, MaxCapacity: {MaxCapacity}]";
        }

        public string FullInfoToString()
        {
            var dictionaryString = ToString() + " Dictionary: {";
            foreach (var keyValues in Dictionary)
            {
                dictionaryString += keyValues.Key + " : " + keyValues.Value + ", ";
            }
            return dictionaryString.TrimEnd(',', ' ') + "}";
        }

    }
}
