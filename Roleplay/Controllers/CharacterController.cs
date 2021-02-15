using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PR5_Roleplay.Models;
using Roleplay.Areas.Identity.Data;
using Roleplay.Data;
using Roleplay.ViewModels;

namespace Roleplay.Controllers
{
    public class CharacterController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<CustomUser> _userManager;

        public CharacterController(ApplicationDbContext context, UserManager<CustomUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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

        //GET: Character search
        public async Task<IActionResult> Search(ListCharacterViewModel viewModel)
        {
           
            if (!string.IsNullOrEmpty(viewModel.CharacterSearch))
            {
                viewModel.Characters = await _context.Characters
                .Include(c => c.Player)
                .Include(c => c.CharacterClass)
                .Where(c => c.CharacterName.Contains(viewModel.CharacterSearch))
                .ToListAsync();
            }
            else
            {
                viewModel.Characters = await _context.Characters
                .Include(c => c.Player)
                .Include(c => c.CharacterClass).ToListAsync();
            }
            return View("Index",viewModel);
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
                    viewModel.Character.UserID = _userManager.GetUserId(this.User);
                    _context.Add(viewModel.Character);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception )
                {
                    return Redirect("~/Views/Shared/Error.cshtml");
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
            
            Character character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }
            CreateCharacterViewModel viewModel = new CreateCharacterViewModel
            {
                Character = character,
                Players = new SelectList(_context.Players, "PlayerID", "Name"),
                CharacterClasses = new SelectList(_context.CharacterClasses, "CharacterClassID", "CharacterClassName")
            };

            return View(viewModel);
        }

        // POST: Character/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,GameMaster,Player")]
        public async Task<IActionResult> Edit(int id, CreateCharacterViewModel viewModel)
        {
            if (id != viewModel.Character.CharacterID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viewModel.Character);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterExists(viewModel.Character.CharacterID))
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

        // GET: Character/Delete/5
        [Authorize(Roles = "Admin,GameMaster,Player")]
        public async Task<IActionResult> Delete(int? id)
        {
            CreateCharacterViewModel viewModel = new CreateCharacterViewModel();
            viewModel.Character = await _context.Characters
                 .Include(c => c.Player)
                 .Include(c => c.CharacterClass)
                .FirstOrDefaultAsync(m => m.CharacterID == id);
            if (id == null)
            {
                return NotFound();
            }

            
            if (viewModel.Character == null)
            {
                return NotFound();
            }

            return View(viewModel);
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
