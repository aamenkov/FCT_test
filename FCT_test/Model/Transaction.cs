using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT_test.Model
{
    public class Transaction
    {
        public string FactoryName { get; private set; }
        public string ProductName { get; private set; }
        public int Count { get; private set; }
        public int TotalWeight { get; private set; }

        public Transaction(AbstractFactory factory)
        {
            FactoryName = factory.Name;
            ProductName = factory.Product.Name;
            Count = factory.Performance;
            TotalWeight = factory.Product.Weight * Count;
        }

        public override string ToString()
        {
            return $"[FactoryName: {FactoryName}, ProductName: {ProductName}, Count: {Count}, TotalWeight: {TotalWeight}]";
        }
    }
}