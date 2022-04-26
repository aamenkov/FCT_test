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
        private readonly Stock _stock = Model.Stock.GetInstance("", 0);
        public bool Transport(AbstractTruck truck)
        {
            if ((_stock.IsEmpty == false) && (_stock.IsFull == true))
            {
                _stock.LoadCar(truck);
                if (_stock.Capacity == 0)
                {
                    _stock.SetEmpty();
                }
            }
            return _stock.IsEmpty;
        }
    }
}
