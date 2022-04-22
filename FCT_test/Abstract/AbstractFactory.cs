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
        private string Name { get; }
        private int Performance { get; }
        private Product Product { get; set; } // сделать паблик?

        protected AbstractFactory(string name, int performance)
        {
            Name = name;
            Performance = performance;
        }

        public Product MakeProduct() // нужно ли это?
        {
            return Product;
        }

        public void MakeProduct(Product product) // нужно ли это?
        {
            Product = product;
        }

        public Product MakeProduct(string name, string packageType, int weight) // нужно ли это?
        {
            Product product = new Product(name, packageType, weight);
            MakeProduct(product);
            return product;
        }

        public override string ToString()
        {
            return $"[FactoryName: {Name}, Performance: {Performance}, Product: {Product}]";
        }
    }
}
