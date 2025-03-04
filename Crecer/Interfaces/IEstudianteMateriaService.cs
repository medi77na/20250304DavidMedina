using Crecer.Dtos;

namespace Crecer.Interfaces
{
    public interface IEstudianteMateriaService
    {
        Task<IEnumerable<MateriaDto>> ObtenerMateriasPorIdEstudiante(int estudianteId);
    }
}
