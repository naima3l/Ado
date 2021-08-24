using Concessionario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario
{
    class MotorcycleListRepository : IMotorcycleDbManager
    {
        public static List<Motorcycle> motorcycles = new List<Motorcycle>
        {
            new Motorcycle("toyota","n1", 2013, null),
            new Motorcycle("kawasaki","greenK", 1997, null),
            new Motorcycle("harley","dd super", 1989, null),
            new Motorcycle("ducati","nXX", 2001, null),

        };

        public void Delete(Motorcycle motorcycle)
        {
            motorcycles.Remove(motorcycle);
        }

        public List<Motorcycle> Fetch()
        {
            return motorcycles;
        }

        public Motorcycle GetById(int? id)
        {
            return motorcycles.Find(m => m.Id == id);

        }

        public void Insert(Motorcycle motorcycle)
        {
            motorcycles.Add(motorcycle);
        }

        public void Update(Motorcycle motorcycle)
        {
            // moto vecchia, con i vecchi parametri
            var motoDaCancellare = GetById(motorcycle.Id);

            Delete(motoDaCancellare);

            //Moto con i nuovi parametri
            Insert(motorcycle);
        }

    }
}
