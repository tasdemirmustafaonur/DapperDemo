using BookDemoDapper.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookDemoDapper.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext>options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Book>().Property(p => p.Name).HasMaxLength(50);
            modelBuilder.Entity<Book>().Property(p => p.Description).IsRequired();
            modelBuilder.Entity<Book>().Property(p => p.Description).HasMaxLength(150);

        }

    }
}
