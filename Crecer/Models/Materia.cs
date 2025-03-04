namespace Crecer.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? CodigoInstructor { get; set; }
        public string? Horario { get; set; }
        public string? Ubicacion { get; set; }

        // Relación con Estudiantes
        public ICollection<EstudianteMateria> EstudianteMaterias { get; set; }
    }
}
