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
    public class AuthorTest
    {
        private static MyContext _myContext;
        private static AuthorRepository _repository;
        private static AuthorService _service;
        private static AuthorController _controller;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            EnvironmentProperties.ConnectionString = "";
            _myContext = new DataContext().CreateDbContext(new string[] { });
            _repository = new AuthorRepository(_myContext);
            _service = new AuthorService(_repository);
            _controller = new AuthorController(_service);

        }

        [TestMethod]
        public async Task ShouldGetAnEmptyAuthorsList()
        {
            var response = (OkObjectResult) await _controller.GetAll();

            var value = response.Value.GetType()
                .GetProperty("Count")
                .GetValue(response.Value);

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual(0, value);
        }

        [TestMethod]
        public async Task ShouldPostAuthors()
        {
            AuthorEntity author = new AuthorEntity { 
                Name = "JoaoDoJeitoCerto"
            };
            var responsePost = await _controller.Post(author);
            var respPost = (AuthorEntity)(((OkObjectResult)((ActionResult<AuthorEntity>)responsePost).Result).Value);

            var responseGet = await _controller.Get(respPost.Id);
            var respGet = (AuthorEntity)(((OkObjectResult)((ActionResult<AuthorEntity>)responseGet).Result).Value);

            var responseGetAll = (OkObjectResult)await _controller.GetAll();
            var respGetAll = responseGetAll.Value.GetType()
                .GetProperty("Count")
                .GetValue(responseGetAll.Value);


            Assert.AreEqual(200, (int)((OkObjectResult)responsePost).StatusCode);
            Assert.AreEqual(200, (int)((OkObjectResult)responseGet).StatusCode);
            Assert.AreEqual(respGet.Id,respPost.Id);
            Assert.AreEqual(1, respGetAll);

        }

        [TestMethod]
        public async Task ShouldPutAuthorById()
        {
            AuthorEntity author = new AuthorEntity
            {
                Name = "JoaoDoJeitoCerto"
            };
            var responsePost = await _controller.Post(author);
            var respPost = (AuthorEntity)(((OkObjectResult)((ActionResult<AuthorEntity>)responsePost).Result).Value);

            author.Name = "JoaoAtualizado";
            
            var responsePut = await _controller.Put(author,respPost.Id);
            var respPut = (AuthorEntity)(((OkObjectResult)((ActionResult<AuthorEntity>)responsePut).Result).Value);

            var responseGetAll = (OkObjectResult)await _controller.GetAll();
            var respGetAll = responseGetAll.Value.GetType()
                .GetProperty("Count")
                .GetValue(responseGetAll.Value);


            Assert.AreEqual(200, (int)((OkObjectResult)responsePost).StatusCode);
            Assert.AreEqual(200, (int)((OkObjectResult)responsePut).StatusCode);
            Assert.AreEqual(respPut.Name, author.Name);
            Assert.AreEqual(2, respGetAll);

        }

        [TestMethod]
        public async Task ShouldDeleteAuthorById()
        {
            AuthorEntity author = new AuthorEntity
            {
                Name = "JoaoDoJeitoCerto"
            };
            var responsePost = await _controller.Post(author);
            var respPost = (AuthorEntity)(((OkObjectResult)((ActionResult<AuthorEntity>)responsePost).Result).Value);

            var responseDelete = await _controller.Delete(respPost.Id);
            var respDelete = (bool)(((OkObjectResult)((ActionResult<AuthorEntity>)responseDelete).Result).Value);

            var responseGet = await _controller.Get(respPost.Id);
            

            var responseGetAll = (OkObjectResult)await _controller.GetAll();
            var respGetAll = responseGetAll.Value.GetType()
                .GetProperty("Count")
                .GetValue(responseGetAll.Value);


            Assert.AreEqual(200, (int)((OkObjectResult)responsePost).StatusCode);
            Assert.AreEqual(200, (int)((OkObjectResult)responseDelete).StatusCode);
            Assert.AreEqual(200, (int)((OkObjectResult)responseGetAll).StatusCode);
            Assert.IsTrue(respDelete);
            Assert.IsInstanceOfType(responseGet, typeof(NotFoundResult) );
        }

        public async Task ShouldFindAllAuthorAndDelete()
        {

            var responseGetAll = (OkObjectResult)await _controller.GetAll();
            var respGetAll = (IEnumerable<AuthorEntity>)(((OkObjectResult)((ActionResult<AuthorEntity>)responseGetAll).Result).Value);

            foreach(AuthorEntity author in respGetAll)
            {
                var responseDelete = await _controller.Delete(author.Id);
                var respDelete = (bool)(((OkObjectResult)((ActionResult<AuthorEntity>)responseDelete).Result).Value);
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
