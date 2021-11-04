using Database.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Road> Roads { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options) { }
    }
}
