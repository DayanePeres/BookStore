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


namespace BookStore.Integrated.Test
{
    [TestClass]
    public class BookTest
    {
        private static MyContext _myContext;

        private static BookRepository _bookRepository;
        private static BookService _bookService;
        private static BookController _bookController;
        private static GenreRepository _genreRepository;
        private static GenreService _genreService;
        private static GenreController _genreController;
        private static AuthorRepository _authorRepository;
        private static AuthorService _authorService;
        private static AuthorController _authorController;



        [ClassInitialize]
        public static void Setup(TestContext context)
        {
             Helper.ConnectionString.setDev();
            _myContext = new DataContext().CreateDbContext(new string[] { });
            SetupBook();
            SetupGenre();
            SetupAuthor();
        }

        private static void SetupBook()
        {
            _bookRepository = new BookRepository(_myContext);
            _bookService = new BookService(_bookRepository);
            _bookController = new BookController(_bookService);
        }
        private static void SetupGenre()
        {
            _genreRepository = new GenreRepository(_myContext);
            _genreService = new GenreService(_genreRepository);
            _genreController = new GenreController(_genreService);
        }
        private static void SetupAuthor()
        {
            _authorRepository = new AuthorRepository(_myContext);
            _authorService = new AuthorService(_authorRepository);
            _authorController = new AuthorController(_authorService);
        }

        [TestMethod]
        public async Task ShouldGetAnEmptyBooksList()
        {
            var response = (OkObjectResult)await _bookController.GetAll();

            var value = response.Value.GetType()
                .GetProperty("Count")
                .GetValue(response.Value);

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual(0, value);
        }

        [TestMethod]
        public async Task ShouldPostBookWithSingleAuthorAndGenre()
        {
            var authorList = new List<BookAuthorEntity>();
            var genreList = new List<BookGenreEntity>();
            authorList.Add(new BookAuthorEntity { AuthorId = (await postAuthor()).Id });
            genreList.Add(new BookGenreEntity { GenreId = (await postGenre()).Id });

            var Book = new BookEntity
            {
                Name = "JoaoDoJeitoCerto",
                Price = 10,
                ListBookAuthor = authorList,
                ListBookGenres = genreList
            };
            var responsePost = await _bookController.Post(Book);
            var respPost = (BookEntity)(((OkObjectResult)((ActionResult<BookEntity>)responsePost).Result).Value);

            var responseGet = await _bookController.Get(respPost.Id);
            var respGet = (BookEntity)(((OkObjectResult)((ActionResult<BookEntity>)responseGet).Result).Value);

            var bookAuthorId = respGet.ListBookAuthor.SingleOrDefault().AuthorId;
            var authorId = authorList.SingleOrDefault().AuthorId;

            var bookGenreId = respGet.ListBookGenres.SingleOrDefault().GenreId;
            var genreId = genreList.SingleOrDefault().GenreId;

            var responseGetAll = (OkObjectResult)await _bookController.GetAll();
            var respGetAll = responseGetAll.Value.GetType()
                .GetProperty("Count")
                .GetValue(responseGetAll.Value);


            Assert.AreEqual(200, (int)((OkObjectResult)responsePost).StatusCode);
            Assert.AreEqual(200, (int)((OkObjectResult)responseGet).StatusCode);
            Assert.AreEqual(respGet.Id, respPost.Id);
            Assert.AreEqual(bookAuthorId, authorId);
            Assert.AreEqual(bookGenreId, genreId);

        }

        [TestMethod]
        public async Task ShouldPostBookWithMultipleAuthorAndGenre()
        {
            var authorList = new List<BookAuthorEntity>();
            var genreList = new List<BookGenreEntity>();
            authorList.Add(new BookAuthorEntity { AuthorId = (await postAuthor()).Id });
            authorList.Add(new BookAuthorEntity { AuthorId = (await postAuthor()).Id });
            authorList.Add(new BookAuthorEntity { AuthorId = (await postAuthor()).Id });
            genreList.Add(new BookGenreEntity { GenreId = (await postGenre()).Id });
            genreList.Add(new BookGenreEntity { GenreId = (await postGenre()).Id });
            genreList.Add(new BookGenreEntity { GenreId = (await postGenre()).Id });

            var book = new BookEntity
            {
                Name = "JoaoDoJeitoCerto",
                Price = 10,
                ListBookAuthor = authorList,
                ListBookGenres = genreList
            };
            var responsePost = await _bookController.Post(book);
            var respPost = (BookEntity)(((OkObjectResult)((ActionResult<BookEntity>)responsePost).Result).Value);

            var responseGet = await _bookController.Get(respPost.Id);
            var respGet = (BookEntity)(((OkObjectResult)((ActionResult<BookEntity>)responseGet).Result).Value);


            for (int i = 0; i < respGet.ListBookAuthor.Count; i++)
            {
                Assert.IsTrue(respGet.ListBookAuthor[i].AuthorId == authorList[i].AuthorId);
            }

            foreach (var bookGenre in respGet.ListBookGenres)
            {
                Assert.IsTrue(genreList.Contains(bookGenre));
            }

            Assert.AreEqual(200, (int)((OkObjectResult)responsePost).StatusCode);
            Assert.AreEqual(200, (int)((OkObjectResult)responseGet).StatusCode);
            Assert.AreEqual(respGet.Id, respPost.Id);
        }

