

using AnimesAPI.Application.Animes.Commands;
using AnimesAPI.Application.DTO;
using AnimesAPI.Domain.Entities;
using AnimesAPI.Domain.Interfaces.Abstractions;
using AnimesAPI.Domain.Interfaces.Repositories;
using FluentAssertions;
using Moq;
using System.Net;
using System.Xml.Linq;

namespace AnimesAPI.Test
{
    public class UpdateAnimeCommandHandlerTests
    {
        private readonly Mock<IAnimeRepository> _animeRepositoryMock;
        private readonly Mock<MessageUpdate> _updateMessageMock;
        private readonly Mock<IErrorMessage> _errorMessageMock;
        private readonly UpdateAnimeCommandHandler _handler;

        public UpdateAnimeCommandHandlerTests()
        {
            // Criando mocks das dependências
            _animeRepositoryMock = new Mock<IAnimeRepository>();
            _updateMessageMock = new Mock<MessageUpdate>();
            _errorMessageMock = new Mock<IErrorMessage>();

            // Inicializando o handler com as dependências mockadas
            _handler = new UpdateAnimeCommandHandler(
                _animeRepositoryMock.Object,
                _updateMessageMock.Object,
                _errorMessageMock.Object
            );
        }

        [Fact]
        public async Task Handle_ShouldReturnSuccess_WhenAnimeIsUpdated()
        {
            // Arrange
            var request = new UpdateAnimeCommand
            {
                Id = 10,
                Name = "Naruto",
                Description = "An anime about ninjas.",
                Director = "Masashi Kishimoto",
                IsDeleted = false,
            };

            var anime = new Anime()
            { 
                Id = 10,
                Name = request.Name,
                Description = request.Description,
                Director = request.Director, 
            };

            _animeRepositoryMock.Setup(r => r.Get(It.IsAny<int>()))
                                .ReturnsAsync(anime);

            _animeRepositoryMock.Setup(r => r.Update(It.IsAny<Anime>()))
                                .ReturnsAsync(anime);

            _updateMessageMock.Setup(m => m.Message200(It.IsAny<string>()))
                               .Returns("Update successfully");

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);


            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().BeEquivalentTo(anime);
            result.Message.Should().Be("Update successfully");

            // Verificando se o repositório foi chamado
            _animeRepositoryMock.Verify(r => r.Update(It.IsAny<Anime>()), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenExceptionIsThrown()
        {
            // Arrange
            var request = new UpdateAnimeCommand
            {
                Id = 10,
                Name = "Naruto",
                Description = "An anime about ninjas.",
                Director = "Masashi Kishimoto",
                IsDeleted = false,
            };

            var anime = new Anime()
            {
                Id = 10,
                Name = request.Name,
                Description = request.Description,
                Director = request.Director,
            };

            _animeRepositoryMock.Setup(r => r.Get(It.IsAny<int>()))
                                .ReturnsAsync(anime);

            _animeRepositoryMock.Setup(r => r.Update(It.IsAny<Anime>()))
                                .ThrowsAsync(new Exception("Something went wrong"));

            _errorMessageMock.Setup(m => m.ErrorMessage500()).Returns("Internal Server Error");

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
            result.Message.Should().Be("Internal Server Error");
            result.MoreDetails.Should().Be("Something went wrong");

            // Verificando se o repositório foi chamado
            _animeRepositoryMock.Verify(r => r.Update(It.IsAny<Anime>()), Times.Once);
        }
    }
}
