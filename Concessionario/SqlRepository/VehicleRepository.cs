using Concessionario.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario.SqlRepository
{
    class VehicleRepository : IVehicleDbManager
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                                    "Initial Catalog = Magazzino;" +
                                    "Integrated Security = true;";

        public void Delete(Vehicle t)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> Fetch()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = "select Vehicle.Brand, Vehicle.Model, Vehicle.Id from Vehicle";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var brand = reader["Brand"];
                    var model = reader["Model"];
                    var id = (int)reader["Id"];

                    Vehicle vehicle = new Vehicle((string)brand, (string)model, id);

                    vehicles.Add(vehicle);
                }
            }
            return vehicles;
        }

        public Vehicle GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Vehicle vehicle)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into Vehicle values(@brand, @model)";

                command.Parameters.AddWithValue("@brand", vehicle.Brand);
                command.Parameters.AddWithValue("@model", vehicle.Model);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Vehicle t)
        {
            throw new NotImplementedException();
        }

        internal void DeleteById(int idVehicleToDelete)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from Vehicle where Id = @id";
                command.Parameters.AddWithValue("@id", idVehicleToDelete);

                command.ExecuteNonQuery();
            }
        }

        internal int GetId(Vehicle vehicle)
        {
            int idVehicle = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select Id from vehicle where Brand = @brand and Model = @model";
                command.Parameters.AddWithValue("@brand", vehicle.Brand);
                command.Parameters.AddWithValue("@model", vehicle.Model);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    idVehicle = (int)reader["Id"];
                }
            }

            return idVehicle;
        }
    }
}
