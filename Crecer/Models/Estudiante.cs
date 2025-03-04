namespace Crecer.Models
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public string? Correo { get; set; }

        // Relación con Materias
        public ICollection<EstudianteMateria> EstudianteMaterias { get; set; }

        public int CalcularEdad()
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            var age = today.Year - FechaNacimiento.Year;
            if (FechaNacimiento > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }
}
