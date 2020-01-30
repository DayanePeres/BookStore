using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Services;

namespace BookStore.Application.Controllers
{

    public class BookController : BaseController<BookEntity>
    {
        public BookController(IBookService service) : base(service)
        {
        }
    }

}
