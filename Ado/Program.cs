using System;

namespace Ado
{
    class Program
    {
        static void Main(string[] args)
        {
            DbManagerConnectedMode dbm = new DbManagerConnectedMode();

            dbm.Count();

            //Book book = new Book(8, "Le meta", "Ciccio", 18);

            ////Modifica l'autore (Console.WriteLine)
            //string author = "Kafka"; //prendo in ingresso dalla readline"

            //book.Author = author;

            //dbm.Update(book);

            //dbm.DeleteById(7);

            //dbm.Insert("La meta", "Kafka", 16);

            //dbm.GetById(2);

            //dbm.Fetch();
        }
    }
}
