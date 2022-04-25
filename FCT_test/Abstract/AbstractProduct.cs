using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT_test.Model
{
    /// <summary>
    /// Абстрактный класс для продуктов, которые выпускает фабрика
    /// </summary>
    public abstract class AbstractProduct
    {
        public string Name { get; private set; }
        public string PackageType { get; private set; }
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
