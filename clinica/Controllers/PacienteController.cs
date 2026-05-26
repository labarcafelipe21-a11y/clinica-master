using clinica.Models;
using clinica.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace clinica.Controllers
{
    public class PacienteController : Controller
    {
        private readonly ClinicaDbContext _context;

        public PacienteController(ClinicaDbContext context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> Index()
        {
            var pacientes = await _context.Pacientes.ToListAsync();
            return View(pacientes);
        }

       
        public async Task<IActionResult> Resumen()
        {
            var pacientes = await _context.Pacientes.ToListAsync();
            return View(new ResumenDia { Pacientes = pacientes });
        }

       
        public IActionResult Crear() => View(new Paciente { FechaAtencion = DateTime.Today });

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Paciente paciente)
        {
            if (!ModelState.IsValid) return View(paciente);

            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
            TempData["Mensaje"] = $"Paciente {paciente.NombreCompleto} registrado.";
            return RedirectToAction(nameof(Index));
        }

       
        public async Task<IActionResult> Detalle(int id)
        {
            var p = await _context.Pacientes.FindAsync(id);
            return p is null ? NotFound() : View(p);
        }

      
        public async Task<IActionResult> Editar(int id)
        {
            var p = await _context.Pacientes.FindAsync(id);
            return p is null ? NotFound() : View(p);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Paciente paciente)
        {
            if (id != paciente.Id) return BadRequest();
            if (!ModelState.IsValid) return View(paciente);

            _context.Pacientes.Update(paciente);
            await _context.SaveChangesAsync();
            TempData["Mensaje"] = $"Paciente {paciente.NombreCompleto} actualizado.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            var p = await _context.Pacientes.FindAsync(id);
            return p is null ? NotFound() : View(p);
        }

        
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            var p = await _context.Pacientes.FindAsync(id);
            if (p is not null)
            {
                _context.Pacientes.Remove(p);
                await _context.SaveChangesAsync();
            }
            TempData["Mensaje"] = "Paciente eliminado correctamente.";
            return RedirectToAction(nameof(Index));
        }
    }
}