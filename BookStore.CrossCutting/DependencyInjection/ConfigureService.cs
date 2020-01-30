using BookStore.Data.Repository;
using BookStore.Domain.Interfaces;
using BookStore.Domain.Interfaces.Services;
using BookStore.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependeciesService(IServiceCollection servicecollection)
        {

            servicecollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            servicecollection.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            servicecollection.AddScoped<IBookService, BookService>();
            servicecollection.AddScoped<IAuthorService, AuthorService>();
            servicecollection.AddScoped<IGenreService, GenreService>();
            
        }
    }
}