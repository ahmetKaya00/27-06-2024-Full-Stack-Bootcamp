using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Techcareer.Models;

namespace Techcareer.Controllers;

public class HomeController : Controller
{
    public HomeController()
    {
        
    }

    public IActionResult Index(string searchString, string category)
    {
        var products = Repository.Products;

        if(!String.IsNullOrEmpty(searchString)){

            ViewBag.SearchString = searchString;
            products = products.Where(p=>p.Name!.ToLower().Contains(searchString)).ToList();
        }
        if(!String.IsNullOrEmpty(category)&&category != "0"){
            products = products.Where(p=>p.CategoryId == int.Parse(category)).ToList();
        }

     //   ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId","Name",category);
        var model = new ProductViewModel{
            Products = products,
            Categories = Repository.Categories,
            SelectedCategory = category
        };

        return View(model);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId","Name");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product model, IFormFile imageFile)
    {
        const int maxFileSize = 2*1024;
        var allowenExtensions = new[] {".jpg",".png",".jpeg"};
        if(imageFile != null){

            if(imageFile.Length > maxFileSize){
                ModelState.AddModelError("","Dosya boyutu 2 MB den küçük olmalıdır.");
            }
            
            var extensions = Path.GetExtension(imageFile.FileName).ToLowerInvariant();

            if(!allowenExtensions.Contains(extensions)){
                ModelState.AddModelError("","Geçerli bir resim seçiniz!");
            }else{
                var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extensions}");
                var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/img",randomFileName);

                try
                {
                    using(var stream = new FileStream(path,FileMode.Create)){
                        await imageFile.CopyToAsync(stream);
                    }
                    model.Image = randomFileName;
                }
                catch
                {
                    ModelState.AddModelError("","Dosya yüklenirken bir hata oluştu.");
                }
            }
        }else{
            ModelState.AddModelError("", "Bir dosya seçiniz.");
        }

        if(ModelState.IsValid){
        
        model.ProductId = Repository.Products.Count+1;
        Repository.CreateProduct(model);
        return RedirectToAction("Index");
        }

        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId","Name");
        return View(model);
    }

    public IActionResult Profile(int? id){
        if(id == null){
            return RedirectToAction("Index","Home");
        }
        var bootcamp = Repository.GetById(id);
        return View(bootcamp);
    }

    public IActionResult Edit(int? id){
        if(id == null){
            return NotFound();
        }
        var entity = Repository.Products.FirstOrDefault(p=>p.ProductId == id);
        if(entity == null){
            return NotFound();
        }
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId","Name");
        return View(entity);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(int id,Product model, IFormFile? imageFile)
    {
        if(id != model.ProductId){
            return NotFound();
        }
        
        var allowenExtensions = new[] {".jpg",".png",".jpeg"};
        if(imageFile != null){
            
            var extensions = Path.GetExtension(imageFile.FileName).ToLowerInvariant();

            if(!allowenExtensions.Contains(extensions)){
                ModelState.AddModelError("","Geçerli bir resim seçiniz!");
            }else{
                var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extensions}");
                var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/img",randomFileName);

                try
                {
                    using(var stream = new FileStream(path,FileMode.Create)){
                        await imageFile.CopyToAsync(stream);
                    }
                    model.Image = randomFileName;
                }
                catch
                {
                    ModelState.AddModelError("","Dosya yüklenirken bir hata oluştu.");
                }
            }
        }else{
            ModelState.AddModelError("", "Bir dosya seçiniz.");
        }

        if(ModelState.IsValid){

        Repository.EditProduct(model);
        return RedirectToAction("Index");
        }

        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId","Name");
        return View(model);
    }

    public IActionResult Delete(int? id){
        if(id == null){
            return NotFound();
        }
        var entity = Repository.Products.FirstOrDefault(p=>p.ProductId == id);
        if(entity==null){
            return NotFound();
        }
        
        return View("DeleteConfirm",entity);
    }

    [HttpPost]
    public IActionResult Delete(int id, int ProductId){
        if(id != ProductId){
            return NotFound();
        }
        var entity = Repository.Products.FirstOrDefault(p=>p.ProductId == ProductId);
        if(entity==null){
            return NotFound();
        }
        
        Repository.DeleteProduct(entity);
        return RedirectToAction("Index");
    }
}
