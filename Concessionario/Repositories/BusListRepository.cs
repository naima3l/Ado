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
            new Bus("Opel","pulmino", 50, null),
            new Bus("Peugeut", "Pxx", 150, null),
            new Bus("Fiat", "Pulmino piccolino", 30, null),
            new Bus("Opel","pulmino più piccolo", 35, null)
        };
        
        public void Delete(Bus bus)
        {
            buses.Remove(bus);
        }

        public List<Bus> Fetch()
        {
            return buses;
        }

        public Bus GetById(int? id)
        {
            return buses.Find(b => b.Id == id);
        }

        public void Insert(Bus b)
        {
            buses.Add(b);
        }

        public void Update(Bus bus)
        {
            Delete(GetById(bus.Id));
            Insert(bus);
        }
    }
}
