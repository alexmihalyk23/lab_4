using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using jijaWEB.Data;

namespace jijaWEB.Data
{
    public class jijaWEBContext : DbContext
    {
        public jijaWEBContext (DbContextOptions<jijaWEBContext> options)
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
