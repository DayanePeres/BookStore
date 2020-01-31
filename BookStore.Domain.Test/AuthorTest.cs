using BookStore.Application.Controllers;
using BookStore.Data.Context;
using BookStore.Data.Repository;
using BookStore.Domain.Entities;
using BookStore.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Integrated.Test.Helper;
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace BookStore.Integrated.Test
{
    [TestClass]
    public class AuthorTest
    {
        private static MyContext _myContext;
        private static AuthorRepository _repository;
        private static AuthorService _service;
        private static AuthorController _controller;
        
        [ClassInitialize] //define que será executado uma vez quando a classe for inicada.
        public static void Setup(TestContext context)
        {
            ConnectionString.SetDev(); //Atalho para limpar a conection string.
            _myContext = new DataContext().CreateDbContext(new string[] { });
            _repository = new AuthorRepository(_myContext);
            _service = new AuthorService(_repository);
            _controller = new AuthorController(_service);

        }

        [TestMethod]
        public async Task ShouldGetAnEmptyAuthorsList()
        {
            //Act
            var getAllResponse = (ObjectResult) await _controller.GetAll();
            var authorList = (IEnumerable<AuthorEntity>) getAllResponse.Value;

            //Assert
            Assert.AreEqual(200, getAllResponse.StatusCode);
            Assert.AreEqual(0, authorList.Count());
        }

        [TestMethod]
        public async Task ShouldPostAuthors()
        {
            //Arrange
            var author = CreateAuthor();

            //Act
            var postResponse = (ObjectResult) await _controller.Post(author);
            author = (AuthorEntity) postResponse.Value;

            var getResponse = (ObjectResult) await _controller.Get(author.Id);
            var authorResponse = (AuthorEntity) getResponse.Value;

            var getAllResponse = (ObjectResult)await _controller.GetAll();
            var authorList = (IEnumerable<AuthorEntity>) getAllResponse.Value;

            //Assert
            Assert.AreEqual(200, postResponse.StatusCode);
            Assert.AreEqual(200, getResponse.StatusCode);
            Assert.AreEqual(author.Id,authorResponse.Id);
            Assert.AreEqual(1, authorList.Count());
        }

        [TestMethod]
        public async Task ShouldPutAuthorById()
        {
            //Arrange
            var author = CreateAuthor();

            //Act
            var postResponse = (ObjectResult) await _controller.Post(author);
            var authorResponse = (AuthorEntity) postResponse.Value;

            author.Name = "JoaoAtualizado";
            
            var putResponse = (ObjectResult) await _controller.Put(author, authorResponse.Id);
            var respPut = (AuthorEntity) putResponse.Value;

            var getAllResponse = (ObjectResult) await _controller.GetAll();
            var authorList = (IEnumerable<AuthorEntity>) getAllResponse.Value;

            //Assert
            Assert.AreEqual(200, (int)((OkObjectResult)postResponse).StatusCode);
            Assert.AreEqual(200, (int)((OkObjectResult)putResponse).StatusCode);
            Assert.AreEqual(respPut.Name, author.Name);
            Assert.AreEqual(2, authorList.Count());

        }

        [TestMethod]
        public async Task ShouldDeleteAuthorById()
        {
            //Arrange
            var author = CreateAuthor();

            //Act
            var postResponse = (ObjectResult) await _controller.Post(author);
            var authorResponse = (AuthorEntity) postResponse.Value;

            var deleteResponse = (ObjectResult) await _controller.Delete(authorResponse.Id);
            var isDeleted = (bool) deleteResponse.Value;

            var getResponse = await _controller.Get(authorResponse.Id);
            

            var getAllResponse = (ObjectResult) await _controller.GetAll();
            var authorList = (IEnumerable<AuthorEntity>) getAllResponse.Value;

            //Assert
            Assert.AreEqual(200, postResponse.StatusCode);
            Assert.AreEqual(200, deleteResponse.StatusCode);
            Assert.AreEqual(200, getAllResponse.StatusCode);
            Assert.IsTrue(isDeleted);
            Assert.IsInstanceOfType(getResponse, typeof(NotFoundResult));
            Assert.AreEqual(0, authorList.Count());
        }
        [TestMethod]
        public async Task ShouldFindAllAuthorAndDelete()
        {
            var getAllResponse = (ObjectResult) await _controller.GetAll();
            var authorList = (IEnumerable<AuthorEntity>) getAllResponse.Value;

            foreach(AuthorEntity author in authorList)
            {
                var deleteResponse = (ObjectResult) await _controller.Delete(author.Id);
                var isDeleted = (bool) deleteResponse.Value;
                Assert.IsTrue(isDeleted);
            }

            getAllResponse = (ObjectResult) await _controller.GetAll();
            authorList = (IEnumerable<AuthorEntity>) getAllResponse.Value;

            Assert.AreEqual(0, authorList.Count());
        }

        private AuthorEntity CreateAuthor()
        {
            return new AuthorEntity
            {
                Name = "Author JoaoDoJeitoCerto"
            };

        }
    }
}
