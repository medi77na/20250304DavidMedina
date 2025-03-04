using AutoMapper;
using Crecer.Dtos;
using Crecer.Models;

namespace Crecer.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Estudiante, EstudianteGetDto>();
            CreateMap<EstudiantePostDto, Estudiante>();
        }
    }
}
