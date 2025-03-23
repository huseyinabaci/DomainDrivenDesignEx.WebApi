using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Book
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public decimal Price { get; private set; }

        public Book(string title, decimal price)
        {
            Title = title;
            Price = price;
        }
    }
}
