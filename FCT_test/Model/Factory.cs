using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCT_test.Inteface;

namespace FCT_test.Model
{
    public class Factory: AbstractFactory
    {
        public Factory(string name, int performance) : base(name, performance) { }
    }
}
