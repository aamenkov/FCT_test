using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT_test.Model
{
    public abstract class AbstractProduct
    {
        private string Name { get; }
        private string PackageType { get; }
        public int Weight { get; private set; }

        protected AbstractProduct(string name, string packageType, int weight)
        {
            Name = name;
            PackageType = packageType;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"[ProductName: {Name}, PackageType: {PackageType}, Weight: {Weight}]";
        }
    }
}
