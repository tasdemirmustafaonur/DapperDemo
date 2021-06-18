using BookDemoDapper.Models;
using BookDemoDapper.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookDemoDapper.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookService service;
        public BooksController(IBookService service)
        {
            this.service = service;
        }
       
        //İstemci tarafından request atıldığında CRUD işlemlerinin yönlendirilmesi yapılmıştır

        //GET ALL
        [HttpGet]
        public IActionResult Get()
        {
            var books = service.GetAll();
            return Ok(books);
        }

        //GET By Id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = service.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        //CREATE
        [HttpPost]
        public IActionResult CreateBook(Book book)
        {
            var newBook = service.Add(book);
            return Ok("Ürün Eklendi");
        }

        //UPDATE
        [HttpPut]
        public IActionResult UpdateBook(Book book)
        {
            var updateBook = service.Update(book);
            return Ok(updateBook);
        }

        //DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            service.Delete(id);
            return Ok(id+" numaralı id silindi");
            

        }
    }
}
