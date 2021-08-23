using System;

namespace Concessionario
{
    internal class Menu
    {
        internal static VehicleListRepository vr = new VehicleListRepository();
        internal static MotorcycleListRepository mr = new MotorcycleListRepository();
        internal static CarListRepository cr = new CarListRepository();
        internal static BusListRepository br = new BusListRepository();

        internal static void Start()
        {
            bool continuare = true;
            int choice;
            do
            {
                Console.WriteLine("Premi 1 per vedere tutti i veicoli \nPremi 2 per vedere tutte le moto \nPremi 3 per vedere tutte le auto \nPremi 4 per vedere tutti i pulmini \nPremi 5 per inserire un nuovo veicolo \nPremi 6 per vendere un veicolo \nPremi 0 per uscire");

                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 6)
                {
                    Console.WriteLine("Scelta non valida! Riprova.");
                }

                switch (choice)
                {
                    case 1:
                        DealerManager.ShowVehicles();
                        break;
                    case 2:
                        DealerManager.ShowMotorcycles();
                        break;
                    case 3:
                        DealerManager.ShowCars();
                        break;
                    case 4:
                        DealerManager.ShowBuses();
                        break;
                    case 5:
                        break;
                    case 6:
                        SellVehicle();
                        break;
                    case 0:
                        Console.WriteLine("Ciao ciao!");
                        continuare = false;
                        break;
                }
            } while (continuare);
        }

        private static void SellVehicle()
        {
            Console.WriteLine("Quale veicolo vuoi vendere?");
            DealerManager.ShowVehicles();
            Console.WriteLine("\nInserisci la marca");
            string brand = Console.ReadLine();
            Console.WriteLine("Inserisci il modello\n");
            string model = Console.ReadLine();
            DealerManager.SellVehicleByBrandAndModel(brand,model);
        }
    }
}