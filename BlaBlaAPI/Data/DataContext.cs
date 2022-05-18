using Microsoft.EntityFrameworkCore;

namespace BlaBlaAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<BlaBla> BlaBlas { get; set; }
    }
}
