using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario
{
    class MotorcycleListRepository : IDbManager<Motorcycle>
    {
        public static List<Motorcycle> motorcycles = new List<Motorcycle>
        {
            new Motorcycle("toyota","n1", 2013),
            new Motorcycle("kawasaki","greenK", 1997),
            new Motorcycle("harley","dd super", 1989),
            new Motorcycle("ducati","nXX", 2001),

        };

        public void Delete(Motorcycle t)
        {
            throw new NotImplementedException();
        }

        public List<Motorcycle> Fetch()
        {
            return motorcycles;
        }

        public Motorcycle Get()
        {
            throw new NotImplementedException();
        }

        public void Insert(Motorcycle mot)
        {
            var m = MotorcycleListRepository.motorcycles.Where(t => t.Brand == mot.Brand && t.Model == mot.Model && t.ProductionYear == mot.ProductionYear);

            if (m.Count() == 0)
            {
                motorcycles.Add(mot);
            }
            else Console.WriteLine("La moto che stai provando ad inserire esste già");

        }

        public void Update(Motorcycle t)
        {
            throw new NotImplementedException();
        }
    }
}
