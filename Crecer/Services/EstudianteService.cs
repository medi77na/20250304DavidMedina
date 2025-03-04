using AutoMapper;
using Crecer.Dtos;
using Crecer.Interfaces;
using Crecer.Models;

namespace Crecer.Services
{
    public class EstudianteService : IEstudianteService
    {
        private readonly IEstudianteRepository _estudianteRepository;
        private readonly IMapper _mapper;

        public EstudianteService(IEstudianteRepository estudianteRepository, IMapper mapper)
        {
            _estudianteRepository = estudianteRepository;
            _mapper = mapper;
        }

        public async Task<EstudianteGetDto> ObtenerPorId(int id)
        {
            var estudiante = await _estudianteRepository.ObtenerPorId(id);
            return _mapper.Map<EstudianteGetDto>(estudiante);
        }

        public async Task<EstudianteGetDto> ObtenerPorCodigo(string codigo)
        {
            var estudiante = await _estudianteRepository.ObtenerPorCodigo(codigo);
            return _mapper.Map<EstudianteGetDto>(estudiante);
        }

        public async Task<IEnumerable<EstudianteGetDto>> ObtenerTodos()
        {
            var estudiantes = await _estudianteRepository.ObtenerTodos();
            return _mapper.Map<IEnumerable<EstudianteGetDto>>(estudiantes);
        }

        public async Task Agregar(EstudiantePostDto estudianteDto)
        {
            var estudiante = _mapper.Map<Estudiante>(estudianteDto);
            estudiante.Edad = estudiante.CalcularEdad();
            await _estudianteRepository.Agregar(estudiante);
        }

        public async Task Actualizar(EstudiantePostDto estudianteDto)
        {
            var estudiante = await _estudianteRepository.ObtenerPorCodigo(estudianteDto.Codigo);
            if (estudiante != null)
            {
                _mapper.Map(estudianteDto, estudiante);
                await _estudianteRepository.Actualizar(estudiante);
            }
        }

        public async Task Eliminar(int id)
        {
            await _estudianteRepository.Eliminar(id);
        }
    }
}
