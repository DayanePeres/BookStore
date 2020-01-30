using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BookStore.Application.Controllers
{
    public class BookController : BaseController<BookEntity>
    {
        private readonly IBookService _serviceBook;
        public BookController(IBookService service) : base(service)
        {
            _serviceBook = service;
        }

        [HttpGet]
        [Route("filter")]
        public ActionResult GetAllWithAuthorAndGenre()
        {
            return Ok( _serviceBook.GetAllWithAuthorAndGenre());
        }

        [HttpGet]
        [Route("{id}/filter")]
        public ActionResult GetOnlyWithAuthorAndGenre(Guid id)
        {
            return Ok(_serviceBook.GetOneWithAuthorAndGenre(id));
        }

    }

}
