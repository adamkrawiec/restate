using Microsoft.EntityFrameworkCore;
using restate.db;
using Microsoft.Extensions.Configuration;

namespace Restate.Tests.RealEstateManagement.Controllers;

public class DbHelper
{
    public static AppDbContext CreateContext()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.Test.json")
            .Build();
        var connectionString = config["ConnectionStrings:restatedb"];

        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql(connectionString); 
        var context = new AppDbContext(optionsBuilder.Options);
        context.Database.EnsureDeleted();
        context.Database.Migrate();

        return context;
    }
}