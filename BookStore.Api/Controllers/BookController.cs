using BookStore.Data.Context;
using BookStore.Data.Repository;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Services;
using BookStore.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BookStore.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
     /*       var connectionString = "Server=localhost;Database=DbBookStore;Trusted_Connection=True";

            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseSqlServer(connectionString);

            var myContext = new MyContext(optionsBuilder.Options);
            var baseService = new BaseService<BookEntity>(
                new BaseRepository<BookEntity>(myContext)
                );*/

            List<BookEntity> list = new List<BookEntity>()
            {
                new BookEntity("asda", 123, 234),
                new BookEntity("qwee", 321, 432),
            };


            return Ok(await _bookService.Get());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            try
            {
                return Ok(await _bookService.Get(id));
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
        
}
