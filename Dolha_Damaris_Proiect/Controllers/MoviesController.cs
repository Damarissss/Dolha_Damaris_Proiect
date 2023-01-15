using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dolha_Damaris_Proiect.Data;
using Dolha_Damaris_Proiect.Models;
using Dolha_Damaris_Proiect.Models.LibraryViewModels;
using static System.Reflection.Metadata.BlobBuilder;
using System.Net;
using System.Security.Policy;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Dolha_Damaris_Proiect.Controllers
{
    [Authorize(Roles = "Employee, Manager")]

    public class MoviesController : Controller
    {
        private readonly LibraryContext _context;

        public MoviesController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Movies
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.Movies
                .Include(i => i.Cinema)
                .Include(i => i.Producer);
                
            return View(await libraryContext.ToListAsync());
        }

        // GET: Movies/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(i => i.Cinema)
                .Include(i => i.Producer)
                .Include(i => i.Actors_Movies)
                .ThenInclude(i => i.Actor)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            ViewBag.CinemaId = new SelectList(_context.Cinemas, "Id", "Name");
            ViewBag.ProducerId = new SelectList(_context.Producers, "Id", "FullName");

            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        // Atributul "ValidateAntiForgeryToken" ajută la prevenirea de atacuri cu cereri false cross-site.
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Price,StartDate,EndDate,MovieGenre,ImageTitle,CinemaId,ProducerId")] Movie movie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Movies.Add(movie);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex*/)
            {

                ModelState.AddModelError("", "Unable to save changes. " + "Try again");
            }

            ViewBag.CinemaId = new SelectList(_context.Cinemas, "Id", "Name", movie.CinemaId);
            ViewBag.ProducerId = new SelectList(_context.Producers, "Id", "FullName", movie.ProducerId);

            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(i => i.Cinema)
                .Include(i => i.Producer)
                .Include(i => i.Actors_Movies)
                .ThenInclude(i => i.Actor)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            ViewBag.CinemaId = new SelectList(_context.Cinemas, "Id", "Name", movie.CinemaId);
            ViewBag.ProducerId = new SelectList(_context.Producers, "Id", "FullName", movie.ProducerId);

            PopulateActor_Movie_Data(movie);
            return View(movie);
        }

        private void PopulateActor_Movie_Data(Movie movie)
        {
            var allActors = _context.Actors;
            var viewModel = new List<Actor_Movie_Data>();
            foreach (var actor in allActors)
            {
                viewModel.Add(new Actor_Movie_Data
                {
                    ActorId = actor.Id,
                    FullName = actor.FullName
                });
            }
            ViewData["Actors"] = viewModel;
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, string[] selectedActors)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieToUpdate = await _context.Movies
                .Include(i => i.Cinema)
                .Include(i => i.Producer)
                .Include(i => i.Actors_Movies)
                .ThenInclude(i => i.Actor)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (await TryUpdateModelAsync<Movie>(movieToUpdate, "", 
                s => s.Name,
                s => s.Description, 
                s => s.Price,
                s => s.StartDate,
                s => s.EndDate,
                s => s.MovieGenre,
                s => s.ImageTitle,
                s => s.CinemaId,
                s => s.ProducerId,
                s => s.Actors_Movies))
            {
                UpdateActor_Movie(selectedActors, movieToUpdate);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "Unable to save changes. " + "Try again");
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CinemaId = new SelectList(_context.Cinemas, "Id", "Name");
            ViewBag.ProducerId = new SelectList(_context.Producers, "Id", "FullName");

            UpdateActor_Movie(selectedActors, movieToUpdate);
            PopulateActor_Movie_Data(movieToUpdate);
            return View(movieToUpdate);
        }

        private void UpdateActor_Movie(string[] selectedActors, Movie movieToUpdate)
        {
            if (selectedActors == null)
            {
                movieToUpdate.Actors_Movies = new List<Actor_Movie>();
                return;
            }
            var selectedActorsHS = new HashSet<string>(selectedActors);
            var movie_their_Actors = new HashSet<int>(movieToUpdate.Actors_Movies.Select(c => c.Actor.Id));
            foreach (var actor in _context.Actors)
            {
                if (selectedActorsHS.Contains(actor.Id.ToString()))
                {
                    if (!movie_their_Actors.Contains(actor.Id))
                    {
                        movieToUpdate.Actors_Movies.Add(new Actor_Movie
                        {
                            MovieId = movieToUpdate.Id,
                            ActorId = actor.Id
                        });
                    }
                }
                else
                {
                    if (movie_their_Actors.Contains(actor.Id))
                    {
                        Actor_Movie actorToRemove = movieToUpdate.Actors_Movies.FirstOrDefault(i => i.ActorId == actor.Id);
                        _context.Remove(actorToRemove);
                    }
                }
            }
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .AsNoTracking()
                .Include(m => m.Cinema)
                .Include(m => m.Producer)
                .Include(m => m.Actors_Movies)
                .ThenInclude(m => m.Actor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Delete failed. Try again";
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Movies == null)
            {
                return Problem("Entity set 'LibraryContext.Movies' is null.");
            }
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }
        private bool MovieExists(int id)
        {
          return _context.Movies.Any(e => e.Id == id);
        }

        // Statistics
        // Metoda utilizează o interogare LINQ care grupează entitățile movies după data comenzii, calculând numărul de filme comandate
        // pentru fiecare dată calendaristică și salvează rezultatul într-o colecție "OrderGroup".
        public async Task<ActionResult> Statistics()
        {
            IQueryable<OrderGroup> data =
                from order in _context.Orders
                group order by order.OrderDate into dateGroup
                select new OrderGroup()
                {
                    OrderDate = dateGroup.Key,
                    MovieCount = dateGroup.Count()
                };
            return View(await data.AsNoTracking().ToListAsync());
        }

        // Chat
        public IActionResult Chat()
        {
            return View();
        }
    }
}
