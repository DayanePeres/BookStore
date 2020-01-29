using BookStore.Application.Controllers;
using BookStore.Data;
using BookStore.Data.Context;
using BookStore.Data.Repository;
using BookStore.Domain.Entities;
using BookStore.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;


namespace BookStore.Integrated.Test
{
    [TestClass]
    public class AuthorTest
    {
        private readonly MyContext _myContext;
        private readonly AuthorRepository _repository;
        private readonly AuthorService _service;
        private readonly DataContext myContext;
        private readonly AuthorController _controller;


        public AuthorTest()
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

    }
}










