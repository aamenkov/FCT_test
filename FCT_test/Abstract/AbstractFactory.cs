using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCT_test.Inteface;

namespace FCT_test.Model
{
    public abstract class AbstractFactory : IProductFactory
    {
        public string Name { get; private set; }
        public int Performance { get; private set; }
        public Product Product { get; private set; }

        protected AbstractFactory(string name, int performance)
        {
            Name = name;
            Performance = performance;
        }

        public Product MakeProduct()
        {
            return Product;
        }

        public Product MakeProduct(string name, string packageType, int weight)
        {
            var product = new Product(name, packageType, weight);
            Product = product;
            return product;
        }

        public override string ToString()
        {
            return $"[FactoryName: {Name}, Performance: {Performance}, Product: {Product}]";
        }
    }
}
