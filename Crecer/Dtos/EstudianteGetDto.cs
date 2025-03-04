namespace Crecer.Dtos
{
    public class EstudianteGetDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public string Correo { get; set; }
    }
}
