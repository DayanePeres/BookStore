using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookStore.Data.Context
{
    public class DataContext : IDesignTimeDbContextFactory <MyContext>
    {

        public MyContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=localhost;Database=DbBookStore;Trusted_Connection=True";

            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new MyContext(optionsBuilder.Options);
        }
    }
}
