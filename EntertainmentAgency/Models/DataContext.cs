using Microsoft.EntityFrameworkCore;

namespace EntertainmentAgency.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }

        public DbSet<Entertainer> Entertainers { get; set;}
    }
}
