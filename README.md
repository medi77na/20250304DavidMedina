# Student Management API

## Descripción
Una API RESTful desarrollada en ASP.NET Core para gestionar información de estudiantes y sus materias. El proyecto permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre estudiantes y materias, con soporte de dockerización y base de datos SQL Server.

## Requisitos
- .NET Core 7.0 o superior
- Docker Desktop 4.x
- Docker Compose 1.29.x
- SQL Server 2019 o superior

## Estructura del Proyecto
```
student-management-api/
│
├── src/
│   ├── Controllers/
│   │   ├── EstudiantesController.cs
│   │   └── MateriasController.cs
│   │
│   ├── Models/
│   │   ├── Estudiante.cs
│   │   └── Materia.cs
│   │
│   ├── Services/
│   │   ├── EstudianteService.cs
│   │   └── MateriaService.cs
│   │
│   ├── Data/
│   │   └── ApplicationDbContext.cs
│   │
│   └── appsettings.json
│
├── Dockerfile
├── docker-compose.yml
└── README.md
```

## Configuración de Docker

### Dockerfile
```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["student-management-api.csproj", "./"]
RUN dotnet restore "student-management-api.csproj"
COPY . .
RUN dotnet build "student-management-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "student-management-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "student-management-api.dll"]
```

### docker-compose.yml
```yaml
version: '3.8'
services:
  api:
    build: .
    ports:
      - "5000:80"
    depends_on:
      - database
    environment:
      - ASPNETCORE_ENVIRONMENT=Production
      - ConnectionStrings__DefaultConnection=Server=database;Database=StudentManagementDB;User=sa;Password=Tu_Contraseña_Segura_123!;

  database:
    image: mcr.microsoft.com/mssql/server:2019-latest
    environment:
      SA_PASSWORD: Tu_Contraseña_Segura_123!
      ACCEPT_EULA: Y
    ports:
      - "1433:1433"
    volumes:
      - sqlserver-data:/var/opt/mssql/data

volumes:
  sqlserver-data:
```

## Configuración de la Base de Datos
1. Asegúrate de reemplazar `Tu_Contraseña_Segura_123!` con una contraseña segura.
2. La base de datos se creará automáticamente al levantar los contenedores.
3. Utiliza Entity Framework Core Migrations para gestionar los esquemas de base de datos.

## Ejecución del Proyecto
```bash
# Construir y levantar los contenedores
docker-compose up --build

# Detener los contenedores
docker-compose down
```

## Funcionalidades
- Registro de nuevos estudiantes
- Consulta de estudiantes por ID
- Listado de todos los estudiantes
- Asignación de materias a estudiantes
- Consulta de materias por estudiante

## Endpoints Principales
- `GET /api/estudiantes`: Obtener todos los estudiantes
- `GET /api/estudiantes/{id}`: Obtener estudiante por ID
- `POST /api/estudiantes`: Crear nuevo estudiante
- `PUT /api/estudiantes/{id}`: Actualizar estudiante
- `DELETE /api/estudiantes/{id}`: Eliminar estudiante

## Problemas Comunes
1. **Error de conexión a la base de datos**
   - Verifica que la cadena de conexión sea correcta
   - Asegúrate de que los puertos no estén ocupados

2. **Problemas con Docker**
   - Actualiza Docker Desktop a la última versión
   - Elimina volúmenes antiguos con `docker volume prune`

## Contribuciones
1. Haz un fork del repositorio
2. Crea una nueva rama (`git checkout -b feature/nueva-funcionalidad`)
3. Realiza tus cambios y commitea (`git commit -m 'Añadir nueva funcionalidad'`)
4. Pushea a la rama (`git push origin feature/nueva-funcionalidad`)
5. Abre un Pull Request

## Licencia
Este proyecto está bajo la Licencia MIT. Consulta el archivo `LICENSE` para más detalles.

## Contacto
Para cualquier duda o sugerencia, por favor abre un issue en el repositorio.
