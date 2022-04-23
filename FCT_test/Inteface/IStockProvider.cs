using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCT_test.Model;

namespace FCT_test.Inteface
{
    /// <summary>
    /// Интерфейс для отправления продукции на склад
    /// </summary>
    public interface IStockProvider
    {
        public void Stock(Transaction transaction);
    }
}
