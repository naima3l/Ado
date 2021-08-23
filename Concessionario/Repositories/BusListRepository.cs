using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario
{
    class BusListRepository : IDbManager<Bus>
    {
        public static List<Bus> buses = new List<Bus>()
        {
            new Bus("Opel","pulmino", 50),
            new Bus("Peugeut", "Pxx", 150),
            new Bus("Fiat", "Pulmino piccolino", 30),
            new Bus("Opel","pulmino più piccolo", 35)
        };
        
        public void Delete(Bus t)
        {
            throw new NotImplementedException();
        }

        public List<Bus> Fetch()
        {
            return buses;
        }

        public Bus Get()
        {
            throw new NotImplementedException();
        }

        public void Insert(Bus b)
        {
            var x = BusListRepository.buses.Where(t => t.Brand == b.Brand && t.Model == b.Model && t.SeatsNumber == b.SeatsNumber);

            if (x.Count() == 0)
            {
                buses.Add(b);
            }
            else Console.WriteLine("Il pulmino che stai provando ad inserire esiste già");
        }

        public void Update(Bus t)
        {
            throw new NotImplementedException();
        }
    }
}
