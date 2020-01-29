using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookStore.Data.Context
{
    public class DataContext : IDesignTimeDbContextFactory <MyContext>
    {

        public MyContext CreateDbContext(string[] args)
        {

            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            if (!string.IsNullOrEmpty(EnvironmentProperties.ConnectionString))
            {
                optionsBuilder.UseSqlServer(EnvironmentProperties.ConnectionString);
            }
            else
            {
                optionsBuilder.UseInMemoryDatabase(EnvironmentProperties.DatabaseName);
            }

            return new MyContext(optionsBuilder.Options);
        }

       
    }
}
