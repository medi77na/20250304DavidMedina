using Crecer.Models;

namespace Crecer.Seeders
{
    public static class EstudianteSeeder
    {
        public static List<Estudiante> GetSeedData()
        {
            return new List<Estudiante>
            {
                new Estudiante
                {
                    Id = 1,
                    Codigo = "2019100001",
                    Nombres = "Juan",
                    Apellidos = "Perez",
                    FechaNacimiento = new DateOnly(2000, 1, 1),
                    Edad = 21,
                    Correo = "juanperez@example.com"
                },
                new Estudiante
                {
                    Id = 2,
                    Codigo = "2019100002",
                    Nombres = "Maria",
                    Apellidos = "Lopez",
                    FechaNacimiento = new DateOnly(2000, 2, 2),
                    Edad = 21,
                    Correo = "marialopez@example.com"
                },
                new Estudiante {
                    Id = 3,
                    Codigo = "2019100003",
                    Nombres = "Pedro",
                    Apellidos = "Gomez",
                    FechaNacimiento = new DateOnly(2000, 3, 3),
                    Edad = 21,
                    Correo = "pedrogomez@example.com"
                }

            };
        }
    }
}
