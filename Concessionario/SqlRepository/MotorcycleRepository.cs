﻿using Concessionario.Interfaces;
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
        static VehicleRepository vehicleRepository = new VehicleRepository();

        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                                    "Initial Catalog = Magazzino;" +
                                    "Integrated Security = true;";
        public void Delete(Motorcycle motorcycle)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                int idVehicleToDelete = GetIdVehicle(motorcycle.Id);

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = "delete from Motorcycle where IdMotorcycle = @id";
                command.Parameters.AddWithValue("@id", motorcycle.Id);

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

                command.CommandText = "select * from Motorcycle where IdMotorcycle = @id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    idVehicleToDelete = (int)reader["IdVehicle"];
                }

            }
            return idVehicleToDelete;
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
                command.CommandText = "select Vehicle.Brand, Vehicle.Model, Motorcycle.IdMotorcycle, Motorcycle.ProductionYear from Vehicle join Motorcycle on Vehicle.Id = Motorcycle.IdVehicle";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var brand = reader["Brand"];
                    var model = reader["Model"];
                    var year = (int)reader["ProductionYear"];
                    var id = (int)reader["IdMotorcycle"];

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
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = "select Vehicle.Brand, Vehicle.Model, Motorcycle.Id, Motorcycle.ProductionYear from Vehicle join Motorcycle on Vehicle.Id = Motorcycle.IdVehicle where Motorcycle.Id = @id";
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

                Vehicle vehicle = new Vehicle(motorcycle.Brand, motorcycle.Model, null);
                vehicleRepository.Insert(vehicle);
                int idVehicle = vehicleRepository.GetId(vehicle);

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into Motorcycle values (@idVehicle, @year)";
                command.Parameters.AddWithValue("@year", motorcycle.ProductionYear);
                command.Parameters.AddWithValue("@idVehicle", idVehicle);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Motorcycle motorcycle)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                int idVehicleToUpdate = GetIdVehicle(motorcycle.Id);
                Vehicle vehicle = new Vehicle(motorcycle.Brand, motorcycle.Model, idVehicleToUpdate);

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = "update Motorcycle set ProductionYear = @year where Id = @id";
                command.Parameters.AddWithValue("@year", motorcycle.ProductionYear);
                command.Parameters.AddWithValue("@id", motorcycle.Id);

                command.ExecuteNonQuery();

                vehicleRepository.Update(vehicle);
            }
        }
    }
}
