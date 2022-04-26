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
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private static readonly int _factoryCount = 3;
        private static readonly int _trucksCount = 2;
        private static readonly int _productsPerHour = 100;
        private static readonly int _stockCoeff = 100;

        private static void Main(string[] args)
        {

            const double q = 1.1;
            var stockMaxCapacity = (int)(_stockCoeff * 1.5 * (_productsPerHour * (1 - Math.Pow(q, _factoryCount)) / (1 - q)));
            // создание склада
            var stock = Stock.GetInstance("MainStock", stockMaxCapacity);
            
            // создание фабрик
            var factoriesList = new List<Factory>();
            for (var i = 0; i < _factoryCount; i++)
            {
                var factory = new Factory("Factory" + i, (int)(_productsPerHour * (1 + (double)i / 10)));
                factory.MakeProduct("Product" + i, "Package" + i, i % 2 + 1);
                factoriesList.Add(factory);
                Logger.Info("FACTORY: " + factory.ToString());
            }

            // запуск пулла потоков с загрузкой
            ThreadPool.QueueUserWorkItem(new WaitCallback(Loading), factoriesList);

            // создание и запуск потока с разгрузкой
            var threadOut = new Thread(Unloading);
            threadOut.Start();
        }

        private static void Loading(object stateInfo)
        {
            var stockProvider = new StockProvider();
            var factoryList = (List<Factory>)stateInfo;

            var isFull = false;
            while (!isFull)
            {
                foreach (var factory in factoryList)
                {
                    var transaction = factory.MakeTransaction();
                    isFull = stockProvider.Stock(transaction);
                    Logger.Info("TO STOCK: " + transaction.ToString());
                }
            }
        }
        private static void Unloading(object stateInfo)
        {
            var transportProvider = new TransportProvider();

            var isEmpty = false;
            while (!isEmpty) 
            {
                var truckList = new List<Truck>();

                for (var y = 0; y < _trucksCount; y++)
                {
                    var truck = new Truck("Truck" + y, (int)(_productsPerHour * (1 + (double)y / 3)));
                    truckList.Add(truck);
                }

                foreach (var truck in truckList)
                {
                    isEmpty = transportProvider.Transport(truck);
                    Logger.Info("TO SHOP: " + truck.ToString());
                }
                //var stock = Model.Stock.GetInstance("", 0);
                //Logger.Info("StockAfterTruckGroup: " + stock.FullInfoToString());
            }
        }
    }
}
