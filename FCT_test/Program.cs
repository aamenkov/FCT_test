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

            var factory = new Factory("FactoryA", 110);
            var product = factory.MakeProduct("ProductA", "Plastic", 2);

            logger.Info(factory.ToString());
            var stock = Stock.GetInstance("Simple");

            logger.Info(stock.ToString());
            var stockProvider = new StockProvider();

            var transaction = new Transaction(factory);
            stockProvider.Stock(transaction);

            logger.Info("TO STOCK: " + transaction.ToString());

        }
    }
}
