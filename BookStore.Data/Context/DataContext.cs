using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookStore.Data.Context
{
    public class DataContext : IDesignTimeDbContextFactory <MyContext>
    {

        public MyContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=localhost,11433;Database=BookStore;Uid=SA;Pwd=DockerSql2017!;";

            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new MyContext(optionsBuilder.Options);
        }
    }
}
