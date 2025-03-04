using Crecer.Controllers;
using Crecer.Dtos;
using Crecer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrecerTest
{
    public class EstudianteControllerTests
    {
        private readonly Mock<IEstudianteService> _estudianteServiceMock;
        private readonly EstudianteController _controller;

        public EstudianteControllerTests()
        {
            _estudianteServiceMock = new Mock<IEstudianteService>();
            _controller = new EstudianteController(_estudianteServiceMock.Object);
        }

        [Fact]
        public async Task ObtenerPorId_ReturnsOkResult_WhenEstudianteExists()
        {
            // Arrange
            var estudianteId = 1;
            var estudiante = new EstudianteGetDto { Id = estudianteId, Codigo = "E001", Nombres = "Juan", Apellidos = "Pérez" };
            _estudianteServiceMock.Setup(s => s.ObtenerPorId(estudianteId)).ReturnsAsync(estudiante);

            // Act
            var result = await _controller.ObtenerPorId(estudianteId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnEstudiante = Assert.IsType<EstudianteGetDto>(okResult.Value);
            Assert.Equal(estudianteId, returnEstudiante.Id);
        }

        [Fact]
        public async Task ObtenerPorId_ReturnsNotFound_WhenEstudianteDoesNotExist()
        {
            // Arrange
            var estudianteId = 1;
            _estudianteServiceMock.Setup(s => s.ObtenerPorId(estudianteId)).ReturnsAsync((EstudianteGetDto)null);

            // Act
            var result = await _controller.ObtenerPorId(estudianteId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Agregar_ReturnsCreatedAtAction_WhenModelStateIsValid()
        {
            // Arrange
            var estudianteDto = new EstudiantePostDto { Codigo = "E001", Nombres = "Juan", Apellidos = "Pérez" };
            _estudianteServiceMock.Setup(s => s.Agregar(estudianteDto)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Agregar(estudianteDto);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("ObtenerPorId", createdAtActionResult.ActionName);
        }

        [Fact]
        public async Task Agregar_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            var estudianteDto = new EstudiantePostDto(); // Invalid DTO
            _controller.ModelState.AddModelError("Codigo", "Required");

            // Act
            var result = await _controller.Agregar(estudianteDto);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
