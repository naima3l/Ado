using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario
{
    class Bus : Vehicle
    {
        public int SeatsNumber { get; set; }

        public Bus(string brand, string model, int seatsNumber)
            : base(brand, model)
        {
            SeatsNumber = seatsNumber;
        }

        public override string Print()
        {
            return $"Pulmino -> {base.Print()}, Numero Posti: {SeatsNumber}";
        }
    }
}
