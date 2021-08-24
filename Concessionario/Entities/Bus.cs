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

        public Bus(string brand, string model, int seatsNumber, int? id)
            : base(brand, model, id)
        {
            SeatsNumber = seatsNumber;
        }

        public Bus()
        {
        }

        public override string Print()
        {
            return $"Pulmino -> {base.Print()}, Numero Posti: {SeatsNumber}";
        }
    }
}
