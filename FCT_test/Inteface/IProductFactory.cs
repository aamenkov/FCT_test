using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCT_test.Model;

namespace FCT_test.Inteface
{
    /// <summary>
    /// Интерфейс создания продукта
    /// </summary>
    public interface IProductFactory
    {
        public void MakeProduct(string name, string packageType, int weight);
        public Transaction MakeTransaction();
    }
}
