using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REalEstateManagement.ViewModel;
using restate.db;
using restate.RealEstateManagement.Models;
using restate.RealEstateManagement.Repositories;
using Microsoft.AspNetCore.Http;

namespace restate.RealEstateManagement.Controllers;

[Area("RealEstateManagement")]
[Route("sessions")]
public class SessionController : Controller
{
    private readonly AppDbContext _context;
    public SessionController(AppDbContext context)
    {
        _context = context;
    }

    
    [Route("new")]
    public IActionResult New()
    {
        return View();
    }

    public async Task<IActionResult> Create(Session session)
    {
        User user = await _context.Users.FirstAsync(u => u.Email == session.Email);
        if(user is not null)
        {
            var cookieOptions = new CookieOptions()
            {
                HttpOnly = true
            };
            Response.Cookies.Append("session_id", user.Id.ToString());
            return RedirectToAction("Index", "RealEstate");
        }
        return View("New");
    }
}