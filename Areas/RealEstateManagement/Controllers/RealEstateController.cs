using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restate.db;
using restate.RealEstateManagement.Models;
using restate.RealEstateManagement.Repositories;

namespace restate.RealEstateManagement.Controllers;

[Area("RealEstateManagement")]
[Route("real-estates")]
public class RealEstateController : Controller
{
    private readonly RealEstateRepository _repository;

    public RealEstateController(AppDbContext context)
    {
        _repository = new RealEstateRepository(context);

    }

    [Route("")]
    public async Task<IActionResult> Index()
    {
        List<RealEstate> realEstates = await _repository.FindAll();
        return View(realEstates);
    }

    [HttpGet("new")]
    public IActionResult New()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Create([Bind("Id,Name,City,Street,HouseNumber,PostalCode,Area,Type")] RealEstate realEstate)
    {
        if (ModelState.IsValid)
        {
            await _repository.Create(realEstate);
            return RedirectToAction("Index");
        }

        return View("New", realEstate);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ShowDetails(int id)
    {
        RealEstate? realEstate = await _repository.FindById(id);
        if (realEstate == null)
        {
            return NotFound();
        }
        return View(realEstate);
    }

    [HttpGet("{id}/edit")]
    public async Task<IActionResult> Edit(int id)
    {
        RealEstate? realEstate = await _repository.FindById(id);
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
        await _repository.Update(realEstate);
        return RedirectToAction("Index");
    }

}