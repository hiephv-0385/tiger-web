using Microsoft.EntityFrameworkCore;
using Tiger.Data.Entities;

namespace Tiger.Data
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
