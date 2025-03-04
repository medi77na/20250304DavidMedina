using Crecer.Context;
using Crecer.Interfaces;
using Crecer.Models;
using Microsoft.EntityFrameworkCore;

namespace Crecer.Repositories
{
    public class EstudianteMateriaRepository : IEstudianteMateriaRepository
    {
        private readonly AppDbContext _context;

        public EstudianteMateriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Materia>> ObtenerMateriasPorIdEstudiante(int estudianteId)
        {
            return await _context.EstudianteMaterias
                .Where(em => em.EstudianteId == estudianteId)
                .Select(em => em.Materia)
                .ToListAsync();
        }
    }
}
