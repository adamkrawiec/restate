using rest.db.Seeds;
using restate.db.Seeds;

namespace restate.db;
public class Seed
{
    public static void SeedData(AppDbContext context)
    {
        RealEstates.Seed(context);
        EstateUnits.Seed(context);
        Users.Seed(context);
    }
}