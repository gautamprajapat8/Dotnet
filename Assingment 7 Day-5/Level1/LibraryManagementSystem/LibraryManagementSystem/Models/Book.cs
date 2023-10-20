using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models
{
    [Table("Book")]
    public class Book
    {
        // Book properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public int NumberInStock { get; set; }

    
        // Foreign key to Patron
        public int? PatronId { get; set; }
        public Patron Patron { get; set; }
    }

    // DbContext class
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Patron> Patrons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define relationships and constraints
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Patron)
                .WithMany(p => p.BorrowedBooks)
                .HasForeignKey(b => b.PatronId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }

}
