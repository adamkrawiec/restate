using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using restate.db;

namespace Restate.Tests;

public class DatabaseFixture : IDisposable
{
    public AppDbContext Context;

    public DatabaseFixture()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.Test.json")
            .Build();
        var connectionString = config["ConnectionStrings:restatedb"];

        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql(connectionString); 
        var context = new AppDbContext(optionsBuilder.Options);
        context.Database.Migrate();

        Context = context;
    }

    public void Dispose()
    {
        Context.Database.EnsureDeleted();
    }

    public AppDbContext GetContext()
    {
        Context.Database.ExecuteSqlRaw("delete from \"EstateUnits\"");
        Context.Database.ExecuteSqlRaw("delete from \"RealEstates\"");

        return Context;
    }
}