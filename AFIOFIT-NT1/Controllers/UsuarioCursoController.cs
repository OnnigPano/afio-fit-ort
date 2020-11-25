using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AFIOFIT_NT1.Models;

namespace AFIOFIT_NT1.Controllers
{
    public class UsuarioCursoController : Controller
    {
        private readonly AfioDbContext _context;

        public UsuarioCursoController(AfioDbContext context)
        {
            _context = context;
        }

        // GET: UsuarioCurso
        public async Task<IActionResult> Index()
        {
            var afioDbContext = _context.UsuarioCurso.Include(u => u.ApplicationUser).Include(u => u.Curso);
            return View(await afioDbContext.ToListAsync());
        }

        // GET: UsuarioCurso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioCurso = await _context.UsuarioCurso
                .Include(u => u.ApplicationUser)
                .Include(u => u.Curso)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioCurso == null)
            {
                return NotFound();
            }

            return View(usuarioCurso);
        }

        // GET: UsuarioCurso/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id");
            ViewData["CursoId"] = new SelectList(_context.Cursos, "CursoId", "Nombre");
            return View();
        }

        // POST: UsuarioCurso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuarioId,CursoId")] UsuarioCurso usuarioCurso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarioCurso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", usuarioCurso.UsuarioId);
            ViewData["CursoId"] = new SelectList(_context.Cursos, "CursoId", "Nombre", usuarioCurso.CursoId);
            return View(usuarioCurso);
        }

        // GET: UsuarioCurso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioCurso = await _context.UsuarioCurso.FindAsync(id);
            if (usuarioCurso == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", usuarioCurso.UsuarioId);
            ViewData["CursoId"] = new SelectList(_context.Cursos, "CursoId", "Nombre", usuarioCurso.CursoId);
            return View(usuarioCurso);
        }

        // POST: UsuarioCurso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,CursoId")] UsuarioCurso usuarioCurso)
        {
            if (id != usuarioCurso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioCurso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioCursoExists(usuarioCurso.Id))
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
            ViewData["UsuarioId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", usuarioCurso.UsuarioId);
            ViewData["CursoId"] = new SelectList(_context.Cursos, "CursoId", "Nombre", usuarioCurso.CursoId);
            return View(usuarioCurso);
        }

        // GET: UsuarioCurso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioCurso = await _context.UsuarioCurso
                .Include(u => u.ApplicationUser)
                .Include(u => u.Curso)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioCurso == null)
            {
                return NotFound();
            }

            return View(usuarioCurso);
        }

        // POST: UsuarioCurso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarioCurso = await _context.UsuarioCurso.FindAsync(id);
            _context.UsuarioCurso.Remove(usuarioCurso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioCursoExists(int id)
        {
            return _context.UsuarioCurso.Any(e => e.Id == id);
        }
    }
}
