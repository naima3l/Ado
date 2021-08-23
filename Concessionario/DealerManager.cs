using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario
{
    class DealerManager
    {
        internal static VehicleListRepository vr = new VehicleListRepository();
        internal static MotorcycleListRepository mr = new MotorcycleListRepository();
        internal static CarListRepository cr = new CarListRepository();
        internal static BusListRepository br = new BusListRepository();
        internal static void ShowVehicles()
        {
            List<Vehicle> vehicles = vr.Fetch();

            foreach(var x in vehicles)
            {
                Console.WriteLine(x.Print());
            }
        }

        internal static void ShowMotorcycles()
        {
            List<Motorcycle> motorcycles = mr.Fetch();

            foreach (var x in motorcycles)
            {
                Console.WriteLine(x.Print());
            }
        }

        internal static void ShowCars()
        {
            List<Car> cars = cr.Fetch();

            foreach (var x in cars)
            {
                Console.WriteLine(x.Print());
            }
        }

        internal static void ShowBuses()
        {
            List<Bus> buses = br.Fetch();

            foreach (var x in buses)
            {
                Console.WriteLine(x.Print());
            }
        }

        internal static void SellVehicleByBrandAndModel(string brand, string model)
        {
            
        }
    }
}
