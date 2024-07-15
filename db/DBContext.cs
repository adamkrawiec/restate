using Microsoft.EntityFrameworkCore;
using restate.RealEstateManagement.Models;

namespace restate.db;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<RealEstate> RealEstates { get; set; }
    public DbSet<EstateUnit> EstateUnits { get; set; }
}