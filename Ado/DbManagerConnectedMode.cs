using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado
{
    class DbManagerConnectedMode
    {
        //Server -> (localdb)\MSSQLLocalDB
        //server mio -> (localdb)\mssqllocaldb
        // Nome del database -> DemoAdo
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                                    "Initial Catalog = DemoAdo;" +
                                    "Integrated Security = true;";
        public void Fetch()
        {
            //creo la connessione
            SqlConnection connection = new SqlConnection(connectionString);
            
            //apro la connessione
            connection.Open();

            //definisco i comandi
            SqlCommand command = new SqlCommand();

            //definisco il tipo
            command.CommandType = System.Data.CommandType.Text;

            //associo il comando alla connessione
            command.Connection = connection;

            //definisco la query
            command.CommandText = "select * from dbo.Book";

            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read()) //legge tutte le righe
            { 
                //per ogni riga leggo le colonne attraverso il nome
                var title = reader["Title"];
                var author = reader["Author"];
                var price = reader["Price"];
                var id = reader["Id"];

                Console.WriteLine($"{title}, {author}, {price}, {id}");

                //per ogni riga leggo le colonne attraverso la posizione

                var title2 = reader[0];
                var author2 = reader[1];


            }

            connection.Close();
        }

        public void GetById(int id)
        {
            using(SqlConnection connection = new SqlConnection(connectionString)) //se uso usyng non ho bisogno di chiudere la connessione
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;

                //ai parametri posso dare il nome che voglio preceduto da  @
                command.CommandText = "select * from dbo.Book where Id = @Id";
                //se ho dei parametri vado a definirli
                command.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    var title = reader["Title"];
                    var author = reader["Author"];
                    var price = reader["Price"];
                    var id2 = reader["Id"];

                    Console.WriteLine($"{title}, {author}, {price}, {id}");
                }
            }
        }

        public void Insert(string title, string author, decimal price)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;

                command.CommandText = "insert into dbo.Book values (@title, @author, @price)";
                
                command.Parameters.AddWithValue("@title" , title);
                command.Parameters.AddWithValue("@author", author);
                command.Parameters.AddWithValue("@price", price);

                //non mi aspetto nessuna riga di ritorno(non leggo nulla)
                command.ExecuteNonQuery();


            }
        }

        public void DeleteById(int id)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;

                command.CommandText = "delete dbo.Book where Id = @id";

                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Book book)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;

                command.CommandText = "update dbo.Book set Title = @title, Author = @author, Price = @price where Id = @id";

                command.Parameters.AddWithValue("@id", book.Id);
                command.Parameters.AddWithValue("@title", book.Title);
                command.Parameters.AddWithValue("@author", book.Author);
                command.Parameters.AddWithValue("@price", book.Price);

                command.ExecuteNonQuery();
            }
        }

        public void Count()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;

                command.CommandText = "select count(*) from dbo.Book";

                int numBooks = (int)command.ExecuteScalar();
            }
        }

        public List<Book> FetchToCount()
        {
            List<Book> books = new List<Book>();

            //creo la connessione
            SqlConnection connection = new SqlConnection(connectionString);

            //apro la connessione
            connection.Open();

            //definisco i comandi
            SqlCommand command = new SqlCommand();

            //definisco il tipo
            command.CommandType = System.Data.CommandType.Text;

            //associo il comando alla connessione
            command.Connection = connection;

            //definisco la query
            command.CommandText = "select * from dbo.Book";

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) //legge tutte le righe
            {
                //per ogni riga leggo le colonne attraverso il nome
                var title = reader["Title"];
                var author = reader["Author"];
                var price = reader["Price"];
                var id = reader["Id"];

                Book book = new Book((int)id, (string)title, (string)author, (decimal)price);

                books.Add(book);
            }

            return books;
        }


        public void CountWithCrud()
        {
            List<Book> books = FetchToCount();
            int numBooks = books.Count();
        }
    }
}
