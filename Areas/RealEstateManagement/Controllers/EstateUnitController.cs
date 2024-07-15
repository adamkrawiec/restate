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

    public async Task<IActionResult> Index(int realEstateId)
    {
        RealEstate realEstate = await _context.RealEstates.FindAsync(realEstateId);
        List<EstateUnit> estateUnits = await _context.EstateUnits.Where(es => es.RealEstate == realEstate).ToListAsync();
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
    public IActionResult New()
    {
        return View();
    }
}