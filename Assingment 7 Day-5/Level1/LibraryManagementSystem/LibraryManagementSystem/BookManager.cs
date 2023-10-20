using LibraryManagementSystem.DataAccess;
using LibraryManagementSystem.Models;
using System;

namespace LibraryManagementSystem
{
    public class BookManager
    {
        private LibraryManagementSystem.DataAccess.LibraryContext _context;


        public BookManager(LibraryManagementSystem.DataAccess.LibraryContext context)
        {
            _context = context;
        }



        public void CreateNewBook(Book newBook)
        {
            
            _context.Books.Add(newBook);
            _context.SaveChanges();
            Console.WriteLine("Book added successfully!");
        }


        public void DisplayBooks()
        {
            var books = _context.Books.ToList();

            if (books.Count > 0)
            {
                Console.WriteLine("Books in the Library:");
                foreach (var book in books)
                {
                    Console.WriteLine($"Book Id: {book.Id}, Title: {book.Title}, Author: {book.Author}, Year: {book.Year}, Avalable Stock: {book.NumberInStock}");
                    // Display other book properties as needed
                }
            }
            else
            {
                Console.WriteLine("No books found in the library.");
            }
        }



        public void UpdateBook(int bookId)
        {
            var book = _context.Books.Find(bookId);

            if (book != null)
            {
                Console.WriteLine("Current book details:");
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Year: {book.Year}");
                // Display other book properties as needed

                Console.Write("Enter the new title for the book: ");
                var newTitle = Console.ReadLine();

                Console.Write("Enter the new author for the book: ");
                var newAuthor = Console.ReadLine();

                int newYear;
                bool validYear = false;

                do
                {
                    Console.Write("Enter the new publication year for the book: ");
                    if (int.TryParse(Console.ReadLine(), out newYear) && newYear >= 0)
                    {
                        validYear = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid year. Please enter a valid year.");
                    }
                } while (!validYear);

                book.Title = newTitle;
                book.Author = newAuthor;
                book.Year = newYear;
                // Update other book properties as needed

                _context.SaveChanges(); // Save the changes to the database

                Console.WriteLine("Book updated successfully!");
            }
            else
            {
                Console.WriteLine("Book not found. Please enter a valid book ID.");
            }
        }



        public void DeleteBook(int bookId)
        {
            var book = _context.Books.Find(bookId);

            if (book != null)
            {
                Console.WriteLine("Book details to delete:");
                Console.WriteLine($"ID: {book.Id}");
                Console.WriteLine($"Title: {book.Title}");
                Console.WriteLine($"Author: {book.Author}");
                Console.WriteLine($"Year: {book.Year}");
                Console.WriteLine($"Number in Stock: {book.NumberInStock}");
                // Display other book properties as needed

                Console.Write("Are you sure you want to delete this book? (yes/no): ");
                var confirmation = Console.ReadLine().ToLower();

                if (confirmation == "yes")
                {
                    _context.Books.Remove(book);
                    _context.SaveChanges(); // Save the changes to the database

                    Console.WriteLine("Book deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Deletion canceled.");
                }
            }
            else
            {
                Console.WriteLine("Book not found. Please enter a valid book ID.");
            }
        }


        public void DisplayBookById(int bookId)
        {
            var book = _context.Books.Find(bookId);

            if (book != null)
            {
                Console.WriteLine("Book details:");
                Console.WriteLine($"ID: {book.Id}");
                Console.WriteLine($"Title: {book.Title}");
                Console.WriteLine($"Author: {book.Author}");
                Console.WriteLine($"Year: {book.Year}");
                Console.WriteLine($"Number in Stock: {book.NumberInStock}");
                // Add other properties here as needed
            }
            else
            {
                Console.WriteLine("Book not found. Please enter a valid book ID.");
            }
        }

        public void UpdateBookStock(int bookId, int newStock)
        {
            var book = _context.Books.Find(bookId);

            if (book != null)
            {
                book.NumberInStock += newStock; // Add the new stock value to the previous stock
                _context.SaveChanges();
                Console.WriteLine("Book stock updated successfully!");
            }
            else
            {
                Console.WriteLine("Book not found. Please enter a valid book ID.");
            }
        }

        
        public void BorrowBook(Patron patron, Book book)
        {
            if (book.NumberInStock > 0)
            {
                // Decrease the stock of the book by one
                book.NumberInStock--;

                // Add the book to the patron's borrowed books
                patron.BorrowedBooks.Add(book);

                // Save changes to the database
                _context.SaveChanges();
                Console.WriteLine("Book borrowed successfully!");
            }
            else
            {
                Console.WriteLine("Sorry, the book is not available in stock at this time. Please try again later.");
            }
        }
        

        
        public void BorrowBook(int patronId, int bookId)
        {
            var patron = _context.Patrons.Find(patronId);
            var book = _context.Books.Find(bookId);

            if (patron != null && book != null && book.NumberInStock > 0)
            {
                // Update the book's stock
                book.NumberInStock--;

                // Associate the book with the patron
                if (patron.BorrowedBooks == null)
                {
                    patron.BorrowedBooks = new List<Book>();
                }
                patron.BorrowedBooks.Add(book);

                _context.SaveChanges();
                Console.WriteLine("Book borrowed successfully!");
            }
            else
            {
                if (patron == null)
                {
                    Console.WriteLine("Patron not found. Please enter a valid patron ID.");
                }
                else if (book == null)
                {
                    Console.WriteLine("Book not found. Please enter a valid book ID.");
                }
                else
                {
                    Console.WriteLine("Book not available in stock. Please try again later.");
                }
            }
        }


        public Book GetBookById(int bookId)
        {
            var book = _context.Books.Find(bookId);
            return book;
        }


    }
}
