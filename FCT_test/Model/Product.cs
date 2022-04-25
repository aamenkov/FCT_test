using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT_test.Model
{
    public class Product : AbstractProduct
    {
        public Product(string name, string packageType, int weight) : base(name, packageType, weight){ }
    }
}
