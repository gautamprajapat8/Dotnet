using LibraryManagementSystem.DataAccess;
using LibraryManagementSystem.Models;
using System;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new LibraryContext())
            {
                var bookManager = new BookManager(context);

                while (true)
                {
                    Console.WriteLine("Library Management System");
                    Console.WriteLine("1. Add New Book");
                    Console.WriteLine("2. Display All Books");
                    Console.WriteLine("3. Display Book by Id");
                    Console.WriteLine("4. Update Book by Id");
                    Console.WriteLine("5. Delete Book by Id");
                    Console.WriteLine("6. Exit");
                    Console.Write("Select an option: ");

                    if (int.TryParse(Console.ReadLine(), out int option))
                    {
                        switch (option)
                        {
                            case 1:
                                // Create a new book
                                Console.Write("Enter the title of the book: ");
                                var title = Console.ReadLine();

                                Console.Write("Enter the author of the book: ");
                                var author = Console.ReadLine();

                                int year = 0; // Initialize the year variable.
                                bool validYear = false;
                                while (!validYear)
                                {
                                    Console.Write("Enter the publication year of the book: ");
                                    if (int.TryParse(Console.ReadLine(), out year) && year > 0)
                                    {
                                        validYear = true; // Break out of the loop if the year is valid.
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid year. Please enter a valid year.");
                                    }
                                }

                                int numberInStock = 0; // Initialize the numberInStock variable.
                                bool validNumberInStock = false;
                                while (!validNumberInStock)
                                {
                                    Console.Write("Enter the number of copies in stock: ");
                                    if (int.TryParse(Console.ReadLine(), out numberInStock) && numberInStock > 0)
                                    {
                                        validNumberInStock = true; // Break out of the loop if the number in stock is valid.
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid number in stock. Please enter a valid number.");
                                    }
                                }

                                var newBook = new Book
                                {
                                    Title = title,
                                    Author = author,
                                    Year = year,
                                    NumberInStock = numberInStock
                                    // Add other properties as needed
                                };
                                bookManager.CreateNewBook(newBook);
                                break;




                            case 2:
                                // Display all books
                                bookManager.DisplayBooks();
                                break;

                            case 3:
                                // Display book by ID
                                Console.Write("Enter the book ID: ");
                                if (int.TryParse(Console.ReadLine(), out int bookId))
                                {
                                    bookManager.DisplayBookById(bookId);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid book ID.");
                                }
                                break;

                            case 4:
                                // Update book
                                Console.Write("Enter the book ID to update: ");
                                if (int.TryParse(Console.ReadLine(), out int bookIdToUpdate))
                                {
                                    bookManager.UpdateBook(bookIdToUpdate);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid book ID.");
                                }
                                break;

                            case 5:
                                // Delete book
                                Console.Write("Enter the book ID to delete: ");
                                if (int.TryParse(Console.ReadLine(), out int bookIdToDelete))
                                {
                                    bookManager.DeleteBook(bookIdToDelete);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid book ID.");
                                }
                                break;

                            case 6:
                                // Exit the program
                                return;

                            default:
                                Console.WriteLine("Invalid option. Please select a valid option.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid option.");
                    }

                    Console.WriteLine("_______________________________________________________________\n");
                }
            }
        }
    }
}
