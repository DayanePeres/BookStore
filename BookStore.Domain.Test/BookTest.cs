using BookStore.Application.Controllers;
using BookStore.Data;
using BookStore.Data.Context;
using BookStore.Data.Repository;
using BookStore.Domain.Entities;
using BookStore.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace BookStore.Integrated.Test
{
    [TestClass]
    public class BookTest
    {
        private readonly MyContext _myContext;
        private readonly BookRepository _repository;
        private readonly BookService _service;
        private readonly BookController _controller;


        public BookTest()
        {
            EnvironmentProperties.ConnectionString = "";
            _myContext = new DataContext().CreateDbContext(new string[] { });
            _repository = new BookRepository(_myContext);
            _service = new BookService(_repository);
            _controller = new BookController(_service);

        }

        [TestMethod]
        public async Task ShouldGetAnEmptyBooksList()
        {
            var response = (OkObjectResult)await _controller.GetAll();

            var value = response.Value.GetType()
                .GetProperty("Count")
                .GetValue(response.Value);

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual(0, value);
        }

        [TestMethod]
        public async Task ShouldPostBooks()
        {
            BookEntity Book = new BookEntity
            {
                Name = "JoaoDoJeitoCerto",
                Price = 10
            };
            var responsePost = await _controller.Post(Book);
            var respPost = (BookEntity)(((OkObjectResult)((ActionResult<BookEntity>)responsePost).Result).Value);

            var responseGet = await _controller.Get(respPost.Id);
            var respGet = (BookEntity)(((OkObjectResult)((ActionResult<BookEntity>)responseGet).Result).Value);

            var responseGetAll = (OkObjectResult)await _controller.GetAll();
            var respGetAll = responseGetAll.Value.GetType()
                .GetProperty("Count")
                .GetValue(responseGetAll.Value);


            Assert.AreEqual(200, (int)((OkObjectResult)responsePost).StatusCode);
            Assert.AreEqual(200, (int)((OkObjectResult)responseGet).StatusCode);
            Assert.AreEqual(respGet.Id, respPost.Id);
            Assert.AreEqual(1, respGetAll);

        }

        [TestMethod]
        public async Task ShouldPutBookById()
        {
            BookEntity Book = new BookEntity
            {
                Name = "JoaoDoJeitoCerto",
                Price = 10
            };
            var responsePost = await _controller.Post(Book);
            var respPost = (BookEntity)(((OkObjectResult)((ActionResult<BookEntity>)responsePost).Result).Value);

            Book.Name = "JoaoAtualizado";

            var responsePut = await _controller.Put(Book, respPost.Id);
            var respPut = (BookEntity)(((OkObjectResult)((ActionResult<BookEntity>)responsePut).Result).Value);

            var responseGetAll = (OkObjectResult)await _controller.GetAll();
            var respGetAll = responseGetAll.Value.GetType()
                .GetProperty("Count")
                .GetValue(responseGetAll.Value);


            Assert.AreEqual(200, (int)((OkObjectResult)responsePost).StatusCode);
            Assert.AreEqual(200, (int)((OkObjectResult)responsePut).StatusCode);
            Assert.AreEqual(respPut.Name, Book.Name);
            Assert.AreEqual(2, respGetAll);

        }

        [TestMethod]
        public async Task ShouldDeleteBookById()
        {
            BookEntity Book = new BookEntity
            {
                Name = "JoaoDoJeitoCerto",
                Price = 10
            };
            var responsePost = await _controller.Post(Book);
            var respPost = (BookEntity)(((OkObjectResult)((ActionResult<BookEntity>)responsePost).Result).Value);

            var responseDelete = await _controller.Delete(respPost.Id);
            var respDelete = (bool)(((OkObjectResult)((ActionResult<BookEntity>)responseDelete).Result).Value);

            var responseGet = await _controller.Get(respPost.Id);


            var responseGetAll = (OkObjectResult)await _controller.GetAll();
            var respGetAll = responseGetAll.Value.GetType()
                .GetProperty("Count")
                .GetValue(responseGetAll.Value);


            Assert.AreEqual(200, (int)((OkObjectResult)responsePost).StatusCode);
            Assert.AreEqual(200, (int)((OkObjectResult)responseDelete).StatusCode);
            Assert.AreEqual(200, (int)((OkObjectResult)responseGetAll).StatusCode);
            Assert.IsTrue(respDelete);
            Assert.IsInstanceOfType(responseGet, typeof(NotFoundResult));
            Assert.AreEqual(2, respGetAll);
        }

        public async Task ShouldFindAllBookAndDelete()
        {

            var responseGetAll = (OkObjectResult)await _controller.GetAll();
            var respGetAll = (IEnumerable<BookEntity>)(((OkObjectResult)((ActionResult<BookEntity>)responseGetAll).Result).Value);

            foreach (BookEntity Book in respGetAll)
            {
                var responseDelete = await _controller.Delete(Book.Id);
                var respDelete = (bool)(((OkObjectResult)((ActionResult<BookEntity>)responseDelete).Result).Value);
                Assert.IsTrue(respDelete);
            }

            var responseGetAll2 = (OkObjectResult)await _controller.GetAll();
            var valueGetAll = responseGetAll2.Value.GetType()
                .GetProperty("Count")
                .GetValue(responseGetAll2.Value);

            Assert.AreEqual(0, valueGetAll);

        }

    }
}
