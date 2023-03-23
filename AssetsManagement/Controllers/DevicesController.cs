using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssetManagment.Data;
using AssetManagment.Models;

namespace AssetsManagement.Controllers
{
    public class DevicesController : Controller
    {
        private readonly AssetsContext _context;

        public DevicesController(AssetsContext context)
        {
            _context = context;
        }

        // GET: Devices
        public async Task<IActionResult> Index()
        {
            var assetsContext = _context.Devices.Include(d => d.DeviceCategory).Include(d => d.DeviceLocation);
            return View(await assetsContext.ToListAsync());
        }

        // GET: Devices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Devices == null)
            {
                return NotFound();
            }

            var devices = await _context.Devices
                .Include(d => d.DeviceCategory)
                .Include(d => d.DeviceLocation)
                .FirstOrDefaultAsync(m => m.DeviceId == id);
            if (devices == null)
            {
                return NotFound();
            }

            return View(devices);
        }

        // GET: Devices/Create
        public IActionResult Create()
        {
            ViewData["DeviceCategoryId"] = new SelectList(_context.DeviceCategories, "DeviceCategoryId", "DeviceCategoryName");
            ViewData["DeviceLocationId"] = new SelectList(_context.DeviceLocations, "DeviceLocationId", "DeviceLocationName");
            return View();
        }

        // POST: Devices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeviceId,DeviceCategoryId,DeviceLocationId,Description,SerialNumber")] Devices devices)
        {
            if (ModelState.IsValid)
            {
                _context.Add(devices);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeviceCategoryId"] = new SelectList(_context.DeviceCategories, "DeviceCategoryId", "DeviceCategoryName", devices.DeviceCategoryId);
            ViewData["DeviceLocationId"] = new SelectList(_context.DeviceLocations, "DeviceLocationId", "DeviceLocationName", devices.DeviceLocationId);
            return View(devices);
        }

        // GET: Devices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Devices == null)
            {
                return NotFound();
            }

            var devices = await _context.Devices.FindAsync(id);
            if (devices == null)
            {
                return NotFound();
            }
            ViewData["DeviceCategoryId"] = new SelectList(_context.DeviceCategories, "DeviceCategoryId", "DeviceCategoryName", devices.DeviceCategoryId);
            ViewData["DeviceLocationId"] = new SelectList(_context.DeviceLocations, "DeviceLocationId", "DeviceLocationName", devices.DeviceLocationId);
            return View(devices);
        }

        // POST: Devices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeviceId,DeviceCategoryId,DeviceLocationId,Description,SerialNumber")] Devices devices)
        {
            if (id != devices.DeviceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(devices);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DevicesExists(devices.DeviceId))
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
            ViewData["DeviceCategoryId"] = new SelectList(_context.DeviceCategories, "DeviceCategoryId", "DeviceCategoryName", devices.DeviceCategoryId);
            ViewData["DeviceLocationId"] = new SelectList(_context.DeviceLocations, "DeviceLocationId", "DeviceLocationName", devices.DeviceLocationId);
            return View(devices);
        }

        // GET: Devices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Devices == null)
            {
                return NotFound();
            }

            var devices = await _context.Devices
                .Include(d => d.DeviceCategory)
                .Include(d => d.DeviceLocation)
                .FirstOrDefaultAsync(m => m.DeviceId == id);
            if (devices == null)
            {
                return NotFound();
            }

            return View(devices);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Devices == null)
            {
                return Problem("Entity set 'AssetsContext.Devices'  is null.");
            }
            var devices = await _context.Devices.FindAsync(id);
            if (devices != null)
            {
                _context.Devices.Remove(devices);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DevicesExists(int id)
        {
          return (_context.Devices?.Any(e => e.DeviceId == id)).GetValueOrDefault();
        }
    }
}
