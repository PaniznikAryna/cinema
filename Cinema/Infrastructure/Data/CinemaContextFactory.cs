using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Cinema.Infrastructure.Data
{
    public class CinemaContextFactory : IDesignTimeDbContextFactory<CinemaContext>
    {
        public CinemaContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CinemaContext>();

            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=cinema_db;Username=postgres;Password=");

            return new CinemaContext(optionsBuilder.Options);
        }
    }
}
