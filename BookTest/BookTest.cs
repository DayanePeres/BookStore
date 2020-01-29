using BookStore.Application.Controllers;
using BookStore.CrossCutting;
using BookStore.Data.Context;
using BookStore.Data.Repository;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repository;
using BookStore.Domain.Interfaces.Services;
using BookStore.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookTest
{
    [TestClass]
    public class BookTest
    {
        private BookController _bookController;
        private IBookService _bookService;


        [TestInitialize]
        public void Setup()
        {
            //ARREGE
            EnviromentProperties.ConnectionString = String.Empty;

            var myContext = new DataContext().CreateDbContext(new string[] { });
            var repository = new BookRepository(myContext);
            _bookService = new BookService(repository);
            _bookController = new BookController(_bookService);
        }

        [TestMethod]
        [TestCategory("Unit")]
         public void ShouldReturnNotFound() //Ação retorna 404 (não encontrado)
        {
            //Act
            var actionResult = _bookController.Get(Guid.NewGuid());

            //Assert 
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult)); 
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void ShouldReturnOk()
        {
            //ARREGE
            var book = new BookEntity();
            book.Name = "";
            book.Id = Guid.NewGuid();

            _bookService.Setup(x => x.Get(book.Id)).Returns( Task.FromResult(book) );


            //Act
            var actionResult = _bookController.Get(book.Id);

            //Assert 
            Assert.IsInstanceOfType(actionResult.Result, typeof(OkObjectResult));

        }
    }
}
