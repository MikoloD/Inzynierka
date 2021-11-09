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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Road>()
                .HasOne(x => x.SourceNode)
                .WithMany(x => x.SourceRoads)
                .HasForeignKey(x => x.SourceNodeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Road>()
                .HasOne(x => x.TargetNode)
                .WithMany(x => x.TargetRoads)
                .HasForeignKey(x => x.TargetNodeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
