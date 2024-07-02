using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using restate.RealEstateManagement.Models;

namespace restate.RealEstateManagement.Controllers;

[Area("RealEstateManagement")]
[Route("real-estates")]
public class RealEstateController : Controller
{
    private readonly ILogger<RealEstateController> _logger;

    public RealEstateController(ILogger<RealEstateController> logger)
    {
        _logger = logger;
    }

    [Route("")]
    public IActionResult Index()
    {
        List<RealEstate> realEstates = new List<RealEstate>
        {
            new RealEstate(1, "House 1", "Berlin", "Hoffstrasse", "1", "00001", 1000, RealEstateType.RESIDENTIAL),
            new RealEstate(2, "House 2", "Berlin", "Hoffstrasse", "2", "00001", 1000, RealEstateType.RESIDENTIAL),
            new RealEstate(2, "House 3", "Berlin", "Ruschestrass", "1", "00001", 200, RealEstateType.COMMERCIAL),
        };
        return View(realEstates);
    }
}