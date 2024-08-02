using Microsoft.EntityFrameworkCore;
using restate.RealEstateManagement.Models;

namespace restate.db;

public class AppDbContext : DbContext
{
    public AppDbContext() {}

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public virtual DbSet<RealEstate> RealEstates { get; set; }
    public virtual DbSet<EstateUnit> EstateUnits { get; set; }
    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserAccess> UserAccesses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserAccess>().HasKey(userAccess=> new { userAccess.UserId, userAccess.RealEstateId });
    }
}