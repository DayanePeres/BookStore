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
    public class GenreTest
    {
        private readonly MyContext _myContext;
        private readonly GenreRepository _repository;
        private readonly GenreService _service;
        private readonly GenreController _controller;


        public GenreTest()
        {
            EnvironmentProperties.ConnectionString = "";
            _myContext = new DataContext().CreateDbContext(new string[] { });
            _repository = new GenreRepository(_myContext);
            _service = new GenreService(_repository);
            _controller = new GenreController(_service);

        }

        [TestMethod]
        public async Task ShouldGetAnEmptyGenresList()
        {
            var response = (OkObjectResult)await _controller.GetAll();

            var value = response.Value.GetType()
                .GetProperty("Count")
                .GetValue(response.Value);

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual(0, value);
        }

        [TestMethod]
        public async Task ShouldPostGenres()
        {
            GenreEntity Genre = new GenreEntity
            {
                Name = "JoaoDoJeitoCerto"
            };
            var responsePost = await _controller.Post(Genre);
            var respPost = (GenreEntity)(((OkObjectResult)((ActionResult<GenreEntity>)responsePost).Result).Value);

            var responseGet = await _controller.Get(respPost.Id);
            var respGet = (GenreEntity)(((OkObjectResult)((ActionResult<GenreEntity>)responseGet).Result).Value);

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
        public async Task ShouldPutGenreById()
        {
            GenreEntity Genre = new GenreEntity
            {
                Name = "JoaoDoJeitoCerto"
            };
            var responsePost = await _controller.Post(Genre);
            var respPost = (GenreEntity)(((OkObjectResult)((ActionResult<GenreEntity>)responsePost).Result).Value);

            Genre.Name = "JoaoAtualizado";

            var responsePut = await _controller.Put(Genre, respPost.Id);
            var respPut = (GenreEntity)(((OkObjectResult)((ActionResult<GenreEntity>)responsePut).Result).Value);

            var responseGetAll = (OkObjectResult)await _controller.GetAll();
            var respGetAll = responseGetAll.Value.GetType()
                .GetProperty("Count")
                .GetValue(responseGetAll.Value);


            Assert.AreEqual(200, (int)((OkObjectResult)responsePost).StatusCode);
            Assert.AreEqual(200, (int)((OkObjectResult)responsePut).StatusCode);
            Assert.AreEqual(respPut.Name, Genre.Name);
            Assert.AreEqual(2, respGetAll);

        }

        [TestMethod]
        public async Task ShouldDeleteGenreById()
        {
            GenreEntity Genre = new GenreEntity
            {
                Name = "JoaoDoJeitoCerto"
            };
            var responsePost = await _controller.Post(Genre);
            var respPost = (GenreEntity)(((OkObjectResult)((ActionResult<GenreEntity>)responsePost).Result).Value);

            var responseDelete = await _controller.Delete(respPost.Id);
            var respDelete = (bool)(((OkObjectResult)((ActionResult<GenreEntity>)responseDelete).Result).Value);

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
        }

        public async Task ShouldFindAllGenreAndDelete()
        {

            var responseGetAll = (OkObjectResult)await _controller.GetAll();
            var respGetAll = (IEnumerable<GenreEntity>)(((OkObjectResult)((ActionResult<GenreEntity>)responseGetAll).Result).Value);

            foreach (GenreEntity Genre in respGetAll)
            {
                var responseDelete = await _controller.Delete(Genre.Id);
                var respDelete = (bool)(((OkObjectResult)((ActionResult<GenreEntity>)responseDelete).Result).Value);
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
