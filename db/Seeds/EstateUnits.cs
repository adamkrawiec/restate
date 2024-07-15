using restate.db;
using restate.RealEstateManagement.Models;

namespace rest.db.Seeds;

public class EstateUnits
{
    public static void Seed(AppDbContext context)
    {
        if(context.EstateUnits.Any()) { return; }

        context.EstateUnits.AddRange(
            new EstateUnit
            {
                Name = "House 1",
                UnitNumber = "1",
                Area = 70,
                Type = EstateUnitType.RESIDENTIAL,
                RealEstate = context.RealEstates.Find(1)
            },
            new EstateUnit
            {
                Name = "House 2",
                UnitNumber = "2",
                Area = 50,
                Type = EstateUnitType.RESIDENTIAL,
                RealEstate = context.RealEstates.Find(1)
            },
            new EstateUnit
            {
                Name = "House 3",
                UnitNumber = "3",
                Area = 70,
                Type = EstateUnitType.RESIDENTIAL,
                RealEstate = context.RealEstates.Find(1),
            },
            new EstateUnit
            {
                Name = "House 1",
                UnitNumber = "1",
                Area = 50,
                Type = EstateUnitType.RESIDENTIAL,
                RealEstate = context.RealEstates.Find(2),
            },
            new EstateUnit
            {
                Name = "Commercial Unit 1",
                UnitNumber = "2",
                Area = 120,
                Type = EstateUnitType.COMMERCIAL,
                RealEstate = context.RealEstates.Find(2),
            },
            new EstateUnit
            {
                Name = "House 2",
                UnitNumber = "3",
                Area = 70,
                Type = EstateUnitType.RESIDENTIAL,
                RealEstate = context.RealEstates.Find(2)
            },
            new EstateUnit
            {
                Name = "Commercial 1",
                UnitNumber = "1",
                Area = 120,
                Type = EstateUnitType.COMMERCIAL,
                RealEstate = context.RealEstates.Find(3)
            },
            new EstateUnit
            {
                Name = "Commercial 3",
                UnitNumber = "2",
                Area = 64,
                Type = EstateUnitType.COMMERCIAL,
                RealEstate = context.RealEstates.Find(3)
            },
            new EstateUnit
            {
                Name = "Commercial 3",
                UnitNumber = "3",
                Area = 82,
                Type = EstateUnitType.COMMERCIAL,
                RealEstate = context.RealEstates.Find(3)
            },
            new EstateUnit
            {
                Name = "Appartment 1",
                UnitNumber = "1",
                Area = 44,
                Type = EstateUnitType.RESIDENTIAL,
                RealEstate = context.RealEstates.Find(4)
            },
            new EstateUnit
            {
                Name = "Appartment 2",
                UnitNumber = "2",
                Area = 58,
                Type = EstateUnitType.RESIDENTIAL,
                RealEstate = context.RealEstates.Find(4)
            },
            new EstateUnit
            {
                Name = "Appartment 3",
                UnitNumber = "3",
                Area = 74,
                Type = EstateUnitType.RESIDENTIAL,
                RealEstate = context.RealEstates.Find(4)
            },
            new EstateUnit
            {
                Name = "Appartment 4",
                UnitNumber = "4",
                Area = 134,
                Type = EstateUnitType.RESIDENTIAL,
                RealEstate = context.RealEstates.Find(4)
            },
            new EstateUnit
            {
                Name = "Appartment 5",
                UnitNumber = "5",
                Area = 89,
                Type = EstateUnitType.RESIDENTIAL,
                RealEstate = context.RealEstates.Find(4)
            }
        );
    context.SaveChanges();
  }
}