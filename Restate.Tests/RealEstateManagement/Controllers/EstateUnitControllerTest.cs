using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restate.db;
using restate.RealEstateManagement.Controllers;
using restate.RealEstateManagement.Models;
using Microsoft.Extensions.Configuration;

namespace Restate.Tests.RealEstateManagement.Controllers;

[Collection("Database collection")]
public class EstateUnitControllerTest
{
    private readonly DbContextOptions<AppDbContext> _options;
    private readonly RealEstate _realEstate;
    private readonly DatabaseFixture _databaseFixture;
    private readonly AppDbContext _context;

    public EstateUnitControllerTest(DatabaseFixture fixture)
    {
        _databaseFixture = fixture;
        _context = _databaseFixture.GetContext();
        _realEstate = newRealEstate("Berlin House 1");

        _context.EstateUnits.AddRange(
            newEstateUnit("Unit 1", _realEstate),
            newEstateUnit("Unit 2", _realEstate)
        );
        _context.SaveChanges();
    }

    [Fact]
    public async Task Get_Index()
    {
        var controller = new EstateUnitController(_context);
        var response = await controller.Index(_realEstate.Id, null);
        var result = response as ViewResult;
        var model = result.Model as List<EstateUnit>;
        Assert.Equal(2, model.Count);
        Assert.Equal("Unit 1", model[0].Name);
    }

    private RealEstate newRealEstate( string? name)
    {
        return new RealEstate
        {
            Name = name,
            City = "Berlin",
            Street = "Hoffstrasse",
            HouseNumber = "1",
            PostalCode = "00001",
            Area = 1000,
            Type = RealEstateType.RESIDENTIAL
        };
    }

    private EstateUnit newEstateUnit(string name, RealEstate realEstate)
    {
        return new EstateUnit
        {
            Name = name,
            RealEstate = realEstate,
            Area = 100,
            UnitNumber = "1a"
        };
    }

    [Fact]
    public async Task Post_Create()
    {
        var controller = new EstateUnitController(_context);
        EstateUnit estateUnit = newEstateUnit( "Unit 1", _realEstate);

        var response = await controller.Create(estateUnit, _realEstate.Id);
        var result = response as RedirectToActionResult;
        Assert.Equal("Index", result.ActionName);
        Assert.Equal(3, _context.EstateUnits.Count());
    }
}