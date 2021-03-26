using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntranceMonitoring.Data;
using EntranceMonitoring.Models;

namespace EntranceMonitoring.Controllers
{
    public class RegistriesController : Controller
    {
        private readonly MonitoringContext _context;

        public RegistriesController(MonitoringContext context)
        {
            _context = context;
        }

        // GET: Registries
        public async Task<IActionResult> Index()
        {
            var monitoringContext = _context.Registries.Include(r => r.Building).Include(r => r.User);
            return View(await monitoringContext.ToListAsync());
        }

        // GET: Registries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registry = await _context.Registries
                .Include(r => r.Building)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registry == null)
            {
                return NotFound();
            }

            return View(registry);
        }

        // GET: Registries/Create
        public IActionResult Create()
        {
            ViewData["BuildingId"] = new SelectList(_context.Buildings, "BuildingId", "BuildingId");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: Registries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Registedtime,InOut,UserId,BuildingId")] Registry registry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuildingId"] = new SelectList(_context.Buildings, "BuildingId", "BuildingId", registry.BuildingId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", registry.UserId);
            return View(registry);
        }

        // GET: Registries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registry = await _context.Registries.FindAsync(id);
            if (registry == null)
            {
                return NotFound();
            }
            ViewData["BuildingId"] = new SelectList(_context.Buildings, "BuildingId", "BuildingId", registry.BuildingId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", registry.UserId);
            return View(registry);
        }

        // POST: Registries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Registedtime,InOut,UserId,BuildingId")] Registry registry)
        {
            if (id != registry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistryExists(registry.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuildingId"] = new SelectList(_context.Buildings, "BuildingId", "BuildingId", registry.BuildingId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", registry.UserId);
            return View(registry);
        }

        // GET: Registries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registry = await _context.Registries
                .Include(r => r.Building)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registry == null)
            {
                return NotFound();
            }

            return View(registry);
        }

        // POST: Registries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registry = await _context.Registries.FindAsync(id);
            _context.Registries.Remove(registry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistryExists(int id)
        {
            return _context.Registries.Any(e => e.Id == id);
        }
    }
}
