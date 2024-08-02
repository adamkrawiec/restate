using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace restate.RealEstateManagement.Models;

public class UserAccess
{
    [Key, Column(Order = 0)]
    public int UserId;
    public User User;

    [Key, Column(Order = 1)]
    public int RealEstateId;
    public RealEstate RealEstate;

    public UserAccess() {}

    public UserAccess(int userId, int realEstateId)
    {
        UserId = userId;
        RealEstateId = realEstateId;
    }
}