using restate.db.Seeds;

namespace restate.db;
public class Seed
{
    public static void SeedData(AppDbContext context)
    {
        RealEstates.Seed(context);
    }
}