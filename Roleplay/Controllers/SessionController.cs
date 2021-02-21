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
    public class SessionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<CustomUser> _userManager;

        public SessionController(ApplicationDbContext context, UserManager<CustomUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Session
        public async Task<IActionResult> Index()
        {
            ListSessionViewModel viewModel = new ListSessionViewModel();
            viewModel.Sessions = await _context.Sessions
                .Include(a => a.Adventure)
                .Include(p => p.SessionPlayers)
                .ToListAsync();
            viewModel.Players = new List<Player>(_context.Players);
            return View(viewModel);
        }


        // GET: Session/Create
        [Authorize(Roles = "Admin,GameMaster")]
        public IActionResult Create()
        {
            CreateSessionViewModel viewModel = new CreateSessionViewModel();
            viewModel.Session = new Session();
            viewModel.Adventures = new SelectList(_context.Adventures, "AdventureID", "Title");
            viewModel.SessionPlayers = new SelectList(_context.Players, "PlayerID", "Name");
            viewModel.SelectedSessionPlayers = new List<int>();
            return View(viewModel);
        }

        // POST: Session/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,GameMaster")]
        public async Task<IActionResult> Create(CreateSessionViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (viewModel.SelectedSessionPlayers == null)
                    {
                        viewModel.SelectedSessionPlayers = new List<int>();
                    }

                    List<SessionPlayer> playersInSession = new List<SessionPlayer>();

                    foreach (int playerID in viewModel.SelectedSessionPlayers)
                    {
                        //Wie speelt mee in de session
                        SessionPlayer sessionPlayer = new SessionPlayer();
                        sessionPlayer.PlayerID = playerID;
                        sessionPlayer.SessionID = viewModel.Session.SessionID;

                        

                        playersInSession.Add(sessionPlayer);
                       
                    }
                    viewModel.Session.UserName = _userManager.GetUserName(this.User);
                    _context.Add(viewModel.Session);
                    await _context.SaveChangesAsync();

                    Session session = await _context.Sessions
                        .Include(s => s.SessionPlayers)
                        .SingleOrDefaultAsync(x => x.SessionID == viewModel.Session.SessionID);
                    session.SessionPlayers.AddRange(playersInSession);

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

        // GET: Session/Edit/5
        [Authorize(Roles = "Admin,GameMaster")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Session session = await _context.Sessions
                .Include(s => s.SessionPlayers)
                .SingleOrDefaultAsync(x => x.SessionID == id);


            if (session == null)
            {
                return NotFound();
            }

            EditSessionViewModel viewModel = new EditSessionViewModel
            {
                Session = session,
                Adventures = new SelectList(_context.Adventures, "AdventureID", "Title"),
                SessionPlayers = new SelectList(_context.Players, "PlayerID", "Name"),
                Characters = new SelectList(_context.Characters, "CharacterID", "CharacterName"),
                SelectedSessionPlayers = session.SessionPlayers.Select(sp => sp.PlayerID),
                SelectedPlayers = session.SessionPlayers.Select(p => p.Player)
            };
            
            return View(viewModel);
        }

        // POST: Session/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,GameMaster")]
        public async Task<IActionResult> Edit(int id, EditSessionViewModel viewModel)
        {
            if (id != viewModel.Session.SessionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Session session = await _context.Sessions
                .Include(s => s.SessionPlayers)
                .SingleOrDefaultAsync(x => x.SessionID == id);

                session.AdventureID = viewModel.Session.AdventureID;
                session.Date = viewModel.Session.Date;
                session.Duration = viewModel.Session.Duration;
                session.IsPlayed = viewModel.Session.IsPlayed;
                session.Recap = viewModel.Session.Recap;
                session.SessionGamemaster = viewModel.Session.SessionGamemaster;

                if (viewModel.SelectedSessionPlayers == null)
                {
                    viewModel.SelectedSessionPlayers = new List<int>();
                }

                List<SessionPlayer> playersInSession = new List<SessionPlayer>();

                foreach (int playerID in viewModel.SelectedSessionPlayers)
                {
                    //Wie speelt mee in de session
                    SessionPlayer sessionPlayer = new SessionPlayer();
                    sessionPlayer.PlayerID = playerID;
                    //sessionPlayer.CharacterID = characterID;
                    sessionPlayer.SessionID = viewModel.Session.SessionID;

                    playersInSession.Add(sessionPlayer);
                }



                session.SessionPlayers
                    .RemoveAll(sp => !playersInSession.Contains(sp));
                session.SessionPlayers
                    .AddRange(
                    playersInSession.Where(p => !session.SessionPlayers.Contains(p)));

                _context.Update(session);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
           
            return View(viewModel);
        }

        // GET: Session/Delete/5
        [Authorize(Roles = "Admin,GameMaster")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EditSessionViewModel viewModel = new EditSessionViewModel();
            viewModel.Session = await _context.Sessions
                .Include(s => s.Adventure)
                .FirstOrDefaultAsync(m => m.SessionID == id);
            if (viewModel.Session == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // POST: Session/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,GameMaster")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var session = await _context.Sessions.FindAsync(id);
            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SessionExists(int id)
        {
            return _context.Sessions.Any(e => e.SessionID == id);
        }
    }
}
