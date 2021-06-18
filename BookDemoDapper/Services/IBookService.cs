using BookDemoDapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookDemoDapper.Services
{
    public interface IBookService
    {
        IList<Book> GetAll();
        Book GetById(int id);
        Book Add(Book book);
        Book Update(Book book);
        void Delete(int id);
    }
}
