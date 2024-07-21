using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restate.db;
using restate.RealEstateManagement.Models;

namespace restate.RealEstateManagement.Controllers;

[Area("RealEstateManagement")]
[Route("real-estates/{realEstateId}/estate-units")]
public class EstateUnitController : Controller
{
    private readonly AppDbContext _context;

    public EstateUnitController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(int realEstateId, string? searchString)
    {
        RealEstate realEstate = await _context.RealEstates.FindAsync(realEstateId);
        var estateUnitQuery = _context.EstateUnits.Where(es => es.RealEstate == realEstate);
        if(!String.IsNullOrEmpty(searchString))
        {
            estateUnitQuery = estateUnitQuery.Where(eu => eu.Name.ToLower().Contains(searchString.ToLower()));
        }
        List<EstateUnit> estateUnits = await estateUnitQuery.ToListAsync();
        return View(estateUnits);
    }

    [Route("{id}")]
    public async Task<IActionResult> Show(int realEstateId, int id)
    {
        RealEstate realEstate = await _context.RealEstates.FindAsync(realEstateId);
        EstateUnit estateUnit = await _context.EstateUnits.FindAsync(id);
        ViewBag.RealEstate = realEstate;
        ViewBag.EstateUnit = estateUnit;
        return View();
    }

    [HttpGet("new")]
    public async Task<IActionResult> New(int realEstateId)
    {
        RealEstate realEstate = await _context.RealEstates.FindAsync(realEstateId);
        ViewBag.RealEstate = realEstate;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("Id,Name,UnitNumber,Area,Type")] EstateUnit estateUnit, int realEstateId)
    {
        RealEstate realEstate = await _context.RealEstates.FindAsync(realEstateId);
        estateUnit.RealEstate = realEstate;
        ModelState.Clear();
        
        if(ModelState.IsValid)
        {
            _context.EstateUnits.Add(estateUnit);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { realEstateId = realEstateId });
        }

        ViewBag.RealEstate = realEstate;
        return View("New", estateUnit);
    }
}