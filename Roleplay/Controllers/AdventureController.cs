using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using PR5_Roleplay.Models;
using Roleplay.Data;
using Roleplay.ViewModels;

namespace Roleplay.Controllers
{
   
    public class AdventureController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdventureController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Adventure
        public async Task<IActionResult> Index()
        {
            ListAdventureViewModel viewModel = new ListAdventureViewModel();
            viewModel.Adventures = await _context.Adventures.ToListAsync();
            return View(viewModel);
        }

        // GET: Adventure/Create
        [Authorize(Roles = "Admin,GameMaster")]
        public IActionResult Create()
        {
            CreateAdventureViewModel viewModel = new CreateAdventureViewModel();
            viewModel.Adventure = new Adventure();
            return View(viewModel);
        }

        // POST: Adventure/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,GameMaster")]
        public async Task<IActionResult> Create(CreateAdventureViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(viewModel.Adventure);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    return Redirect("~/Views/Shared/Error.cshtml");
                }
               
            }
            return View(viewModel);
        }

        // GET: Adventure/Edit/5
        [Authorize(Roles = "Admin,GameMaster")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EditAdventureViewModel viewModel = new EditAdventureViewModel();
            viewModel.Adventure = await _context.Adventures.FindAsync(id);
          
            if (viewModel.Adventure == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        // POST: Adventure/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,GameMaster")]
        public async Task<IActionResult> Edit(int id, EditAdventureViewModel viewModel)
        {
            if (id != viewModel.Adventure.AdventureID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viewModel.Adventure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdventureExists(viewModel.Adventure.AdventureID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        return Redirect("~/Views/Shared/Error.cshtml");
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Adventure/Delete/5
        [Authorize(Roles = "Admin,GameMaster")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EditAdventureViewModel viewModel = new EditAdventureViewModel();
            viewModel.Adventure = await _context.Adventures
                .FirstOrDefaultAsync(m => m.AdventureID == id);
            if (viewModel.Adventure == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // POST: Adventure/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,GameMaster")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adventure = await _context.Adventures.FindAsync(id);
            _context.Adventures.Remove(adventure);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdventureExists(int id)
        {
            return _context.Adventures.Any(e => e.AdventureID == id);
        }
    }
}
