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
           new Car("Fiat", "500x", PowerSupply.Diesel, 5, null),
           new Car("Ford", "Fiesta", PowerSupply.Gas, 5, null),
           new Car("Tesla", "tt", PowerSupply.Electric, 3, null),
           new Car("Fiat", "Punto", PowerSupply.Diesel, 3, null)

        };
        public void Delete(Car car)
        {
            cars.Remove(car);
        }

        public List<Car> Fetch()
        {
            return cars;
        }

        public Car GetById(int? id)
        {
            return cars.Find(c => c.Id == id);
        }

        public void Insert(Car car)
        {
            cars.Add(car);
        }

        public void Update(Car car)
        {
            Delete(GetById(car.Id));
            Insert(car);
        }
    }
