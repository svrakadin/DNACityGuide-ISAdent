﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DNACityGuide.Data;
using DNACityGuide.Models;
using Microsoft.AspNetCore.Authorization;

namespace DNACityGuide.Controllers
{
    [Authorize]
    public class MapaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MapaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mapa
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mapa.ToListAsync());
        }

        // GET: Mapa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mapa = await _context.Mapa
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mapa == null)
            {
                return NotFound();
            }

            return View(mapa);
        }

        // GET: Mapa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mapa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID")] Mapa mapa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mapa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mapa);
        }

        // GET: Mapa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mapa = await _context.Mapa.FindAsync(id);
            if (mapa == null)
            {
                return NotFound();
            }
            return View(mapa);
        }

        // POST: Mapa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID")] Mapa mapa)
        {
            if (id != mapa.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mapa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MapaExists(mapa.ID))
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
            return View(mapa);
        }

        // GET: Mapa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mapa = await _context.Mapa
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mapa == null)
            {
                return NotFound();
            }

            return View(mapa);
        }

        // POST: Mapa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mapa = await _context.Mapa.FindAsync(id);
            _context.Mapa.Remove(mapa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MapaExists(int id)
        {
            return _context.Mapa.Any(e => e.ID == id);
        }
    }
}
