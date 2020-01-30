using Autofac.Core;
using BookStore.Api;
using BookStore.Data;
using BookStore.Data.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MsTestIntegration
{

    // Classe necessária para criar o banco de dados em memória e assim fazer os teste de integração
    public class Startup <TStartup> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices
                (services =>
                    {
                        var serviceProvaider = new ServiceCollection()
                        .AddEntityFrameworkInMemoryDatabase()
                        .BuildServiceProvider();

                        services.AddDbContext<MyContext>(options =>
                        {
                            options.UseInMemoryDatabase(EnvironmentProperties.DataBaseName);
                            options.UseInternalServiceProvider(serviceProvaider);

                        });

                        var sp = services.BuildServiceProvider();
                        using (var scope = sp.CreateScope()){
                            var scopedServices = scope.ServiceProvider;
                            var appDb = scopedServices.GetRequiredService<MyContext>();
                            appDb.Database.EnsureCreated();
                        }
                    }
                );
        }
    }
}
