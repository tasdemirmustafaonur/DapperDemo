using BookDemoDapper.Data;
using BookDemoDapper.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BookDemoDapper.Services
{
    public class BookService : IBookService
    {
        private IDbConnection db;

        //Veritabanı bağlantısı gerçekleştirlmiştir
        public BookService(IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        
        //Dapper Micro ORM ile CRUD işlemleri gerçekleştirilmiştir.
        public Book Add(Book book)
        {
            var sql = "INSERT INTO Books (Name,PublishedDate,Description) VALUES(@Name, @PublishedDate, @Description);" + "SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = db.Query<int>(sql,book).Single();
            book.Id = id;
            return book;

        }

        public void Delete(int id)
        {
            var sql = "DELETE FROM Books WHERE Id = @Id";
            db.Execute(sql, new { @Id = id });
        }

        public Book GetById(int id)
        {
            var sql = "SELECT * FROM Books WHERE Id = @Id";
            return db.Query<Book>(sql, new { @Id = id }).Single();
        }

        public IList<Book> GetAll()
        {
            var sql = "SELECT * FROM Books";
            return db.Query<Book>(sql).ToList();
        }

        public Book Update(Book book)
        {
            var sql = "UPDATE Books SET Name = @Name, PublishedDate = @PublishedDate, Description = @Description WHERE Id = @Id";
            db.Execute(sql, book);
            return book;
        }
    }
}
