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

        public void Stock(Transaction transaction)
        {
            stock.Put(transaction);

            if (stock.Capacity > 0.95 * stock.MaxCapacity)
            {
                // TODO: машинки поехали
                // заполняется ли в это время склад...

            }
        }

    }
}
