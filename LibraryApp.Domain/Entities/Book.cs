using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Entities
{
    public class Book: BaseEntity
    {
        
        public string? Title { get; private set; }
        public string? Author { get; private set; }
        public string? ISBN { get; private set; }
        public int AvailableCopies{ get; set; }
        public Book(string title, string author, string isbn, int availableCopies)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be null or empty.", nameof(title));
            }
            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentException("Author cannot be null or empty.", nameof(author));
            }
            if (string.IsNullOrWhiteSpace(isbn))
            {
                throw new ArgumentException("ISBN cannot be null or empty.", nameof(isbn));
            }
            if (availableCopies < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(availableCopies), "Available copies cannot be negative.");
            }
            this.Title = title;
            this.Author = author;
            this.ISBN = isbn;
            this.AvailableCopies = availableCopies;
        }

    }
}
