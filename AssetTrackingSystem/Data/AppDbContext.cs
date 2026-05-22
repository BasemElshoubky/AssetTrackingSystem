using AssetTrackingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetTrackingSystem.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<ComputerAsset> ComputerAssets { get; set; }

        public DbSet<MobileAsset> MobileAssets { get; set; }

        public DbSet<Office> Offices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=AssetTrackingDB;Trusted_Connection=True;");
        }
    }
}