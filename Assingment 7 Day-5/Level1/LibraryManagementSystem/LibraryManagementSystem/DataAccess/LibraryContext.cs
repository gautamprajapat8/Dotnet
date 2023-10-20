using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.DataAccess
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Patron> Patrons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;database=library;user=root;password=gautam");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Book"); // Explicitly specify the table name
            modelBuilder.Entity<Patron>().ToTable("Patron"); // Explicitly specify the table name

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Patron)
                .WithMany(p => p.BorrowedBooks)
                .HasForeignKey(b => b.PatronId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
