using MotoGP.Models;
using Microsoft.EntityFrameworkCore;

namespace MotoGP.Data
{
    public class GPContext : DbContext
    {
        public GPContext(DbContextOptions<GPContext> options) : base(options) { }

        public DbSet<Race> Races { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Rider> Riders { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Race>().ToTable("Race");
            modelBuilder.Entity<Ticket>().ToTable("Ticket");
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<Rider>().ToTable("Rider");
            modelBuilder.Entity<Team>().ToTable("Team");

        }
    }
}
