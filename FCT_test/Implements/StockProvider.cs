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
        private Stock stock = Model.Stock.GetInstance("", 0);
        public bool Stock(Transaction transaction)
        {
            if (stock.isFull == false)
            {
                stock.Put(transaction);
                if (stock.Capacity > 0.95 * stock.MaxCapacity)
                {
                    stock.AlarmStockIsFull();
                }
            }
            return stock.isFull;
        }
    }
}
