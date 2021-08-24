using Concessionario.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario.SqlRepository
{
    class CarRepository : ICarDbManager
    {
        static VehicleRepository vehicleRepository = new VehicleRepository();

        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                                    "Initial Catalog = Magazzino;" +
                                    "Integrated Security = true;";
        public void Delete(Car car)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                int idVehicleToDelete = GetIdVehicle(car.Id);

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = "delete from Car where IdCar = @id";
                command.Parameters.AddWithValue("@id", car.Id);

                command.ExecuteNonQuery();

                vehicleRepository.DeleteById(idVehicleToDelete);

            }
        }

        private int GetIdVehicle(int? id)
        {
            int idVehicleToDelete = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;

                command.CommandText = "select * from Car where IdCar = @id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    idVehicleToDelete = (int)reader["IdVehicle"];
                }

            }
            return idVehicleToDelete;
        }

        public List<Car> Fetch()
        {
            List<Car> cars = new List<Car>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = "select Vehicle.Brand, Vehicle.Model, Car.IdCar, Car.DoorsNumber, Car.Supply from Vehicle join Car on Vehicle.Id = Car.IdVehicle";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var brand = reader["Brand"];
                    var model = reader["Model"];
                    var supply = (int)reader["Supply"];
                    var doors = (int)reader["DoorsNumber"];
                    var id = (int)reader["IdCar"];

                    Car car = new Car((string)brand, (string)model, (PowerSupply)supply, doors, id);

                    cars.Add(car);
                }
            }
            return cars;
        }

        public Car GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Car car)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Vehicle vehicle = new Vehicle(car.Brand, car.Model, null);
                vehicleRepository.Insert(vehicle);
                int idVehicle = vehicleRepository.GetId(vehicle);

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into Car values (@doors, @supply,idVehicle)";
                command.Parameters.AddWithValue("@doors",car.DoorsNumber);
                command.Parameters.AddWithValue("@supply", (int)car.Supply);
                command.Parameters.AddWithValue("@idVehicle", idVehicle);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Car t)
        {
            throw new NotImplementedException();
        }
    }
}
