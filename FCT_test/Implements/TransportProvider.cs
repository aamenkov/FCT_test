using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCT_test.Inteface;
using FCT_test.Model;

namespace FCT_test.Implements
{
    public class TransportProvider : ITransportProvider
    {
        private Stock stock = Model.Stock.GetInstance("", 0);
        public bool Transport(AbstractTruck truck)
        {
            if (stock.isEmpty == false)
            {
                stock.LoadCar(truck);
                if (stock.Capacity == 0)
                {
                    stock.AlarmStockIsEmpty();
                }
            }
            return stock.isEmpty;
        }
    }
}
