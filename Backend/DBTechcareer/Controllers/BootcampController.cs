using DBTechcareer.Data;
using DBTechcareer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DBTechcareer.Controllers
{

    public class BootcampController : Controller
    {

        private readonly DataContext _context;
        public BootcampController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var Bootcampler = await _context.Bootcamps.Include(e => e.Egitmen).ToListAsync();
            return View(Bootcampler);
        }
        public async Task<IActionResult> Create()
        {

            ViewBag.Egitmenler = new SelectList(await _context.Egitmenler.ToListAsync(), "EgitmenId", "AdSoyad");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Bootcamp model)
        {
            _context.Bootcamps.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // var ogr = await _context.Bootcampler.FindAsync(id);
            var bootcamp = await _context.Bootcamps.Include(b => b.KursKayit).ThenInclude(b => b.Ogrenci).Select(b=>new BootcampViewModel{BootcampId = b.BootcampId,Baslik = b.Baslik,EgitmenId=b.EgitmenId,KursKayit = b.KursKayit}).FirstOrDefaultAsync(o => o.BootcampId == id);

            if (bootcamp == null)
            {
                return NotFound();
            }
            ViewBag.Egitmenler = new SelectList(await _context.Egitmenler.ToListAsync(), "EgitmenId", "AdSoyad");


            return View(bootcamp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BootcampViewModel model)
        {
            if (id != model.BootcampId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(new Bootcamp() {BootcampId = model.BootcampId, Baslik = model.Baslik,EgitmenId = model.EgitmenId});
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Bootcamps.Any(o => o.BootcampId == model.BootcampId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Bootcamp = await _context.Bootcamps.FindAsync(id);
            if (Bootcamp == null)
            {
                return NotFound();
            }

            return View(Bootcamp);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var Bootcamp = await _context.Bootcamps.FindAsync(id);

            if (Bootcamp == null)
            {
                return NotFound();
            }

            _context.Bootcamps.Remove(Bootcamp);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }
    }
}