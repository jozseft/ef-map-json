using MapJSON.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MapJSON.Data.Context
{
    public class MapJSONContext : DbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Trip> Trips { get; set; }
        public MapJSONContext(DbContextOptions<MapJSONContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>()
                .OwnsOne(
                    appUser => appUser.UserSettings, ownedNavigationBuilder =>
                    {
                        ownedNavigationBuilder.ToJson();
                        ownedNavigationBuilder.OwnsOne(settings => settings.Theme);
                        ownedNavigationBuilder.OwnsMany(
                            settings => settings.Tables,
                            ownedOwnedNavigationBuilder => ownedOwnedNavigationBuilder.OwnsMany(table => table.Columns));

                    });

            modelBuilder.Entity<Trip>().OwnsMany(trip => trip.Transits, ownedNavigationBuilder => ownedNavigationBuilder.ToJson());
        }
    }
}

