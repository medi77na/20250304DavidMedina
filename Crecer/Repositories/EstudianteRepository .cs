using Crecer.Context;
using Crecer.Interfaces;
using Crecer.Models;
using Microsoft.EntityFrameworkCore;

namespace Crecer.Repositories
{
    // EstudianteRepository.cs
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly AppDbContext _context;

        public EstudianteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Estudiante> ObtenerPorId(int id)
        {
            return await _context.Estudiantes.FindAsync(id);
        }

        public async Task<Estudiante> ObtenerPorCodigo(string codigo)
        {
            return await _context.Estudiantes.FirstOrDefaultAsync(e => e.Codigo == codigo);
        }

        public async Task<IEnumerable<Estudiante>> ObtenerTodos()
        {
            return await _context.Estudiantes.ToListAsync();
        }

        public async Task Agregar(Estudiante estudiante)
        {
            await _context.Estudiantes.AddAsync(estudiante);
            await _context.SaveChangesAsync();        
        }

        public async Task Actualizar(Estudiante estudiante)
        {
            _context.Estudiantes.Update(estudiante);
            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var estudiante = await ObtenerPorId(id);
            if (estudiante != null)
            {
                _context.Estudiantes.Remove(estudiante);
                await _context.SaveChangesAsync();
            }
        }
    }
}
