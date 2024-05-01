using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    class Program
    {
        private static string username = "rustam";
        private static string password = "library123";
        private static int maxLoginAttempts = 5;
        private static Library library = new Library();
        static void Main(string[] args)
        {
            int loginAttempts = 0;
            bool isLoggedIn = false;

            while (!isLoggedIn && loginAttempts < maxLoginAttempts)
            {
                Console.Write("Username: ");
                string enteredUsername = Console.ReadLine();
                Console.Write("Password: ");
                string enteredPassword = Console.ReadLine();

                if (enteredUsername == username && enteredPassword == password)
                {
                    isLoggedIn = true;
                    Console.WriteLine("Login successful!");
                    DisplayMenu();
                }
                else
                {
                    Console.WriteLine("Invalid username or password. Please try again.");
                    loginAttempts++;
                }
            }

            if (loginAttempts >= maxLoginAttempts)
            {
                Console.WriteLine("Maximum login attempts reached. Exiting program.");
            }
        }       
        static void DisplayMenu()
        {
            
                bool quit = false;

                while (!quit)
                {
                Console.WriteLine("\nLibrary Management System Menu:");
                Console.WriteLine("1. View Library Elements");
                Console.WriteLine("2. Add Library Element");
                Console.WriteLine("3. Rent Element to Student");
                Console.WriteLine("4. Search Library");
                Console.WriteLine("5. Quit");

                Console.Write("\nEnter your choice (1-5): ");
                    string choice = Console.ReadLine();
                    Thread.Sleep(300);
                    Console.Clear();
                switch (choice)
                    {
                        case "1":
                            ViewLibraryElements();
                            break;
                        case "2":
                            AddLibraryElement();
                            break;
                        case "3":
                            RentElement();
                            break;
                        case "4":
                            SearchLibrary();
                            break;
                        case "5":
                            quit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }          
        }
        //view item area
        static void ViewLibraryElements()
        {
            
            bool quit = false;

            while (!quit)
            {
                Console.WriteLine("\nView Library Elements:");
                Console.WriteLine("1. Books");
                Console.WriteLine("2. Audio Books");
                Console.WriteLine("3. Journals");
                Console.WriteLine("4. Quit");

                Console.Write("\nEnter your choice (1-4): ");
                string choice = Console.ReadLine();
                Thread.Sleep(300);
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        DisplayBooks();
                        break;
                    case "2":
                        DisplayAudioBooks();
                        break;
                    case "3":
                        DisplayJournals();
                        break;
                    case "4":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        static void DisplayBooks()
        {
            Console.WriteLine("\nBooks:");

            Book[] books = library.Books;

            if (books != null && books.Length > 0)
            {
                for (int i = 0; i < books.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {books[i].Title} by {books[i].Author}, {books[i].PublicationYear}");
                }
            }
            else
            {
                Console.WriteLine("There is no book yet");
            }
        }
        static void DisplayAudioBooks()
        {
            Console.WriteLine("\nAudio Books:");

            
            AudioBook[] books = library.AudioBooks;

            if (books != null)
            {
                for (int i = 0; i < books.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {books[i].Title} by {books[i].Author}, {books[i].PublicationYear}");
                }
            }
            else
            {
                Console.WriteLine("There is no book yet");
            }
        }
        static void DisplayJournals()
        {
            Console.WriteLine("\nJournals:");

           
            Journal[] books = library.Journals;

            if (books != null)
            {
                for (int i = 0; i < books.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {books[i].Title} by {books[i].Author}, {books[i].PublicationYear}");
                }
            }
            else
            {
                Console.WriteLine("There is no book yet");
            }
        }
        //add item area
        static void AddLibraryElement()
        {
            bool quit = false;

            while (!quit)
            {
                Console.WriteLine("\nView Library Elements:");
                Console.WriteLine("1.Add Books");
                Console.WriteLine("2.Add Audio Books");
                Console.WriteLine("3.Add Journals");
                Console.WriteLine("4.Quit");

                Console.Write("\nEnter your choice (1-4): ");
                string choice = Console.ReadLine();
                Thread.Sleep(1000);
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        AddBooks();
                        break;
                    case "2":
                        AddAudioBooks();
                        break;
                    case "3":
                        AddJournals();
                        break;
                    case "4":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        static void AddBooks()
        {
            Console.WriteLine("\nAdd Books:");

            Console.Write("Enter the title of the book: ");
            string title = Console.ReadLine();
            Console.Write("Enter the author of the book: ");
            string author = Console.ReadLine();
            Console.Write("Enter the publication year of the book: ");
            int publicationYear;
            while (!int.TryParse(Console.ReadLine(), out publicationYear))
            {
                Console.WriteLine("Please enter a valid year.");
                Console.Write("Enter the publication year of the book: ");
            }

            
            Book newBook = new Book(title, author, publicationYear);

            
            List<Book> bookList = new List<Book>(library.Books ?? new Book[0]);
            bookList.Add(newBook);
            library.Books = bookList.ToArray();

            Console.WriteLine("Book added successfully!");
        }
        static void AddAudioBooks()
        {
            Console.WriteLine("\nAdd Audio Books:");

            Console.Write("Enter the title of the book: ");
            string title = Console.ReadLine();
            Console.Write("Enter the author of the book: ");
            string author = Console.ReadLine();
            Console.Write("Enter the publication year of the book: ");
            int publicationYear;
            while (!int.TryParse(Console.ReadLine(), out publicationYear))
            {
                Console.WriteLine("Please enter a valid year.");
                Console.Write("Enter the publication year of the book: ");
            }

           
            AudioBook newAudioBook = new AudioBook(title, author, publicationYear);

            
            List<AudioBook> audioBookList = new List<AudioBook>(library.AudioBooks ?? new AudioBook[0]);
            audioBookList.Add(newAudioBook);
            library.AudioBooks = audioBookList.ToArray();

            Console.WriteLine("Audio book added successfully!");
        }
        static void AddJournals()
        {
            Console.WriteLine("\nAdd Journals:");

            Console.Write("Enter the title of the journal: ");
            string title = Console.ReadLine();
            Console.Write("Enter the author of the journal: ");
            string author = Console.ReadLine();
            Console.Write("Enter the publication year of the journal: ");
            int publicationYear;
            while (!int.TryParse(Console.ReadLine(), out publicationYear))
            {
                Console.WriteLine("Please enter a valid year.");
                Console.Write("Enter the publication year of the journal: ");
            }
            Console.Write("Enter the journal name of the book: ");
            string journal = Console.ReadLine();
            

            Journal newJournal = new Journal(title, author, publicationYear,journal);


            List<Journal> journalList = new List<Journal>(library.Journals ?? new Journal[0]);
            journalList.Add(newJournal);
            library.Journals = journalList.ToArray();

            Console.WriteLine("Journal added successfully!");
        }
        //rent item area
        static void RentElement()
        {
            bool quit = false;

            while (!quit)
            {
                Console.WriteLine("\nRent Element to Student:");
                Console.WriteLine("1. Rent Books");
                Console.WriteLine("2. Rent Audio Books");
                Console.WriteLine("3. Rent Journals");
                Console.WriteLine("4. Quit");

                Console.Write("\nEnter your choice (1-4): ");
                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        RentBook();
                        break;
                    case "2":
                        RentAudioBook();
                        break;
                    case "3":
                        RentJournal();
                        break;
                    case "4":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        static void RentBook()
        {
            Console.WriteLine("\nRent Books:");
            DisplayBooks();

            Console.Write("\nEnter the number of the book to rent: ");
            if (int.TryParse(Console.ReadLine(), out int bookIndex))
            {
                if (bookIndex >= 1 && bookIndex <= library.Books.Length)
                {
                    List<Book> remainingBooks = new List<Book>(library.Books);
                    Console.WriteLine($"'{library.Books[bookIndex - 1].Title}' has been rented successfully.");
                    remainingBooks.RemoveAt(bookIndex - 1);
                    library.Books = remainingBooks.ToArray();
                }
                else
                {
                    Console.WriteLine("Invalid book number. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
        static void RentAudioBook()
        {
            Console.WriteLine("\nRent Audio Books:");
            DisplayAudioBooks();

            Console.Write("\nEnter the number of the audio book to rent: ");
            if (int.TryParse(Console.ReadLine(), out int audioBookIndex))
            {
                if (audioBookIndex >= 1 && audioBookIndex <= library.AudioBooks.Length)
                {
                    List<AudioBook> remainingAudioBooks = new List<AudioBook>(library.AudioBooks);
                    Console.WriteLine($"'{library.AudioBooks[audioBookIndex - 1].Title}' has been rented successfully.");
                    remainingAudioBooks.RemoveAt(audioBookIndex - 1);
                    library.AudioBooks = remainingAudioBooks.ToArray();
                }
                else
                {
                    Console.WriteLine("Invalid audio book number. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
        static void RentJournal()
        {
            Console.WriteLine("\nRent Journals:");
            DisplayJournals();

            Console.Write("\nEnter the number of the journal to rent: ");
            if (int.TryParse(Console.ReadLine(), out int journalIndex))
            {
                if (journalIndex >= 1 && journalIndex <= library.Journals.Length)
                {
                    List<Journal> remainingJournals = new List<Journal>(library.Journals);
                    Console.WriteLine($"'{library.Journals[journalIndex - 1].Title}' has been rented successfully.");
                    remainingJournals.RemoveAt(journalIndex - 1);
                    library.Journals = remainingJournals.ToArray();
                }
                else
                {
                    Console.WriteLine("Invalid journal number. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
        //search item
        static void SearchLibrary()
        {
            bool quit = false;

            while (!quit)
            {
                Console.WriteLine("\nSearch Library Elements:");
                Console.WriteLine("1.Search Books");
                Console.WriteLine("2.Search Audio Books");
                Console.WriteLine("3.Search Journals");
                Console.WriteLine("4.Quit");

                Console.Write("\nEnter your choice (1-4): ");
                string choice = Console.ReadLine();
                Thread.Sleep(1000);
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        SearchBook();
                        break;
                    case "2":
                        SearchAudioBook();
                        break;
                    case "3":
                        SearchJournal();
                        break;
                    case "4":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        static void SearchBook()
        {
            Console.WriteLine("\nSearch Library:");
            string search = Console.ReadLine();

            bool found = false;

            // Search in Books
            Console.WriteLine("\nBooks:");
            foreach (Book book in library.Books)
            {
                if (book.Title.ToLower() == search.ToLower() || book.Author.ToLower() == search.ToLower() || book.PublicationYear.ToString().ToLower() == search.ToLower())
                {
                    Console.WriteLine($"Book found: {book.Title} by {book.Author}, {book.PublicationYear}");
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No matching book, audio book, or journal found.");
            }
        }
        static void SearchAudioBook()
        {
            Console.WriteLine("\nSearch Library:");
            string search = Console.ReadLine();

            bool found = false;

            // Search in AudioBooks
            Console.WriteLine("\nAudio Books:");
            foreach (AudioBook audioBook in library.AudioBooks)
            {
                if (audioBook.Title.ToLower() == search.ToLower() || audioBook.Author.ToLower() == search.ToLower() || audioBook.PublicationYear.ToString().ToLower() == search.ToLower())
                {
                    Console.WriteLine($"Audio Book found: {audioBook.Title} by {audioBook.Author}, {audioBook.PublicationYear}");
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No matching book, audio book, or journal found.");
            }
        }
        static void SearchJournal()
        {
            Console.WriteLine("\nSearch Library:");
            string search = Console.ReadLine();

            bool found = false;

            // Search in Journals
            Console.WriteLine("\nJournals:");
            foreach (Journal journal in library.Journals)
            {
                if (journal.Title.ToLower() == search.ToLower() || journal.Author.ToLower() == search.ToLower() || journal.PublicationYear.ToString().ToLower() == search.ToLower())
                {
                    Console.WriteLine($"Journal found: {journal.Title} by {journal.Author}, {journal.PublicationYear}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No matching book, audio book, or journal found.");
            }
        }
    }
    public class Library
    {
        public Book[] Books { get; set; }
        public AudioBook[] AudioBooks { get; set; }
        public Journal[] Journals { get; set; }

        public Library()
        {
            Books =
            [
                new Book("1984", "George Orwell", 1948),
                new Book("Sherlock Holmes", "Arthur Conan Doyle", 1887)
            ];

            AudioBooks =
            [
                new AudioBook("To Kill a Mockingbird", "Harper Lee", 1960),
                new AudioBook("The Great Gatsby", "F. Scott Fitzgerald", 1925)
            ];

            Journals =
            [
                new Journal("Magazine, Business","The Economist",2023, "The Economist Group" ),
                new Journal( "Magazine, Science","National Geographic Partners",1888,"National Geographic" )
            ];
        }
    }
}