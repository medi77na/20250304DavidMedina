using Crecer.Dtos;

namespace Crecer.Interfaces
{
    public interface IEstudianteService
    {
        Task<EstudianteGetDto> ObtenerPorId(int id);
        Task<EstudianteGetDto> ObtenerPorCodigo(string codigo);
        Task<IEnumerable<EstudianteGetDto>> ObtenerTodos();
        Task Agregar(EstudiantePostDto estudianteDto);
        Task Actualizar(EstudiantePostDto estudianteDto);
        Task Eliminar(int id);
    }
}
