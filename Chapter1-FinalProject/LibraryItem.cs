using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class LibraryItem
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }

        public LibraryItem(string title, string author, int publicationYear)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
        }
        
    }
    
    public class Book : LibraryItem
    {
        internal int Quantity;

        public Book(string title, string author, int publicationYear) : base(title, author, publicationYear)
        {
        }
    }

    public class AudioBook : LibraryItem
    {
        public AudioBook(string title, string author, int publicationYear) : base(title, author, publicationYear)
        {
        }
    }

    public class Journal : LibraryItem
    {
        public string Type { get; set; }

        public Journal(string title, string author, int publicationYear, string type) : base(title, author, publicationYear)
        {
            Type = type;
        }
    }
}
