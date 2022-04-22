using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCT_test.Model;

namespace FCT_test.Inteface
{
    public interface IStockProvider
    {
        public void Stock(Product product);
    }
}
