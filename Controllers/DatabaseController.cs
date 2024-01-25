using examen.Data;
using examen.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace examen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly Context _context;
        public DatabaseController(Context context)
        {
            _context = context;
        }

        [HttpGet("profesori")]
        public async Task<IActionResult> GetProfesori()
        {
            return Ok(await _context.Profesori.ToListAsync());
        }

        [HttpGet("materii")]
        public async Task<IActionResult> GetMaterii()
        {
            return Ok(await _context.Materii.ToListAsync());
        }

        [HttpPost("postProfesori")]
        public async Task<IActionResult> Create(Profesor profesor)
        {
            var newProfesor = new Profesor
            {
                ProfesorId = profesor.ProfesorId,
                Nume = profesor.Nume,
                Varsta = profesor.Varsta,
                Tip = profesor.Tip
            };

            await _context.AddAsync(newProfesor);
            await _context.SaveChangesAsync();

            return Ok(newProfesor);
        }
        [HttpPost("postMaterii")]
        public async Task<IActionResult> Create(Materie materie)
        {
            var newMaterie = new Materie
            {
                MaterieId = materie.MaterieId,
                Nume = materie.Nume,
                Credite = materie.Credite
            };

            await _context.AddAsync(newMaterie);
            await _context.SaveChangesAsync();

            return Ok(newMaterie);
        }

        [HttpPost("asignare")]
        public async Task<IActionResult> Asignare(int profesorId, int materieId)
        {
            var profesor = await _context.Profesori.FindAsync(profesorId);
            var materie = await _context.Materii.FindAsync(materieId);

            if (profesor == null || materie == null)
            {
                return NotFound();
            }

            var profesorMaterie = new ProfesoriMaterii
            {
                Profesor = profesor,
                Materie = materie
            };

            _context.ProfesoriMaterii.Add(profesorMaterie);
            await _context.SaveChangesAsync();

            return Ok(profesorMaterie);
        }

    }
}
