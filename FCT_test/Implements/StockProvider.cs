using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCT_test.Inteface;
using FCT_test.Model;

namespace FCT_test.Implements
{
    public class StockProvider : IStockProvider
    {
        private readonly Stock _stock = Model.Stock.GetInstance("", 0);
        public bool Stock(Transaction transaction)
        {
            if (_stock.IsFull == false)
            {
                _stock.Put(transaction);
                if (_stock.Capacity > 0.95 * _stock.MaxCapacity)
                {
                    _stock.SetFull();
                }
            }
            return _stock.IsFull;
        }
    }
}
