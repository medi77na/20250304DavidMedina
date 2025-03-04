using Crecer.Models;

namespace Crecer.Interfaces
{
    public interface IEstudianteMateriaRepository
    {
        Task<IEnumerable<Materia>> ObtenerMateriasPorIdEstudiante(int estudianteId);
    }
}
