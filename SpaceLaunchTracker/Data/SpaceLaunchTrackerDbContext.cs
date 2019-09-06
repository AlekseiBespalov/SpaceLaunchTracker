using Microsoft.EntityFrameworkCore;
using SpaceLaunchTracker.Data.DataModels;

namespace SpaceLaunchTracker.Data
{
    public class SpaceLaunchTrackerDbContext : DbContext
    {
        public DbSet<LaunchDto> Launches { get; set; }
        public DbSet<AgencyDto> Agencies { get; set; }
        public DbSet<CountryDto> Countries { get; set; }

        public SpaceLaunchTrackerDbContext(DbContextOptions<SpaceLaunchTrackerDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryDto>()
                .HasMany(c => c.Agencies)
                .WithOne(e => e.Country);
            modelBuilder.Entity<CountryDto>()
                .HasMany(c => c.Launches)
                .WithOne(e => e.Country);
            modelBuilder.Entity<AgencyDto>()
                .HasMany(l => l.Launches)
                .WithOne(a => a.Agency);
        }
    }
}
