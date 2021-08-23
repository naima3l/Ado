using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario
{
    class CarListRepository : IDbManager<Car>
    {
        public static List<Car> cars = new List<Car>
        {
           new Car("Fiat", "500x", PowerSupply.Diesel, 5),
           new Car("Ford", "Fiesta", PowerSupply.Gas, 5),
           new Car("Tesla", "tt", PowerSupply.Electric, 3),
           new Car("Fiat", "Punto", PowerSupply.Diesel, 3)

        };
        public void Delete(Car t)
        {
            throw new NotImplementedException();
        }

        public List<Car> Fetch()
        {
            return cars;
        }

        public Car Get()
        {
            throw new NotImplementedException();
        }

        public void Insert(Car car)
        {
            var c = CarListRepository.cars.Where(t => t.Brand == car.Brand && t.Model == car.Model && t.Supply == car.Supply);

            if (c.Count() == 0)
            {
                cars.Add(car);
            }
            else Console.WriteLine("L'auto che stai provando ad inserire esste già");
        }

        public void Update(Car t)
        {
            throw new NotImplementedException();
        }
    }
}
