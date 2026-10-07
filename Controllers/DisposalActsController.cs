using GochsSiz.Data;
using GochsSiz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GochsSiz.Controllers
{
    public class DisposalActsController : Controller
    {
        private readonly AppDbContext _context;
        public DisposalActsController(AppDbContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var acts = await _context.DisposalActs.Include(a => a.SizItem).ToListAsync();
            return View(acts);
        }

        public IActionResult Create()
        {
            ViewBag.SizItems = _context.SizItems.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DisposalAct act)
        {
            if (ModelState.IsValid)
            {
                _context.Add(act);
                // Меняем статус СИЗ на «Списано»
                var siz = await _context.SizItems.FindAsync(act.SizItemId);
                if (siz != null) siz.Status = "Списано / Утилизировано";

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.SizItems = _context.SizItems.ToList();
            return View(act);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var act = await _context.DisposalActs
                .Include(a => a.SizItem)
                .FirstOrDefaultAsync(a => a.Id == id);
            if (act == null) return NotFound();
            return View(act);
        }
    }
}