using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario
{
    class Vehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int? Id { get; set; }

        public Vehicle (string brand, string model)
        {
            Brand = brand;
            Model = model;
        }

        public virtual string Print()
        {
            return $"Marca: {Brand}, Modello: {Model}";
        }
    }
}
