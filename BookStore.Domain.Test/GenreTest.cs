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


namespace BookStore.Integrated.Test
{
    [TestClass]
    public class GenreTest
    {
        private static MyContext _myContext;
        private static GenreRepository _repository;
        private static GenreService _service;
        private static GenreController _controller;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConnectionString.SetDev();
            _myContext = new DataContext().CreateDbContext(new string[] { });
            _repository = new GenreRepository(_myContext);
            _service = new GenreService(_repository);
            _controller = new GenreController(_service);

        }

        [TestMethod]
        public async Task ShouldGetAnEmptyGenresList()
        {
            //Act
            var getAllResponse = (ObjectResult)await _controller.GetAll();
            var genreList = (IEnumerable<GenreEntity>) getAllResponse.Value;

            //Assert
            Assert.AreEqual(200, getAllResponse.StatusCode);
            Assert.AreEqual(0, genreList.Count());
        }

        [TestMethod]
        public async Task ShouldPostGenres()
        {
            //Arrange
            var genre = CreateGenre();
            //Act
            var postResponse = (ObjectResult)await _controller.Post(genre);
            genre = (GenreEntity)postResponse.Value;

            var getResponse = (ObjectResult)await _controller.Get(genre.Id);
            var genreResponse = (GenreEntity)getResponse.Value;

            var getAllResponse = (ObjectResult)await _controller.GetAll();
            var genreList = (IEnumerable<GenreEntity>) getAllResponse.Value;
            //Assert
            Assert.AreEqual(200, ((ObjectResult)postResponse).StatusCode);
            Assert.AreEqual(200, ((ObjectResult)getResponse).StatusCode);
            Assert.AreEqual(genreResponse.Id, genre.Id);
            Assert.AreEqual(1, genreList.Count());

        }

        [TestMethod]
        public async Task ShouldPutGenreById()
        {
            //Arrange
            var genre = CreateGenre();

            //Act
            var postResponse = (ObjectResult)await _controller.Post(genre);
            var genreResponse = (GenreEntity)postResponse.Value;
            genre.Name = "Action";
            var putResponse = (ObjectResult)await _controller.Put(genre, genreResponse.Id);
            genreResponse = (GenreEntity)putResponse.Value;
            var getAllResponse = (ObjectResult)await _controller.GetAll();
            var genreList = (IEnumerable<GenreEntity>) getAllResponse.Value;

            //Assert
            Assert.AreEqual(200, postResponse.StatusCode);
            Assert.AreEqual(200, putResponse.StatusCode);
            Assert.AreEqual(genreResponse.Name, genre.Name);
            Assert.AreEqual(2, genreList.Count());

        }

        [TestMethod]
        public async Task ShouldDeleteGenreById()
        {
            //Arrange
            var genre = CreateGenre();
            //Act
            var postResponse = (ObjectResult)await _controller.Post(genre);
            var genreResponse = (GenreEntity)postResponse.Value;

            var deleteResponse = (ObjectResult)await _controller.Delete(genreResponse.Id);
            var isDeleted = (bool)deleteResponse.Value;

            var getResponse = await _controller.Get(genreResponse.Id);
            var getAllResponse = (ObjectResult)await _controller.GetAll();
            var genreList = (IEnumerable<GenreEntity>)getAllResponse.Value;
            //Assert
            Assert.AreEqual(200, postResponse.StatusCode);
            Assert.AreEqual(200, deleteResponse.StatusCode);
            Assert.AreEqual(200, getAllResponse.StatusCode);
            Assert.IsTrue(isDeleted);
            Assert.IsInstanceOfType(getResponse, typeof(NotFoundResult));
            Assert.AreEqual(0, genreList.Count());
        }
        [TestMethod]
        public async Task ShouldFindAllGenreAndDelete()
        {
            var getAllResponse = (ObjectResult)await _controller.GetAll();
            var genreList = (IEnumerable<GenreEntity>)getAllResponse.Value;
            foreach (var genre in genreList)
            {
                var deleteResponse = (ObjectResult)await _controller.Delete(genre.Id);
                var isDeleted = (bool)deleteResponse.Value;
                Assert.IsTrue(isDeleted);
            }
            getAllResponse = (OkObjectResult)await _controller.GetAll();
            genreList = (IEnumerable<GenreEntity>)getAllResponse.Value;
            Assert.AreEqual(0, genreList.Count());
        }

        private GenreEntity CreateGenre()
        {
            return new GenreEntity
            {
                Name = "Comedian"
            };
        }

    }
}
