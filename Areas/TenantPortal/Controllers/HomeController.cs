using Microsoft.AspNetCore.Mvc;

namespace restate.TenantPortal.Controllers;

[Area("TenantPortal")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}