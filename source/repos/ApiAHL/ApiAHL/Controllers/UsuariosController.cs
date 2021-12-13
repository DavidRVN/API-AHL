using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApiAHL.Data;
using ApiAHL.Models;

namespace ApiAHL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly ApiAHLContext _context;

        public UsuariosController(ApiAHLContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuarios>>> getUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }



        [HttpGet("{username}/{password}")]
        public ActionResult<List<Usuarios>> GetLogin(string username, string password)
        {
            try
            {
                var usuarios = _context.Usuarios.Where(usuario => usuario.usuario.Equals(username) && usuario.contraseña.Equals(password)).ToList();
                if (usuarios == null)
                {
                    return NotFound();
                }
                return usuarios;
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }


        /* // GET: Usuarios
         public async Task<IActionResult> Index()
         {
             return View(await _context.Usuarios.ToListAsync());
         }

         // GET: Usuarios/Details/5
         public async Task<IActionResult> Details(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var usuarios = await _context.Usuarios
                 .FirstOrDefaultAsync(m => m.idusuario == id);
             if (usuarios == null)
             {
                 return NotFound();
             }

             return View(usuarios);
         }

         // GET: Usuarios/Create
         public IActionResult Create()
         {
             return View();
         }

         // POST: Usuarios/Create
         // To protect from overposting attacks, enable the specific properties you want to bind to.
         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Create([Bind("idusuario,nombre,apellido,usuario,contraseña,rol")] Usuarios usuarios)
         {
             if (ModelState.IsValid)
             {
                 _context.Add(usuarios);
                 await _context.SaveChangesAsync();
                 return RedirectToAction(nameof(Index));
             }
             return View(usuarios);
         }

         // GET: Usuarios/Edit/5
         public async Task<IActionResult> Edit(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var usuarios = await _context.Usuarios.FindAsync(id);
             if (usuarios == null)
             {
                 return NotFound();
             }
             return View(usuarios);
         }

         // POST: Usuarios/Edit/5
         // To protect from overposting attacks, enable the specific properties you want to bind to.
         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Edit(int id, [Bind("idusuario,nombre,apellido,usuario,contraseña,rol")] Usuarios usuarios)
         {
             if (id != usuarios.idusuario)
             {
                 return NotFound();
             }

             if (ModelState.IsValid)
             {
                 try
                 {
                     _context.Update(usuarios);
                     await _context.SaveChangesAsync();
                 }
                 catch (DbUpdateConcurrencyException)
                 {
                     if (!UsuariosExists(usuarios.idusuario))
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
             return View(usuarios);
         }

         // GET: Usuarios/Delete/5
         public async Task<IActionResult> Delete(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var usuarios = await _context.Usuarios
                 .FirstOrDefaultAsync(m => m.idusuario == id);
             if (usuarios == null)
             {
                 return NotFound();
             }

             return View(usuarios);
         }

         // POST: Usuarios/Delete/5
         [HttpPost, ActionName("Delete")]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> DeleteConfirmed(int id)
         {
             var usuarios = await _context.Usuarios.FindAsync(id);
             _context.Usuarios.Remove(usuarios);
             await _context.SaveChangesAsync();
             return RedirectToAction(nameof(Index));
         }*/

        private bool UsuariosExists(int id)
        {
            return _context.Usuarios.Any(e => e.idusuario == id);
        }
    }
}
