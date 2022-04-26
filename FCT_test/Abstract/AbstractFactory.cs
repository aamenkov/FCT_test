using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCT_test.Inteface;

namespace FCT_test.Model
{
    /// <summary>
    /// Абстрактный класс для фабрик
    /// </summary>
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

        /// <summary>
        /// Метод для создания продукта
        /// </summary>
        /// <param name="name"></param>
        /// <param name="packageType"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public void MakeProduct(string name, string packageType, int weight)
        {
            var product = new Product(name, packageType, weight);
            Product = product;
        }

        /// <summary>
        /// Метод для создания транзакции для отправления на склад
        /// </summary>
        /// <returns></returns>
        public Transaction MakeTransaction()
        {
            return new Transaction(Name, Product, Performance, Product.Weight * Performance);
        }

        public override string ToString()
        {
            return $"[FactoryName: {Name}, Performance: {Performance}, Product: {Product}]";
        }
    }
}
