using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace restate.RealEstateManagement.Models;

public enum EstateUnitType
{
  RESIDENTIAL,
  COMMERCIAL
}
public class EstateUnit
{
    public int Id { get; set; }

    [Required]
    // Unique per Real Estate
    public string Name { get; set; }

    [DisplayName("Unit Number")]
    // Unique per Real Estate
    public string UnitNumber { get; set; }

    public float Area { get; set; }

    // forbid Residential if real estate is commercial
    public EstateUnitType Type { get; set; }

    public RealEstate RealEstate { get; set; }
    public int RealEstateId { get; set; }

    public string Address {
        get {
            if(RealEstate is not null)
            {
                return $"{RealEstate.Street} {RealEstate.HouseNumber}/{UnitNumber} {RealEstate.City}";
            }
            return "";
        }
    }

    public EstateUnit() { }

    public EstateUnit(
        int id,
        string name,
        string unitNumber,
        float area,
        EstateUnitType type,
        RealEstate realEstate
    )
    {
        Id = id;
        Name = name;
        UnitNumber = unitNumber;
        Area = area;
        Type = type;
        RealEstate = realEstate;
    }
}