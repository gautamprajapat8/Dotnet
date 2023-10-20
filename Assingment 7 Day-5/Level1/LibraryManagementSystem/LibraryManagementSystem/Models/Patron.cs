using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models
{
    [Table("Patron")]
    public class Patron
    {

        public Patron()
        {
            BorrowedBooks = new List<Book>(); // Initialize BorrowedBooks as an empty collection
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ContactInformation { get; set; }

        public ICollection<Book> BorrowedBooks { get; set; }


        // You can add more properties for tracking patron-related information.

        // If you want to establish a relationship with books, you can add a navigation property like this:
        // public ICollection<Book> Books { get; set; }
    }
}
