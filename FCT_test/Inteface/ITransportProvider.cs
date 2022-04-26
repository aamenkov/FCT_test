using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCT_test.Model;

namespace FCT_test.Inteface
{
    /// <summary>
    /// Интерфейс для разгрузки склада
    /// </summary>
    public interface ITransportProvider
    {
        public bool Transport(AbstractTruck truck);
    }
}
