using Concessionario.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario.SqlRepository
{
    class BusRepository : IBusDbManager
    {
        static VehicleRepository vehicleRepository = new VehicleRepository();

        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                                    "Initial Catalog = Magazzino;" +
                                    "Integrated Security = true;";

        public List<Bus> Fetch()
        {
            List<Bus> buses = new List<Bus>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = "select Vehicle.Brand, Vehicle.Model, Bus.IdBus, Bus.SeatsNumber from Vehicle join Bus on Vehicle.Id = Bus.IdVehicle";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var brand = reader["Brand"];
                    var model = reader["Model"];
                    var seats = (int)reader["SeatsNumber"];
                    var id = (int)reader["IdBus"];

                    Bus bus = new Bus((string)brand, (string)model, seats, id);

                    buses.Add(bus);
                }
            }
            return buses;
        }

        public Bus GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Bus bus)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Vehicle vehicle = new Vehicle(bus.Brand, bus.Model, null);
                vehicleRepository.Insert(vehicle);
                int idVehicle = vehicleRepository.GetId(vehicle);

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into Bus values (@seats,idVehicle)";
                command.Parameters.AddWithValue("@seats", bus.SeatsNumber);
                command.Parameters.AddWithValue("@idVehicle", idVehicle);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(Bus bus)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                int idVehicleToDelete = GetIdVehicle(bus.Id);

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = "delete from Bus where IdBus = @id";
                command.Parameters.AddWithValue("@id", bus.Id);

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

                command.CommandText = "select * from Bus where IdBus = @id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    idVehicleToDelete = (int)reader["IdVehicle"];
                }

            }
            return idVehicleToDelete;
        }

        public void Update(Bus t)
        {
            throw new NotImplementedException();
        }
    }
}
