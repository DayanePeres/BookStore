using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using BookStore.Domain.Interfaces.Services;

namespace BookStore.Service.Services
{
    public class AuthorService : BaseService<AuthorEntity>, IAuthorService
    {
        public AuthorService(IBaseRepository<AuthorEntity> baseRepository) : base(baseRepository)
        {
        }
    }
}
