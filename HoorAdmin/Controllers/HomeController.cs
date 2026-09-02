using HoorAdmin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HoorAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly Jobzy _context;

        public HomeController(Jobzy context)
        {
            _context = context;
        }
        // GET: HomeController
        public async Task<IActionResult> Index()
        {
            var users = await _context.AspNetUsers.ToListAsync();
            return View(users);
        }


        public async Task<IActionResult> Details(string id)
        {
            if (id == null) return NotFound();

            var user = await _context.AspNetUsers.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) return NotFound();

            return View(user);
        }

        // GET: HomeController/Create
        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Email,PhoneNumber,UserName")] AspNetUser user)
        {
            if (ModelState.IsValid)
            {
                user.Id = Guid.NewGuid().ToString();
                user.CreatedOn = DateTime.Now;
                user.IsDeleted = false;

                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }


        // GET: HomeController/Edit/5
        // GET: Edit
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null) return NotFound();

            var user = await _context.AspNetUsers.FindAsync(id);
            if (user == null) return NotFound();

            return View(user);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,FirstName,LastName,Email,PhoneNumber,UserName")] AspNetUser user)
        {
            if (id != user.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.AspNetUsers.Any(e => e.Id == id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }


        // GET: HomeController/Delete/5
        // GET: Delete
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return NotFound();

            var user = await _context.AspNetUsers.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) return NotFound();

            return View(user);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _context.AspNetUsers.FindAsync(id);
            if (user != null)
            {
                _context.AspNetUsers.Remove(user);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
