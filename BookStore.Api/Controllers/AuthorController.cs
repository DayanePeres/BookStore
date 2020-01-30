using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Services;

namespace BookStore.Application.Controllers
{
    public class AuthorController : BaseController<AuthorEntity>
    {
        public AuthorController(IAuthorService service) : base(service)
        {
        }
    }
}
