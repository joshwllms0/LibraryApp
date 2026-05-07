using LibraryApp.Data;
using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers
{
    public class MembersController : Controller
    {
        private readonly AppDbContext _context;
        public MembersController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _context.Members.ToListAsync();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Member member)
        {
            if (ModelState.IsValid)
            {
                _context.Members.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = await _context.Members.FindAsync(id.Value);

            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _context.Members.FindAsync(id.Value);

            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Member member)
        {
            if (id != member.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Members.Update(member);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound(); 
            }
            var result = await _context.Members.FindAsync(id.Value);
            
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmation(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

                var result = await _context.Members.FindAsync(id.Value);

                if (result == null)
                {
                    return NotFound();
                }

                _context.Members.Remove(result);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

        }
    }
}
