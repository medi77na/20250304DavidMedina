using Crecer.Models;

namespace Crecer.Interfaces
{
    public interface IEstudianteRepository
    {
        Task<Estudiante> ObtenerPorId(int id);
        Task<Estudiante> ObtenerPorCodigo(string codigo);
        Task<IEnumerable<Estudiante>> ObtenerTodos();
        Task Agregar(Estudiante estudiante);
        Task Actualizar(Estudiante estudiante);
        Task Eliminar(int id);
    }
}