        private async Task<AuthorEntity> postAuthor()
        {
            AuthorEntity author = new AuthorEntity
            {
                Name = "JoaoDoJeitoCerto"
            };
            var responsePost = await _authorController.Post(author);
            var respPost = (AuthorEntity)(((OkObjectResult)((ActionResult<BookEntity>)responsePost).Result).Value);

            return respPost;
        }

        private async Task<GenreEntity> postGenre()
        {
            GenreEntity genre = new GenreEntity
            {
                Name = "JoaoDoJeitoCerto"
            };
            var responsePost = await _genreController.Post(genre);
            var respPost = (GenreEntity)(((OkObjectResult)((ActionResult<BookEntity>)responsePost).Result).Value);

            return respPost;
        }

        [TestMethod]
        public async Task ShouldPutBookById()
        {
            var authorList = new List<BookAuthorEntity>();
            var genreList = new List<BookGenreEntity>();
            authorList.Add(new BookAuthorEntity { AuthorId = (await postAuthor()).Id });
            genreList.Add(new BookGenreEntity { GenreId = (await postGenre()).Id });

            var Book = new BookEntity
            {
                Name = "JoaoDoJeitoCerto",
                Price = 10,
                ListBookAuthor = authorList,
                ListBookGenres = genreList
            };
            var responsePost = await _bookController.Post(Book);
            var respPost = (BookEntity)(((OkObjectResult)((ActionResult<BookEntity>)responsePost).Result).Value);

            Book.Name = "JoaoAtualizado";

            var responsePut = await _bookController.Put(Book, respPost.Id);
            var respPut = (BookEntity)(((OkObjectResult)((ActionResult<BookEntity>)responsePut).Result).Value);
            
            Assert.AreEqual(200, (int)((OkObjectResult)responsePost).StatusCode);
            Assert.AreEqual(200, (int)((OkObjectResult)responsePut).StatusCode);
            Assert.AreEqual(respPut.Name, Book.Name);
        }

        [TestMethod]
        public async Task ShouldDeleteBookById()
        {
            var authorList = new List<BookAuthorEntity>();
            var genreList = new List<BookGenreEntity>();
            authorList.Add(new BookAuthorEntity { AuthorId = (await postAuthor()).Id });
            genreList.Add(new BookGenreEntity { GenreId = (await postGenre()).Id });

            var Book = new BookEntity
            {
                Name = "JoaoDoJeitoCerto",
                Price = 10,
                ListBookAuthor = authorList,
                ListBookGenres = genreList
            };
            var responsePost = await _bookController.Post(Book);
            var respPost = (BookEntity)(((OkObjectResult)((ActionResult<BookEntity>)responsePost).Result).Value);

            var responseDelete = await _bookController.Delete(respPost.Id);
            var respDelete = (bool)(((OkObjectResult)((ActionResult<BookEntity>)responseDelete).Result).Value);

            var responseGet = await _bookController.Get(respPost.Id);

            Assert.AreEqual(200, (int)((OkObjectResult)responsePost).StatusCode);
            Assert.AreEqual(200, (int)((OkObjectResult)responseDelete).StatusCode);
            Assert.IsTrue(respDelete);
            Assert.IsInstanceOfType(responseGet, typeof(NotFoundResult));
        }
        [TestMethod]
        public async Task ShouldFindAllBookAndDelete()
        {

            var responseGetAll = (OkObjectResult)await _bookController.GetAll();
            var respGetAll = (IEnumerable<BookEntity>)(((OkObjectResult)((ActionResult<BookEntity>)responseGetAll).Result).Value);

            foreach (BookEntity Book in respGetAll)
            {
                var responseDelete = await _bookController.Delete(Book.Id);
                var respDelete = (bool)(((OkObjectResult)((ActionResult<BookEntity>)responseDelete).Result).Value);
                Assert.IsTrue(respDelete);
            }

            var responseGetAll2 = (OkObjectResult)await _bookController.GetAll();
            var valueGetAll = responseGetAll2.Value.GetType()
                .GetProperty("Count")
                .GetValue(responseGetAll2.Value);

            Assert.AreEqual(0, valueGetAll);

        }

    }
}
