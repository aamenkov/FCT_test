using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using FCT_test.Implements;
using FCT_test.Model;
using NLog;

namespace FCT_test
{
    internal class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private static int factoryCount = 3;
        private static int trucksCount = 2;
        private static int productsPerHour = 100;
        private static int stockCoef = 10;
        static void Main(string[] args)
        {
            var q = productsPerHour * 1.1 / productsPerHour;
            var stockMaxCapacity = (int)(stockCoef * 1.5 * (productsPerHour * (1 - Math.Pow(q, factoryCount)) / (1 - q)));
            // logger.Info(q);
            // logger.Info(stockMaxCapacity);

            var stock = Stock.GetInstance("MainStock", stockMaxCapacity);
            logger.Info(stock.ToString());
            //   logger.Info(stock.FullInfoToString());


            Thread threadIn = new Thread(Zapolnenie);
            threadIn.Start();

            Thread threadOut = new Thread(Razgruzka);
            threadOut.Start();

            logger.Info(stock.FullInfoToString());
        }

        static void Zapolnenie()
        {
            var stockProvider = new StockProvider();
            var factoryList = new List<Factory>();

            for (var i = 0; i < factoryCount; i++)
            {
                var factory = new Factory("Factory" + i, (int)(productsPerHour * (1 + (double)i / 10)));
                factory.MakeProduct("Product" + i, "Plastic" + i, i % 2 + 1);
                factoryList.Add(factory);
                logger.Info(factory.ToString());
                
            }

            while (true)
            {
                foreach (var factory in factoryList)
                {
                    var transaction = factory.MakeTransaction();
                    stockProvider.Stock(transaction);
                    logger.Info("TO STOCK: " + transaction.ToString());
                }
            }
        }

        static void Razgruzka()
        {
            var transportProvider = new TransportProvider();

            var truckList = new List<Truck>();
            for (var y = 0; y < trucksCount; y++)
            {
                var truck = new Truck("Truck" + y, (int)(productsPerHour * (1 + (double)y / 3)));
                truckList.Add(truck);
                logger.Info(truck.ToString());
            }

            Stock stock = Model.Stock.GetInstance("", 0);
            if (stock.Capacity > 0.95 * stock.MaxCapacity)
            {
                while (true)
                {
                    foreach (var truck in truckList)
                    {
                        transportProvider.Transport(truck);
                        logger.Info(truck.ToString());
                    }
                }
            }

        }

    }

}
