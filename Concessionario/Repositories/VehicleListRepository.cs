using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario
{
    class VehicleListRepository : IDbManager<Vehicle>
    {
        static List<Vehicle> vehicles = new List<Vehicle>();

        internal static MotorcycleListRepository mr = new MotorcycleListRepository();
        internal static CarListRepository cr = new CarListRepository();
        internal static BusListRepository br = new BusListRepository();

        public void Delete(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> Fetch()
        {
            List<Motorcycle> motorcycles = mr.Fetch();
            List<Car> cars = cr.Fetch();
            List<Bus> buses = br.Fetch();

            vehicles.AddRange(motorcycles);
            vehicles.AddRange(cars);
            vehicles.AddRange(buses);

            return vehicles;
        }

        public Vehicle Get()
        {
            throw new NotImplementedException();
        }

        public void Insert(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public void Update(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
