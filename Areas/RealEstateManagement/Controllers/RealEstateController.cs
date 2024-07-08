using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restate.db;
using restate.RealEstateManagement.Models;

namespace restate.RealEstateManagement.Controllers;

[Area("RealEstateManagement")]
[Route("real-estates")]
public class RealEstateController : Controller
{
    private readonly AppDbContext _context;

    public RealEstateController(AppDbContext context)
    {
        _context = context;
    }

    [Route("")]
    public async Task<IActionResult> Index()
    {
        List<RealEstate> realEstates = await _context.RealEstates.ToListAsync();
        return View(realEstates);
    }

    [HttpGet("/new")]
    public IActionResult New()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> CreateRealEstate(RealEstate realEstate)
    {
        if (ModelState.IsValid)
        {
            _context.RealEstates.Add(realEstate);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        return View(realEstate);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ShowDetails(int id)
    {
        RealEstate realEstate = await _context.RealEstates.FindAsync(id);
        if (realEstate == null)
        {
            return NotFound();
        }
        return View(realEstate);
    }

    [HttpGet("{id}/edit")]
    public IActionResult Edit(int id)
    {
        RealEstate realEstate = _context.RealEstates.Find(id);
        if (realEstate == null)
        {
            return NotFound();
        }
        return View(realEstate);
    }

    [HttpPut("/{id}")]
    public async Task<IActionResult> UpdateRealEstate(int id, RealEstate realEstate)
    {
        if (id != realEstate.Id)
        {
            return BadRequest();
        }
        _context.Entry(realEstate).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

}