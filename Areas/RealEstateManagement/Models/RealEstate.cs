namespace restate.RealEstateManagement.Models;

public enum RealEstateType
{
  RESIDENTIAL,
  COMMERCIAL,
  GOVERNAMENTAL
}

public class RealEstate
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string City { get; set; }
  public string Street { get; set; }
  public string Number { get; set; }
  public string Zip { get; set; }
  public float Area { get; set; }
  public RealEstateType Type { get; set; }


  public RealEstate() {}

  public RealEstate(int id, string name, string city, string street, string number, string zip, float area, RealEstateType type)
  {
    Id = id;
    Name = name;
    City = city;
    Street = street;
    Number = number;
    Zip = zip;
    Area = area;
    Type = type;
  }
  
}