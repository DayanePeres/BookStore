using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookStore.Data.Context
{
    public class DataContext : IDesignTimeDbContextFactory <MyContext>
    {

        public MyContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<MyContext> context = getOptionBuilder(string.IsNullOrEmpty(EnvironmentProperties.ConnectionString));
            return new MyContext(context.Options);
            //
        }

        private DbContextOptionsBuilder<MyContext> getOptionBuilder(bool isDev)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            return isDev  == true ? optionsBuilder.UseInMemoryDatabase(EnvironmentProperties.DataBaseName) : optionsBuilder.UseSqlServer(EnvironmentProperties.ConnectionString);
        }

       
    }
}
