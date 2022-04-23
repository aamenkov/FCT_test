using System;
using FCT_test.Implements;
using FCT_test.Model;
using NLog;

namespace FCT_test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var logger = LogManager.GetCurrentClassLogger();

            Factory factory = new Factory("Factory", 110);
            Product product = factory.MakeProduct("Product", "Plastic", 2);

            logger.Info(factory.ToString());
            Stock stock = Stock.GetInstance("Simple");

            logger.Info(stock.ToString());
            StockProvider stockProvider = new StockProvider();
            stockProvider.Stock(factory.MakeProduct());
            logger.Info(stock.ToString());

        }
    }
}
