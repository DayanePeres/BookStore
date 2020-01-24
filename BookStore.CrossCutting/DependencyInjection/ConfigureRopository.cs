using BookStore.Data.Context;
using BookStore.Data.Repository;
using BookStore.Domain.Interfaces;
using BookStore.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.CrossCutting.DependencyInjection
{
    public class ConfigureRopository
    {
        public static void ConfigureDependeciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            serviceCollection.AddScoped<IAuthorRepository,AuthorRepository>();
            serviceCollection.AddScoped<IGenreRepository, GenreRepository>();
            serviceCollection.AddScoped<IBookRepository, BookRepository>();

            serviceCollection.AddDbContext<MyContext>(
             options => options.UseSqlServer("Server=localhost,11433;Database=BookStore;Uid=SA;Pwd=DockerSql2017!;"));

        }
    }
}
