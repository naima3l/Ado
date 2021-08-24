using Concessionario.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario.SqlRepository
{
    class MotorcycleRepository : IMotorcycleDbManager
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                                    "Initial Catalog = Magazzino;" +
                                    "Integrated Security = true;";
        public void Delete(Motorcycle motorcycle)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                int idVehichleToDelete =GetIdVehicle(motorcycle.Id);

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;

                command.CommandText = "delete from Motorcycle where Id = @id";
                command.Parameters.AddWithValue("@id", motorcycle.Id);

                command.ExecuteNonQuery();
            }
        }

        private int GetIdVehicle(int? id)
        {
            int idVehichleToDelete = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;

                command.CommandText = "Select * from Motorcycle where IdMotorcycle = @id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    idVehichleToDelete = (int)reader["IdVehicle"];
                }
            }
            return idVehichleToDelete;
        }

        public List<Motorcycle> Fetch()
        {
            List<Motorcycle> motorcycles = new List<Motorcycle>();

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;

                command.CommandText = "SELECT Vehicle.Brand, Vehicle.Model , Motorcycle.IdMotorcycle , Motorcycle.ProductionYear " +
                                        "FROM dbo.Vehicle JOIN dbo.Motorcycle ON Vehicle.Id = Motorcycle.IdVehichle";

                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    var brand = reader["Brand"];
                    var model = reader["Model"];
                    var year = reader["ProductionYear"];
                    var id = reader["IdMotorcycle"];

                    Motorcycle motorcycle = new Motorcycle((string)brand, (string)model, (int)id, (int)year);

                    motorcycles.Add(motorcycle);
                }
            }
            return motorcycles;
        }

        public Motorcycle GetById()
        {
            throw new NotImplementedException();
        }

        public void Insert(Motorcycle t)
        {
            throw new NotImplementedException();
        }

        public void Update(Motorcycle t)
        {
            throw new NotImplementedException();
        }
    }
}
