using Concessionario.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario.ThirdMethodRepository
{
    class CarTMRepository : ICarDbManager
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                                   "Initial Catalog = Magazzino3;" +
                                   "Integrated Security = true;";
        public void Delete(Car car)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = "delete from Vehicle where Id = @id";
                command.Parameters.AddWithValue("@id", car.Id);

                command.ExecuteNonQuery();

            }
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
                command.CommandText = "select * from Vehicle where Discriminator = 'Car'";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var brand = reader["Brand"];
                    var model = reader["Model"];
                    var supply = (int)reader["Supply"];
                    var doors = (int)reader["DoorsNumber"];
                    var id = (int)reader["Id"];

                    Car car = new Car((string)brand, (string)model, (PowerSupply)supply, doors, id);

                    cars.Add(car);
                }
            }
            return cars;
        }

        public Car GetById(int? id)
        {
            Car car = new Car();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Vehicle where Id=@id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var brand = reader["Brand"];
                    var model = reader["Model"];
                    var supply = (int)reader["Supply"];
                    var doors = reader["DoorsNumber"];

                    car = new Car((string)brand, (string)model, (PowerSupply)supply, (int)doors, id);
                }
            }
            return car;
        }

        public void Insert(Car car)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into Vehicle values (@brand,@model,@year,@supply,@doors,@seats,@discriminator)";
                command.Parameters.AddWithValue("@brand", car.Brand);
                command.Parameters.AddWithValue("@model", car.Model);
                command.Parameters.AddWithValue("@year", DBNull.Value);
                command.Parameters.AddWithValue("@supply", (int)car.Supply);
                command.Parameters.AddWithValue("@doors", car.DoorsNumber);
                command.Parameters.AddWithValue("@seats", DBNull.Value);
                command.Parameters.AddWithValue("@discriminator", "Car");

                command.ExecuteNonQuery();
            }
        }

        public void Update(Car car)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update Vehicle set Brand = @brand, Model = @model, ProductionYear = @year, Supply = @supply, DoorsNumber = @doors, SeatsNumber = @seats, Discriminator = @discriminator  where Id = @id";
                command.Parameters.AddWithValue("@brand", car.Brand);
                command.Parameters.AddWithValue("@model", car.Model);
                command.Parameters.AddWithValue("@year", DBNull.Value);
                command.Parameters.AddWithValue("@supply", (int)car.Supply);
                command.Parameters.AddWithValue("@doors", car.DoorsNumber);
                command.Parameters.AddWithValue("@seats", DBNull.Value);
                command.Parameters.AddWithValue("@discriminator", "Car");
                command.Parameters.AddWithValue("Id", car.Id);

                command.ExecuteNonQuery();
            }
        }
    }
}
