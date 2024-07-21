using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using restate.RealEstateManagement.Validators;

namespace restate.RealEstateManagement.Models;

public enum RealEstateType
{
    RESIDENTIAL,
    COMMERCIAL,
    GOVERNAMENTAL,
    MIX_USE
}

[Index(nameof(Name), IsUnique = true)]
public class RealEstate
    {
    public int Id { get; set; }

    [Required]
    // [UniqueValidator]
    public string Name { get; set; }

    [Required]
    public string City { get; set; }

    public string Street { get; set; }

    [DisplayName("House Number")]
    public string HouseNumber { get; set; }

    [DisplayName("Postal Code")]
    public string PostalCode { get; set; }

    public float Area { get; set; }

    [DisplayName("Type of Real Estate")]
    public RealEstateType Type { get; set; }


    public RealEstate() {}

    public RealEstate(int id, string name, string city, string street, string number, string zip, float area, RealEstateType type)
    {
        Id = id;
        Name = name;
        City = city;
        Street = street;
        HouseNumber = number;
        PostalCode = zip;
        Area = area;
        Type = type;
    }
}