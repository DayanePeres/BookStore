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
            ConnectionString.SetDev();
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
            var getAllResponse = (ObjectResult) await _bookController.GetAll();

            var bookList = (IEnumerable<BookEntity>) getAllResponse.Value;

            Assert.AreEqual(200, getAllResponse.StatusCode);
            Assert.AreEqual(0, bookList.Count());
        }

        [TestMethod]
        public async Task ShouldPostBookWithSingleAuthorAndGenre()
        {
            var authorList = new List<BookAuthorEntity>();
            var genreList = new List<BookGenreEntity>();

            authorList.Add(new BookAuthorEntity { AuthorId = (await PostAuthor()).Id });
            genreList.Add(new BookGenreEntity { GenreId = (await PostGenre()).Id });

            var book = new BookEntity //Criando o livro
            {
                Name = "HarryPotter I",
                Price = 10,
                ListBookAuthor = authorList,
                ListBookGenres = genreList
            };

            var postResponse = (ObjectResult) await _bookController.Post(book); //Inserindo no banco na mémoria
            book = (BookEntity) postResponse.Value;

            var getResponse = (ObjectResult) await _bookController.Get(book.Id);
            var bookResponse = (BookEntity) getResponse.Value;

            var bookAuthorId = bookResponse.ListBookAuthor.SingleOrDefault()?.AuthorId;
            var authorId = authorList.SingleOrDefault()?.AuthorId;

            var bookGenreId = bookResponse.ListBookGenres.SingleOrDefault()?.GenreId;
            var genreId = genreList?.SingleOrDefault()?.GenreId;
            
            Assert.AreEqual(200, postResponse.StatusCode);
            Assert.AreEqual(200, getResponse.StatusCode);
            Assert.AreEqual(bookResponse.Id, book.Id);
            Assert.AreEqual(bookAuthorId, authorId);
            Assert.AreEqual(bookGenreId, genreId);

        }

        [TestMethod]
        public async Task ShouldPostBookWithMultipleAuthorAndGenre()
        {
            var authorList = new List<BookAuthorEntity>();
            var genreList = new List<BookGenreEntity>();

            authorList.Add(new BookAuthorEntity { AuthorId = (await PostAuthor()).Id });
            authorList.Add(new BookAuthorEntity { AuthorId = (await PostAuthor()).Id });
            authorList.Add(new BookAuthorEntity { AuthorId = (await PostAuthor()).Id });
            genreList.Add(new BookGenreEntity { GenreId = (await PostGenre()).Id });
            genreList.Add(new BookGenreEntity { GenreId = (await PostGenre()).Id });
            genreList.Add(new BookGenreEntity { GenreId = (await PostGenre()).Id });

            var book = CreateBook(authorList, genreList);
           
            var postResponse = (ObjectResult) await _bookController.Post(book);
            book = (BookEntity) postResponse.Value;

            var getResponse = (ObjectResult) await _bookController.Get(book.Id);
            var bookResponse = (BookEntity) getResponse.Value;


            foreach (var bookAuthor in book.ListBookAuthor)
            {
                Assert.IsTrue(authorList.Contains(bookAuthor));
            }

            foreach (var bookGenre in book.ListBookGenres)
            {
                Assert.IsTrue(genreList.Contains(bookGenre));
            }

            Assert.AreEqual(200, postResponse.StatusCode);
            Assert.AreEqual(200, getResponse.StatusCode);
            Assert.AreEqual(book.Id, bookResponse.Id);
        }

        private async Task<AuthorEntity> PostAuthor()
        {
            var author = new AuthorEntity
            {
                Name = "J.K Rowling"
            };
            var postResponse = (ObjectResult) await _authorController.Post(author);
            var authorResponse = (AuthorEntity) postResponse.Value;

            return authorResponse;
        }

        private async Task<GenreEntity> PostGenre()
        {
            var genre = new GenreEntity
            {
                Name = "Adventure"
            };
            var postResponse = (ObjectResult) await _genreController.Post(genre);
            var genreResponse = (GenreEntity) postResponse.Value;

            return genreResponse;
        }

        [TestMethod]
        public async Task ShouldPutBookById()
        {
            var authorList = new List<BookAuthorEntity>();
            var genreList = new List<BookGenreEntity>();
            authorList.Add(new BookAuthorEntity { AuthorId = (await PostAuthor()).Id });
            genreList.Add(new BookGenreEntity { GenreId = (await PostGenre()).Id });

            var book = CreateBook(authorList, genreList);
            var postResponse = (ObjectResult) await _bookController.Post(book);
            var bookResponse = (BookEntity)postResponse.Value;

            book.Name = "JoaoAtualizado"; //Alterando nome

            var putResponse = (ObjectResult) await _bookController.Put(book, bookResponse.Id);
            bookResponse = (BookEntity) putResponse.Value;
            
            Assert.AreEqual(200,  postResponse.StatusCode);
            Assert.AreEqual(200,  putResponse.StatusCode);
            Assert.AreEqual(bookResponse.Name, book.Name);
        }

        [TestMethod]
        public async Task ShouldDeleteBookById()
        {
            var authorList = new List<BookAuthorEntity>();
            var genreList = new List<BookGenreEntity>();
            authorList.Add(new BookAuthorEntity { AuthorId = (await PostAuthor()).Id });
            genreList.Add(new BookGenreEntity { GenreId = (await PostGenre()).Id });

            var book = CreateBook(authorList, genreList);

            var postResponse = (ObjectResult) await _bookController.Post(book);
            book = (BookEntity) postResponse.Value;

            var deleteResponse = (ObjectResult) await _bookController.Delete(book.Id);
            var isDeleted = (bool) deleteResponse.Value;

            var getResponse = await _bookController.Get(book.Id);

            Assert.AreEqual(200, postResponse.StatusCode);
            Assert.AreEqual(200, deleteResponse.StatusCode);
            Assert.IsTrue(isDeleted);
            Assert.IsInstanceOfType(getResponse, typeof(NotFoundResult)); //Consultar obj deletado não deve retorn\r
        }
        [TestMethod]
        public async Task ShouldFindAllBookAndDelete()
        {

            var getAllResponse = (ObjectResult) await _bookController.GetAll();
            var bookList = (IEnumerable<BookEntity>) getAllResponse.Value;

            foreach (var book in bookList)
            {
                var deleteResponse = (ObjectResult) await _bookController.Delete(book.Id);
                var isDeleted = (bool) deleteResponse.Value;
                Assert.IsTrue(isDeleted);
            }

            getAllResponse = (ObjectResult) await _bookController.GetAll();
            bookList = (IEnumerable<BookEntity>) getAllResponse.Value;

            Assert.AreEqual(0, bookList.Count());

        }

        private BookEntity CreateBook(List<BookAuthorEntity> bookAuthorEntities, List<BookGenreEntity> bookGenreEntities)
        {
            return  new BookEntity
            {
                Name = "HarryPotter II",
                Price = 10,
                ListBookAuthor = bookAuthorEntities,
                ListBookGenres = bookGenreEntities
            };
        }

    }
}
