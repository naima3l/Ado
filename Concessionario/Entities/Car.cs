using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario
{
    class Car : Vehicle
    {
        public PowerSupply Supply { get; set; }
        public int DoorsNumber { get; set; }

        public Car(string brand, string model, PowerSupply supply, int doorsNumber)
            : base(brand, model)
        {
            Supply = supply;
            DoorsNumber = doorsNumber;
        }

        public override string Print()
        {
            return $"Auto -> {base.Print()}, Alimentazione: {Supply}, Numero porte: {DoorsNumber}";
        }
    }

    enum PowerSupply
    {
        Diesel,
        Gas,
        Electric
    }
}
