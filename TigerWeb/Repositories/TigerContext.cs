using Microsoft.EntityFrameworkCore;
using TigerWeb.Models;

namespace TigerWeb.Repositories
{
    public class TigerContext: DbContext
    {
        public TigerContext(DbContextOptions<TigerContext> options)
            : base(options)
        { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
