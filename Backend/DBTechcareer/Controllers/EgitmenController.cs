using DBTechcareer.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBTechcareer.Controllers{

    public class EgitmenController : Controller{

        private readonly DataContext _context;
        public EgitmenController(DataContext context){
            _context = context;
        }

        public async Task<IActionResult> Index(){
            var Egitmenler = await _context.Egitmenler.ToListAsync();
            return View(Egitmenler);
        }
        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Create(Egitmen model){
            _context.Egitmenler.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id){
            if(id == null){
                return NotFound();
            }
           // var ogr = await _context.Egitmenler.FindAsync(id);
            var egt = await _context.Egitmenler.Include(b=>b.Bootcamp).FirstOrDefaultAsync(o => o.EgitmenId == id);

            if(egt == null){
                return NotFound();
            }
            return View(egt);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id, Egitmen model){
            if(id != model.EgitmenId){
                return NotFound();
            }
            if(ModelState.IsValid){
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!_context.Egitmenler.Any(o=>o.EgitmenId == model.EgitmenId)){
                        return NotFound();
                    }else{
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]

        public async Task<IActionResult>Delete(int? id){
            if(id == null){
                return NotFound();
            }

            var Egitmen = await _context.Egitmenler.FindAsync(id);
            if(Egitmen == null){
                return NotFound();
            }

            return View(Egitmen);
        }

        [HttpPost]
        public async Task<IActionResult>Delete([FromForm]int id){
            var Egitmen = await _context.Egitmenler.FindAsync(id);
            
            if(Egitmen == null){
                return NotFound();
            }

            _context.Egitmenler.Remove(Egitmen);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }
    }
}