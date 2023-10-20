using LibraryManagementSystem.DataAccess;
using LibraryManagementSystem.Models;
using System;

namespace LibraryManagementSystem
{
    public class BookManager
    {
        private LibraryContext _context;

        public BookManager(LibraryContext context)
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
                    Console.WriteLine($"Book Id: {book.Id}, Title: {book.Title}, Author: {book.Author}, Year: {book.Year}");
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



    }
}
