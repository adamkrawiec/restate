using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restate.db;
using restate.RealEstateManagement.Controllers;
using restate.RealEstateManagement.Models;
using Moq;
using Moq.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Restate.Tests.RealEstateManagement.Controllers;

[Collection("Database collection")]
public class RealEstateControllerTest
{
    private readonly DatabaseFixture _databaseFixture;
    private readonly AppDbContext _context;

    public RealEstateControllerTest(DatabaseFixture fixture)
    {
        _databaseFixture = fixture;
        _context = _databaseFixture.GetContext();

        _context.RealEstates.AddRange(
            newRealEstate("Berlin House 1"),
            newRealEstate("Berlin House 2")
        );
        _context.SaveChanges();
    }

    [Fact]
    public async Task Get_Index()
    {
        var controller = new RealEstateController(_context);
        var response = await controller.Index();
        Assert.IsType<ViewResult>(response);
    
        var result = response as ViewResult;
        var model = result.Model as List<RealEstate>;
        Assert.Equal(2, model.Count);
        Assert.Equal("Berlin House 1", model[0].Name);

    }

    [Fact]
    public async Task Post_Create()
    {
        var controller = new RealEstateController(_context);

        var realEstate = newRealEstate("Berlin House 3");
        var response = await controller.Create(realEstate);
        var result = response as RedirectToActionResult;
        Assert.IsType<RedirectToActionResult>(response);
        Assert.Equal("Index", result.ActionName);
        Assert.Equal(3, _context.RealEstates.Count());
    }

    // [Fact]
    // public async Task Post_Create_WhenInvalid()
    // {
    //     var controller = new RealEstateController(_context);
    //     var realEstate = newRealEstate(null);

    //     var response = await controller.Create(realEstate);

    //     Assert.IsType<ViewResult>(response);
    // }

    [Fact]
    public async Task Get_ShowDetails()
    {
        var controller = new RealEstateController(_context);

        var response = await controller.ShowDetails(1);
        var result = response as ViewResult;
        var model = result.Model as RealEstate;
        Assert.Equal("Berlin House 1", model.Name);

    }

    [Fact]
    public async Task Put_UpdateDetails()
    {
        var controller = new RealEstateController(_context);

        RealEstate realEstate = newRealEstate("Berlin House XX");

        _context.RealEstates.Add(realEstate);
        await _context.SaveChangesAsync();
        _context.Entry(realEstate).State = EntityState.Detached;

        var realEstateParams = newRealEstate( "Berlin House 22");
        realEstateParams.Id = realEstate.Id;

        var response = await controller.UpdateRealEstate(realEstate.Id, realEstateParams);
        Assert.IsType<RedirectToActionResult>(response);
        Assert.Equal("Index", (response as RedirectToActionResult).ActionName);
        
        var updatedRealEstate = await _context.RealEstates.FindAsync(realEstate.Id);
        Assert.Equal("Berlin House 22", updatedRealEstate.Name);
    }

    private RealEstate newRealEstate(string? name)
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
}