using System.ComponentModel.DataAnnotations;

namespace restate.RealEstateManagement.Models;

public enum RealEstateType
{
  RESIDENTIAL,
  COMMERCIAL,
  GOVERNAMENTAL,
  MIX_USE
}

public class RealEstate
{
  public int Id { get; set; }
  [Required]
  public string Name { get; set; }
  [Required]
  public string City { get; set; }
  public string Street { get; set; }
  public string HouseNumber { get; set; }
  public string PostalCode { get; set; }
  public float Area { get; set; }
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