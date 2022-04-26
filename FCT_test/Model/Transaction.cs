using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT_test.Model
{
    /// <summary>
    /// Вспомогательный класс для продукции на складе
    /// </summary>
    public class Transaction
    {
        public string FactoryName { get; private set; }
        public Product Product { get; private set; }
        public int Count { get; private set; }
        public int TotalWeight { get; private set; }

        public Transaction(AbstractFactory factory)
        {
            FactoryName = factory.Name;
            Product = factory.Product;
            Count = factory.Performance;
            TotalWeight = factory.Product.Weight * Count;
        }

        public Transaction(string factoryName, Product product, int count, int totalWeight)
        {
            FactoryName = factoryName;
            Product = product;
            Count = count;
            TotalWeight = totalWeight;
        }

        public override string ToString()
        {
            return $"[FactoryName: {FactoryName}, " + Product.Name + $", Count: {Count}, TotalWeight: {TotalWeight}]";
        }
    }
}