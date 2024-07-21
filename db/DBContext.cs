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
}