using Microsoft.EntityFrameworkCore;
using NewProject.Models;
namespace NewProject.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Character> Characters => Set<Character>();
    }
}
