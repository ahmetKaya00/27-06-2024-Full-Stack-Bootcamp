using Basic.Models;
using Microsoft.AspNetCore.Mvc;

namespace Basic.Controllers{

    public class BootcampController : Controller{
    public IActionResult Details(int? id)
    {
        if(id==null){
            return RedirectToAction("Index","Home");
        }
            var bootcamp = Repository.GetById(id);
            return View(bootcamp);
    }
        public IActionResult List(){

            return View(Repository.Bootcamps);
        }
    }
}