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
        private static Stock instanceStock; 
        public string Name { get; }
        public int Capacity { get; private set; }
        public int MaxCapacity { get; }
        private ConcurrentDictionary<Product, int> Dictionary { get; } 
        public bool isFull { get; private set; }
        public bool isEmpty { get; private set; }
        private Stock(string name, int maxCapacity)
        {
            Name = name;
            Capacity = 0;
            MaxCapacity = maxCapacity;
            Dictionary = new ConcurrentDictionary<Product, int>();
            isFull = false;
            isEmpty = false;
        }

        public static Stock GetInstance(string name, int maxCapacity)
        {
            if (instanceStock == null)
            {
                instanceStock = new Stock(name, maxCapacity);
            }
            return instanceStock;
        }

        public void AlarmStockIsFull()
        {
            isFull = true;
        }

        public void AlarmStockIsEmpty()
        {
            isEmpty = true;
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
            //delaet tol'kjo одну итерацию, обе машины машина уменьшеают сток и уехжает остальные не киеньшают
            //все в складе зануляется
            foreach (var pair in Dictionary)
            {
                Dictionary.TryGetValue(pair.Key, out var val);
                while ((truck.MaxCapacity - truck.Capacity >= pair.Key.Weight) && (val > 0))
                {
                    truck.AddProduct(pair.Key);
                    //Console.WriteLine(val);
                    Dictionary[pair.Key] = val - 1;
                    //Console.WriteLine(pair);
                    Capacity = Capacity - pair.Key.Weight;
                    //Console.WriteLine(Capacity.ToString(), pair.Key.Weight);
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
