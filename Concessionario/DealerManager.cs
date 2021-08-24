using Concessionario.SecondMethodSqlRepository;
using Concessionario.SqlRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario
{
    class DealerManager
    {
        //internal static VehicleListRepository vr = new VehicleListRepository();
        //internal static MotorcycleListRepository mr = new MotorcycleListRepository();
        //internal static CarListRepository cr = new CarListRepository();
        //internal static BusListRepository br = new BusListRepository();

        //public static MotorcycleRepository mr = new MotorcycleRepository();
        public static MotorcycleSMRepository mr = new MotorcycleSMRepository();
        public static BusSMRepository br = new BusSMRepository();
        public static CarSMRepository cr = new CarSMRepository();
        public static VehicleRepository vr = new VehicleRepository();

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

        internal static void SellVehicle()
        {
            int tipoVeicolo;
            bool isInt;

            do
            {
                Console.WriteLine("Che veicolo vuoi acquistare?");
                Console.WriteLine("Premi 1 per acquistare una moto");
                Console.WriteLine("Premi 2 per acquistare un'auto");
                Console.WriteLine("Premi 3 per acquistare un pulmino");

                isInt = int.TryParse(Console.ReadLine(), out tipoVeicolo);

            } while (!isInt || tipoVeicolo <= 0 || tipoVeicolo >= 4);

            switch (tipoVeicolo)
            {
                case 1:
                    Motorcycle motorcycle = ScegliMoto();
                    mr.Delete(motorcycle);
                    break;
                case 2:
                    Car car = ScegliAuto();
                    cr.Delete(car);
                    break;
                case 3:
                    Bus bus = ScegliBus();
                    br.Delete(bus);
                    break;
            }
        }

        private static Bus ScegliBus()
        {
            List<Bus> buses = br.Fetch();

            int i = 1;
            foreach (var bus in buses)
            {
                Console.WriteLine($"Premi {i} per acquistare {bus.Print()}");
                i++;
            }

            bool isInt;
            int veicoloScelto;
            do
            {
                Console.WriteLine("Quale veicolo vuoi acquistare?");

                isInt = int.TryParse(Console.ReadLine(), out veicoloScelto);

            } while (!isInt || veicoloScelto <= 0 || veicoloScelto > buses.Count);

            return buses.ElementAt(veicoloScelto - 1);
        }

        private static Car ScegliAuto()
        {
            List<Car> cars = cr.Fetch();

            int i = 1;
            foreach (var car in cars)
            {
                Console.WriteLine($"Premi {i} per acquistare {car.Print()}");
                i++;
            }

            bool isInt;
            int veicoloScelto;
            do
            {
                Console.WriteLine("Quale veicolo vuoi acquistare?");

                isInt = int.TryParse(Console.ReadLine(), out veicoloScelto);

            } while (!isInt || veicoloScelto <= 0 || veicoloScelto > cars.Count);

            return cars.ElementAt(veicoloScelto - 1);
        }

        private static Motorcycle ScegliMoto()
        {
            List<Motorcycle> motocycles = mr.Fetch();

            int i = 1;
            foreach (var motocycle in motocycles)
            {
                Console.WriteLine($"Premi {i} per acquistare {motocycle.Print()}");
                i++;
            }

            bool isInt;
            int veicoloScelto;
            do
            {
                Console.WriteLine("Quale veicolo vuoi acquistare?");

                isInt = int.TryParse(Console.ReadLine(), out veicoloScelto);

            } while (!isInt || veicoloScelto <= 0 || veicoloScelto > motocycles.Count);

            return motocycles.ElementAt(veicoloScelto - 1);
        }
        internal static void InsertVehicles()
        {
            int veicoloScelto;
            bool isInt;

            do
            {
                Console.WriteLine("Che veicolo vuoi inserire?");
                Console.WriteLine("Premi 1 per inserire una nuova moto");
                Console.WriteLine("Premi 2 per inserire una nuova auto");
                Console.WriteLine("Premi 3 per inserire un nuovo pulmino");

                isInt = int.TryParse(Console.ReadLine(), out veicoloScelto);

            } while (!isInt || veicoloScelto <= 0 || veicoloScelto >= 4);

            switch (veicoloScelto)
            {
                case 1:
                    Motorcycle motorcycle = ChiediDatiMoto();
                    mr.Insert(motorcycle);
                    break;
                case 2:
                    Car car = ChiediDatiAuto();
                    cr.Insert(car);
                    break;
                case 3:
                    Bus bus = ChiediDatiBus();
                    br.Insert(bus);
                    break;
            }

        }
        private static Bus ChiediDatiBus()
        {
            Vehicle vehicle = ChiediDatiVeicolo();
            Bus bus = new Bus();
            bus.Brand = vehicle.Brand;
            bus.Model = vehicle.Model;

            int numeroPosti;
            bool isInt;
            do
            {
                Console.WriteLine("Inserisci il numero di posti");
                isInt = int.TryParse(Console.ReadLine(), out numeroPosti);
            } while (!isInt);
            bus.SeatsNumber = numeroPosti;

            return bus;
        }
        private static Car ChiediDatiAuto()
        {
            Vehicle vehicle = ChiediDatiVeicolo();
            Car car = new Car();
            car.Model = vehicle.Model;
            car.Brand = vehicle.Brand;

            int alimentazione;
            bool isInt;
            do
            {
                Console.WriteLine("Scegli un genere");
                foreach (var genere in Enum.GetValues(typeof(PowerSupply)))
                {
                    Console.WriteLine($"Premi {(int)genere + 1} per {(PowerSupply)genere}");
                }
                isInt = int.TryParse(Console.ReadLine(), out alimentazione);

            } while (!isInt || alimentazione <= 0 || alimentazione >= 4);

            car.Supply = (PowerSupply)(alimentazione - 1);

            int numeroPorte;
            do
            {
                Console.WriteLine("Inserisci il numero di porte");
                isInt = int.TryParse(Console.ReadLine(), out numeroPorte);
            } while (!isInt);

            car.DoorsNumber = numeroPorte;

            return car;
        }

        private static Motorcycle ChiediDatiMoto()
        {
            Vehicle vehicle = ChiediDatiVeicolo();

            Motorcycle motocycle = new Motorcycle();
            motocycle.Brand = vehicle.Brand;
            motocycle.Model = vehicle.Model;

            bool isInt;
            int annoProduzione;
            do
            {
                Console.WriteLine("Inserisci l'anno di produzione");

                isInt = int.TryParse(Console.ReadLine(), out annoProduzione);

            } while (!isInt);

            motocycle.ProductionYear = annoProduzione;

            return motocycle;
        }

        private static Vehicle ChiediDatiVeicolo()
        {
            Vehicle vehicle = new Vehicle();

            Console.WriteLine("Inserisci la marca");
            vehicle.Brand = Console.ReadLine();

            Console.WriteLine("Inserisci il modello");
            vehicle.Model = Console.ReadLine();

            return vehicle;
        }
    }
}
