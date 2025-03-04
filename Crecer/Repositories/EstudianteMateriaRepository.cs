using Crecer.Context;
using Crecer.Dtos;
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

        public async Task<IEnumerable<MateriaDto>> ObtenerMateriasPorIdEstudiante(int estudianteId)
        {
            return await _context.EstudianteMaterias
                .Where(em => em.EstudianteId == estudianteId)
                .Select(em => new MateriaDto
                {
                    Id = em.Materia.Id,
                    Nombre = em.Materia.Nombre,
                    CodigoInstructor = em.Materia.CodigoInstructor,
                    Horario = em.Materia.Horario,
                    Ubicacion = em.Materia.Ubicacion
                })
                .ToListAsync();
        }
    }
}
