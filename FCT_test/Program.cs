using System;
using FCT_test.Model;

namespace FCT_test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Factory factory = new Factory("Factory", 110);
            Product product = factory.MakeProduct("Product", "Plastic", 2);
            Console.WriteLine(factory.ToString());

            Stock stock = Stock.GetInstance("Simple");

            Console.WriteLine(stock.ToString());
            stock.Put(product);
            Console.WriteLine(stock.ToString());
        }
    }
}
