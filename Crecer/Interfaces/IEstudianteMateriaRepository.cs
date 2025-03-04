using Crecer.Dtos;
using Crecer.Models;

namespace Crecer.Interfaces
{
    public interface IEstudianteMateriaRepository
    {
        Task<IEnumerable<MateriaDto>> ObtenerMateriasPorIdEstudiante(int estudianteId);
    }
}
