using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models
{
    [Table("Book")]
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The field NumberInStock must be greater than 0.")]
        public int NumberInStock { get; set; }

        // You can add more properties, such as ISBN, genre, or a foreign key to Patron for tracking book borrowers.

        // If you want to establish a relationship with Patron, you can add a foreign key property like this:
        // [ForeignKey("Patron")]
        // public int? PatronId { get; set; }
        // public Patron Patron { get; set; }
    }
}
