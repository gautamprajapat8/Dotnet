using LibraryManagementSystem.DataAccess;
using LibraryManagementSystem.Models;
using System;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new LibraryManagementSystem.DataAccess.LibraryContext())
            {
                var bookManager = new BookManager(context);
                var patronManager = new PatronManager(context);

                while (true)
                {
                    Console.WriteLine("Library Management System");
                    Console.WriteLine("1. Add New Book");
                    Console.WriteLine("2. Display All Books");
                    Console.WriteLine("3. Display Book by Id");
                    Console.WriteLine("4. Update Book by Id");
                    Console.WriteLine("5. Delete Book by Id");
                    Console.WriteLine("6. Add New Patron");
                    Console.WriteLine("7. Display All Patrons");
                    Console.WriteLine("8. Display Patron by Id");
                    Console.WriteLine("9. Update Patron by Id");
                    Console.WriteLine("10. Delete Patron by Id");
                    Console.WriteLine("11. Borrow a Book");
                    Console.WriteLine("12. Update Book Stock");
                    Console.WriteLine("13. Exit");
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

                                int year = 0;
                                bool validYear = false;
                                while (!validYear)
                                {
                                    Console.Write("Enter the publication year of the book: ");
                                    if (int.TryParse(Console.ReadLine(), out year) && year > 0)
                                    {
                                        validYear = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid year. Please enter a valid year.");
                                    }
                                }

                                int numberInStock = 0;
                                bool validNumberInStock = false;
                                while (!validNumberInStock)
                                {
                                    Console.Write("Enter the number of copies in stock: ");
                                    if (int.TryParse(Console.ReadLine(), out numberInStock) && numberInStock > 0)
                                    {
                                        validNumberInStock = true;
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
                                // Create a new patron
                                Console.Write("Enter the name of the patron: ");
                                var patronName = Console.ReadLine();
                                Console.Write("Enter contact information: ");
                                var contactInfo = Console.ReadLine();
                                var newPatron = new Patron
                                {
                                    Name = patronName,
                                    ContactInformation = contactInfo
                                };
                                patronManager.CreateNewPatron(newPatron);
                                Console.WriteLine("Patron added successfully!");
                                break;

                            case 7:
                                // Display all patrons
                                patronManager.DisplayPatrons();
                                break;

                            case 8:
                                // Display patron by ID
                                Console.Write("Enter the patron ID: ");
                                if (int.TryParse(Console.ReadLine(), out int patronId))
                                {
                                    patronManager.DisplayPatronById(patronId);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid patron ID.");
                                }
                                break;

                            case 9:
                                // Update patron
                                Console.Write("Enter the patron ID to update: ");
                                if (int.TryParse(Console.ReadLine(), out int patronIdToUpdate))
                                {
                                    patronManager.UpdatePatron(patronIdToUpdate);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid patron ID.");
                                }
                                break;

                            case 10:
                                // Delete patron
                                Console.Write("Enter the patron ID to delete: ");
                                if (int.TryParse(Console.ReadLine(), out int patronIdToDelete))
                                {
                                    patronManager.DeletePatron(patronIdToDelete);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid patron ID.");
                                }
                                break;

                            //Borrow a Book
                            case 11:
                                int patronId; // Declare patronId here
                                Console.Write("Enter the patron ID: ");
                                if (int.TryParse(Console.ReadLine(), out patronId))
                                {
                                    var patron = patronManager.GetPatronById(patronId);
                                    if (patron != null)
                                    {
                                        int bookId; // Declare a different variable name (e.g., bookId) here
                                        Console.Write("Enter the book ID to borrow: ");
                                        if (int.TryParse(Console.ReadLine(), out bookId))
                                        {
                                            var book = bookManager.GetBookById(bookId);
                                            if (book != null)
                                            {
                                                // Attempt to borrow the book
                                                bookManager.BorrowBook(patron, book);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Book not found. Please enter a valid book ID.");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input. Please enter a valid book ID.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Patron not found. Please enter a valid patron ID.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid patron ID.");
                                }
                                break;





                            case 12:
                                // Update book stock
                                Console.Write("Enter the book ID to update stock: ");
                                if (int.TryParse(Console.ReadLine(), out int bookIdToUpdateStock))
                                {
                                    Console.Write("Enter the new stock value: ");
                                    if (int.TryParse(Console.ReadLine(), out int newStockValue))
                                    {
                                        if (newStockValue > 0)
                                        {
                                            bookManager.UpdateBookStock(bookIdToUpdateStock, newStockValue);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Stock value must be greater than zero. Please enter a valid stock value.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid stock value. Please enter a valid number.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid book ID.");
                                }
                                break;


                            case 13:
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
