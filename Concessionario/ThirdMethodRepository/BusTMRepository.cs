using Concessionario.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario.ThirdMethodRepository
{
    class BusTMRepository : IBusDbManager
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                                    "Initial Catalog = Magazzino3;" +
                                    "Integrated Security = true;";
        public void Delete(Bus bus)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = "delete from Vehicle where Id = @id";
                command.Parameters.AddWithValue("@id", bus.Id);

                command.ExecuteNonQuery();

            }
        }

        public List<Bus> Fetch()
        {
            List<Bus> buses = new List<Bus>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = "select * from Vehicle where Discriminator = 'Bus'";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var brand = reader["Brand"];
                    var model = reader["Model"];
                    var seats = (int)reader["SeatsNumber"];
                    var id = (int)reader["Id"];

                    Bus bus = new Bus((string)brand, (string)model, seats, id);

                    buses.Add(bus);
                }
            }
            return buses;
        }

        public Bus GetById(int? id)
        {
            Bus bus = new Bus();

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
                    var seats = reader["SeatsNumber"];

                    bus = new Bus((string)brand, (string)model, (int)seats, id);
                }
            }
            return bus;
        }

        public void Insert(Bus bus)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into Vehicle values (@brand,@model,@year,@supply,@doors,@seats,@discriminator)";
                command.Parameters.AddWithValue("@brand", bus.Brand);
                command.Parameters.AddWithValue("@model", bus.Model);
                command.Parameters.AddWithValue("@year", DBNull.Value);
                command.Parameters.AddWithValue("@supply", DBNull.Value);
                command.Parameters.AddWithValue("@doors", DBNull.Value);
                command.Parameters.AddWithValue("@seats", bus.SeatsNumber);
                command.Parameters.AddWithValue("@discriminator", "Bus");

                command.ExecuteNonQuery();
            }
        }

        public void Update(Bus bus)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update Vehicle set Brand = @brand, Model = @model, ProductionYear = @year, Supply = @supply, DoorsNumber = @doors, SeatsNumber = @seats, Discriminator = @discriminator  where Id = @id";
                command.Parameters.AddWithValue("@brand", bus.Brand);
                command.Parameters.AddWithValue("@model", bus.Model);
                command.Parameters.AddWithValue("@year", DBNull.Value);
                command.Parameters.AddWithValue("@supply", DBNull.Value);
                command.Parameters.AddWithValue("@doors", DBNull.Value);
                command.Parameters.AddWithValue("@seats", bus.SeatsNumber);
                command.Parameters.AddWithValue("@discriminator", "Bus");
                command.Parameters.AddWithValue("Id", bus.Id);

                command.ExecuteNonQuery();
            }
        }
    }
}
