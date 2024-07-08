using restate.RealEstateManagement.Models;

namespace restate.db.Seeds;

public class RealEstates
{
    public static void Seed(AppDbContext context)
    {
        if (context.RealEstates.Any())
        {
        return;
        }

        context.RealEstates.AddRange(
            new RealEstate
            {
                Name = "Berlin House 1",
                City = "Berlin",
                Street = "Hoffstrasse",
                HouseNumber = "1",
                PostalCode = "00001",
                Area = 1000,
                Type = RealEstateType.RESIDENTIAL
            },
            new RealEstate
            {
                Name = "Berlin House 2",
                City = "Berlin",
                Street = "Hoffstrasse",
                HouseNumber = "2",
                PostalCode = "00001",
                Area = 1000,
                Type = RealEstateType.RESIDENTIAL
            },
            new RealEstate
            {
                Name = "Berlin House 3",
                City = "Berlin",
                Street = "Ruschestrass",
                HouseNumber = "1",
                PostalCode = "00001",
                Area = 200,
                Type = RealEstateType.COMMERCIAL
            },
            new RealEstate
            {
                Name = "Paris House 1",
                City = "Paris",
                Street = "Faubourg Saint Honoré",
                HouseNumber = "1",
                PostalCode = "75000",
                Area = 2000,
                Type = RealEstateType.RESIDENTIAL
            },
            new RealEstate
            {
                Name = "Paris House 2",
                City = "Paris",
                Street = "Rue de Strasbourg",
                HouseNumber = "13",
                PostalCode = "75000",
                Area = 2000,
                Type = RealEstateType.RESIDENTIAL
            },
            new RealEstate
            {
                Name = "Warsaw House 1",
                City = "Warsaw",
                Street = "Bracka",
                HouseNumber = "13",
                PostalCode = "00-001",
                Area = 2000,
                Type = RealEstateType.RESIDENTIAL
            },
            new RealEstate
            {
                Name = "Warsaw House 2",
                City = "Warsaw",
                Street = "Asfaltowa",
                HouseNumber = "7",
                PostalCode = "00-001",
                Area = 2000,
                Type = RealEstateType.RESIDENTIAL
            },
            new RealEstate
            {
                Name = "Warsaw Commerce 2",
                City = "Warsaw",
                Street = "Ligocka",
                HouseNumber = "5",
                PostalCode = "00-001",
                Area = 200,
                Type = RealEstateType.COMMERCIAL
            }

        );
        context.SaveChanges();
    }
}
  