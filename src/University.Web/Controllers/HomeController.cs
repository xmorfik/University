using Microsoft.AspNetCore.Mvc;

namespace University.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return RedirectToAction("Index", "Courses");
    }

    public IActionResult Privacy()
    {
        return View();
    }
}