using Microsoft.EntityFrameworkCore;

namespace jijaWEB.Data
{
    public class jijaWEBContext : DbContext
    {
        public jijaWEBContext(DbContextOptions<jijaWEBContext> options)
            : base(options)
        {
        }

        public DbSet<jijaWEB.Data.Users> Users { get; set; }

        public DbSet<jijaWEB.Data.Role> Role { get; set; }

        public DbSet<jijaWEB.Data.Basket> Basket { get; set; }

        public DbSet<jijaWEB.Data.Goods> Goods { get; set; }

        public DbSet<jijaWEB.Data.Category> Category { get; set; }

    }
}
