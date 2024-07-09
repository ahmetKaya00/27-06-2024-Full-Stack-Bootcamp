using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Basic.Models;

namespace Basic.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
            return View(Repository.Bootcamps);
    }
}
