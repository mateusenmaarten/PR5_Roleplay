using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PR5_Roleplay.Models;
using Roleplay.Data;
using Roleplay.ViewModels;

namespace Roleplay.Controllers
{
    public class CharacterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CharacterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Character
        public async Task<IActionResult> Index()
        {
            ListCharacterViewModel viewModel = new ListCharacterViewModel();
            viewModel.Characters = await _context.Characters
                .Include(c => c.Player)
                .Include(c => c.CharacterClass)
                .ToListAsync();
            return View(viewModel);
        }

        // GET: Character/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters
                .Include(c => c.Player)
                .FirstOrDefaultAsync(m => m.CharacterID == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // GET: Character/Create
        [Authorize(Roles = "Admin,GameMaster,Player")]
        public IActionResult Create()
        {
            CreateCharacterViewModel viewModel = new CreateCharacterViewModel();
            viewModel.Character = new Character();
            viewModel.CharacterClasses = new SelectList(_context.CharacterClasses, "CharacterClassID","CharacterClassName");
            viewModel.Players = new SelectList(_context.Players, "PlayerID", "Name");
            return View(viewModel);
        }

        // POST: Character/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,GameMaster,Player")]
        public async Task<IActionResult> Create(CreateCharacterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(viewModel.Character);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {

                    return RedirectToAction(nameof(Index));
                }
            }
            viewModel.CharacterClasses = new SelectList(_context.CharacterClasses, "CharacterClassID", "CharacterClassName");
            viewModel.Players = new SelectList(_context.Players, "PlayerID", "Name");
            return View(viewModel);
        }

        // GET: Character/Edit/5
        [Authorize(Roles = "Admin,GameMaster,Player")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }
            ViewData["PlayerID"] = new SelectList(_context.Players, "PlayerID", "PlayerID", character.PlayerID);
            return View(character);
        }

        // POST: Character/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,GameMaster,Player")]
        public async Task<IActionResult> Edit(int id, [Bind("CharacterID,PlayerID,ClassID,CharacterName,CharacterGender,CharacterDescription,CharacterAge,FavouriteWeapon,HomeTown")] Character character)
        {
            if (id != character.CharacterID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(character);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterExists(character.CharacterID))
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
            ViewData["PlayerID"] = new SelectList(_context.Players, "PlayerID", "PlayerID", character.PlayerID);
            return View(character);
        }

        // GET: Character/Delete/5
        [Authorize(Roles = "Admin,GameMaster,Player")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters
                .Include(c => c.Player)
                .FirstOrDefaultAsync(m => m.CharacterID == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // POST: Character/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,GameMaster,Player")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterExists(int id)
        {
            return _context.Characters.Any(e => e.CharacterID == id);
        }
    }
}
