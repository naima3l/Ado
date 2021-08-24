using Concessionario.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario.SecondMethodSqlRepository
{
    class MotorcycleSMRepository : IMotorcycleDbManager
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                                    "Initial Catalog = Magazzino2;" +
                                    "Integrated Security = true;";
        public void Delete(Motorcycle motorcycle)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = "delete from Motorcycle where Id = @id";
                command.Parameters.AddWithValue("@id", motorcycle.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<Motorcycle> Fetch()
        {
            List<Motorcycle> motorcycles = new List<Motorcycle>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = "select * from Motorcycle";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var brand = reader["Brand"];
                    var model = reader["Model"];
                    var year = (int)reader["ProductionYear"];
                    var id = (int)reader["Id"];

                    Motorcycle motorcycle = new Motorcycle((string)brand, (string)model, year, id);

                    motorcycles.Add(motorcycle);
                }
            }
            return motorcycles;
        }

        public Motorcycle GetById(int? id)
        {
            Motorcycle motorcycle = new Motorcycle();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Motorcycle where Id=@id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var brand = reader["Brand"];
                    var model = reader["Model"];
                    var year = (int)reader["ProductionYear"];

                 motorcycle = new Motorcycle((string)brand, (string)model, year, id);
                }
            }
            return motorcycle;
        }

        public void Insert(Motorcycle motorcycle)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into Motorcycle values (@brand,@model,@year)";
                command.Parameters.AddWithValue("@brand", motorcycle.Brand);
                command.Parameters.AddWithValue("@model", motorcycle.Model);
                command.Parameters.AddWithValue("@year", motorcycle.ProductionYear);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Motorcycle motorcycle)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update Motorcycle set Brand = @brand, Model = @model, ProductionYear = @year where Id = @id";
                command.Parameters.AddWithValue("@brand", motorcycle.Brand);
                command.Parameters.AddWithValue("@model", motorcycle.Model);
                command.Parameters.AddWithValue("@year", motorcycle.ProductionYear);
                command.Parameters.AddWithValue("Id", motorcycle.Id);

                command.ExecuteNonQuery();
            }
        }
    }
}
