using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restate.db;
using restate.RealEstateManagement.Controllers;
using restate.RealEstateManagement.Models;

namespace Restate.Tests.RealEstateManagement.Controllers;

public class RealEstateControllerTest
{
    private readonly AppDbContext _context;
    private readonly RealEstateController _controller;


    public RealEstateControllerTest()
    {
        _context = DbHelper.CreateContext();
        _controller = new RealEstateController(_context);
    }

    [Fact]
    public async Task Get_Index()
    { 
        _context.RealEstates.AddRange(
            newRealEstate(1, "Berlin House 1"),
            newRealEstate(2, "Berlin House 2")
        );
        await _context.SaveChangesAsync();
        var response = await _controller.Index();
        Assert.IsType<ViewResult>(response);
    
        var result = response as ViewResult;
        var model = result.Model as List<RealEstate>;
        Assert.Equal(2, model.Count);
        Assert.Equal("Berlin House 1", model[0].Name);
    }

    [Fact]
    public async Task Post_Create()
    {
        var realEstate = newRealEstate(1, "Berlin House 1");
        var response = await _controller.Create(realEstate);
        var result = response as RedirectToActionResult;
        Assert.IsType<RedirectToActionResult>(response);
        Assert.Equal("Index", result.ActionName);
        Assert.Equal(1, _context.RealEstates.Count());
    }

    [Fact]
    public async Task Post_Create_WhenInvalid()
    {
        var realEstate = newRealEstate(1, null);
        var response = await _controller.Create(realEstate);

        Assert.IsType<ViewResult>(response);
    }

    [Fact]
    public async Task Get_ShowDetails()
    {
        _context.RealEstates.Add(newRealEstate(1, "Berlin House 1"));
        await _context.SaveChangesAsync();
        var response = await _controller.ShowDetails(1);
        Assert.IsType<ViewResult>(response);
        var result = response as ViewResult;
        var model = result.Model as RealEstate;
        Assert.Equal("Berlin House 1", model.Name);
    }

    [Fact]
    public async Task Put_UpdateDetails()
    {
        RealEstate realEstate = newRealEstate(1, "Berlin House 1");

        _context.RealEstates.Add(realEstate);
        await _context.SaveChangesAsync();
        _context.Entry(realEstate).State = EntityState.Detached;

        var realEstateParams = newRealEstate(1, "Berlin House 2");

        var response = await _controller.UpdateRealEstate(1, realEstateParams);
        Assert.IsType<RedirectToActionResult>(response);
        Assert.Equal("Index", (response as RedirectToActionResult).ActionName);
        var updatedRealEstate = await _context.RealEstates.FindAsync(1);
        Assert.Equal("Berlin House 2", updatedRealEstate.Name);
    }

    private RealEstate newRealEstate(int id, string? name)
    {
        return new RealEstate
        {
            Id = id,
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