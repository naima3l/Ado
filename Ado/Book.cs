﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado
{
    class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }

        public Book(int id, string title, string author, decimal price)
        {
            Title = title;
            Author = author;
            Price = price;
            Id = id;
        }
    }
}
