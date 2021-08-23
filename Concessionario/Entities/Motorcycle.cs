using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario
{
    class Motorcycle : Vehicle
    {
        public int ProductionYear { get; set; }

        public Motorcycle(string brand, string model, int productionYear)
            :base(brand, model)
        {
            ProductionYear = productionYear;
        }

        public override string Print()
        {
            return $"Moto -> {base.Print()}, Anno di produzione: {ProductionYear}";
        }
    }

}
