﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eCatalogWebApplication.Data;
using eCatalogWebApplication.Models;

namespace eCatalogWebApplication.Controllers
{
    public class CatalogsController : Controller
    {
        private readonly eCatalogWebApplicationContext _context;

        public CatalogsController(eCatalogWebApplicationContext context)
        {
            _context = context;
        }

        // GET: Catalogs
        public async Task<IActionResult> Index()
        {
              return _context.Catalog != null ? 
                          View(await _context.Catalog.ToListAsync()) :
                          Problem("Entity set 'eCatalogWebApplicationContext.Catalog'  is null.");
        }

        // GET: Catalogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Catalog == null)
            {
                return NotFound();
            }

            var catalog = await _context.Catalog
                .FirstOrDefaultAsync(m => m.IDCatalog == id);
            if (catalog == null)
            {
                return NotFound();
            }

            return View(catalog);
        }

        // GET: Catalogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Catalogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDCatalog,NameCatalog,SubCatalog")] Catalog catalog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catalog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalog);
        }

        // GET: Catalogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Catalog == null)
            {
                return NotFound();
            }

            var catalog = await _context.Catalog.FindAsync(id);
            if (catalog == null)
            {
                return NotFound();
            }
            return View(catalog);
        }

        // POST: Catalogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDCatalog,NameCatalog,SubCatalog")] Catalog catalog)
        {
            if (id != catalog.IDCatalog)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogExists(catalog.IDCatalog))
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
            return View(catalog);
        }

        // GET: Catalogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Catalog == null)
            {
                return NotFound();
            }

            var catalog = await _context.Catalog
                .FirstOrDefaultAsync(m => m.IDCatalog == id);
            if (catalog == null)
            {
                return NotFound();
            }

            return View(catalog);
        }

        // POST: Catalogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Catalog == null)
            {
                return Problem("Entity set 'eCatalogWebApplicationContext.Catalog'  is null.");
            }
            var catalog = await _context.Catalog.FindAsync(id);
            if (catalog != null)
            {
                _context.Catalog.Remove(catalog);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogExists(int id)
        {
          return (_context.Catalog?.Any(e => e.IDCatalog == id)).GetValueOrDefault();
        }
    }
}
