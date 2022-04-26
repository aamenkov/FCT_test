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
        private static int stockCoef = 100;
        static void Main(string[] args)
        {
            var q = productsPerHour * 1.1 / productsPerHour;
            var stockMaxCapacity = (int)(stockCoef * 1.5 * (productsPerHour * (1 - Math.Pow(q, factoryCount)) / (1 - q)));

            var stock = Stock.GetInstance("MainStock", stockMaxCapacity);
            //logger.Info(stock.ToString());
            //logger.Info(stock.FullInfoToString());

            //Thread threadIn = new Thread(Zapolnenie);
            //threadIn.Start();
            //Thread threadOut = new Thread(Razgruzka);
            //threadOut.Start();

            logger.Info(stock.FullInfoToString());
           // Zapolnenie();
            logger.Info(stock.FullInfoToString());
            logger.Info(stock.FullInfoToString());
            logger.Info(stock.FullInfoToString());
           // Razgruzka();
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
                logger.Info("FACTORY: " + factory.ToString());
            }
            var isFull = false;
            while (!isFull)
            {
                foreach (var factory in factoryList)
                {
                    var transaction = factory.MakeTransaction();
                    isFull = stockProvider.Stock(transaction);
                    logger.Info("TO STOCK: " + transaction.ToString());
                }
            }
        }

        static void Razgruzka()
        {
            var transportProvider = new TransportProvider();

            var isEmpty = false;
            while (!isEmpty)
            {
                var truckList = new List<Truck>();

                for (var y = 0; y < trucksCount; y++)
                {
                    var truck = new Truck("Truck" + y, (int)(productsPerHour * (1 + (double)y / 3)));
                    truckList.Add(truck);
                    //logger.Info("TRUCK: " + truck.ToString());
                }

                foreach (var truck in truckList)
                {
                    isEmpty = transportProvider.Transport(truck);
                    logger.Info("TO SHOP: " + truck.ToString());
                    Stock stock = Model.Stock.GetInstance("", 0);
                   // logger.Info("AfterShop: " + stock.FullInfoToString());
                }
                //Stock stock1 = Model.Stock.GetInstance("", 0);
                //logger.Info("AfterForEach: " + stock1.FullInfoToString());
            }
        }

    }

}
