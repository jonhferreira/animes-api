using Moq;
using Xunit;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System;
using AnimesAPI.Domain.Interfaces.Repositories;
using AnimesAPI.Domain.Interfaces.Abstractions;
using AnimesAPI.Application.Animes.Commands;
using AnimesAPI.Domain.Entities;
using AnimesAPI.Application.DTO;


namespace AnimesAPI.Test
{
    

    public class CreateAnimeCommandHandlerTests
    {
        private readonly Mock<IAnimeRepository> _animeRepositoryMock;
        private readonly Mock<ISuccessMessage> _successMessageMock;
        private readonly Mock<IErrorMessage> _errorMessageMock;
        private readonly CreateAnimeCommandHandler _handler;

        public CreateAnimeCommandHandlerTests()
        {
            // Criando mocks das dependências
            _animeRepositoryMock = new Mock<IAnimeRepository>();
            _successMessageMock = new Mock<ISuccessMessage>();
            _errorMessageMock = new Mock<IErrorMessage>();

            // Inicializando o handler com as dependências mockadas
            _handler = new CreateAnimeCommandHandler(
                _animeRepositoryMock.Object,               
                _errorMessageMock.Object,
                _successMessageMock.Object
            );
        }

        [Fact]
        public async Task Handle_ShouldReturnSuccess_WhenAnimeIsCreated()
        {
            // Arrange
            var request = new CreateAnimeCommand
            {
                Name = "Naruto",
                Description = "An anime about ninjas.",
                Director = "Masashi Kishimoto"
            };

            var anime = new Anime()
            {
                Name = request.Name,
                Description = request.Description,
                Director = request.Director
            };

            var apiResponse = new ApiResponse<Anime>(true, HttpStatusCode.OK, anime, "Created successfully", "");


            _animeRepositoryMock.Setup(r => r.Create(It.IsAny<Anime>()))
                                .ReturnsAsync(anime);

            _successMessageMock.Setup(m => m.Message201(It.IsAny<string>()))
                               .Returns("Created successfully");

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().BeEquivalentTo(anime);
            result.Message.Should().Be("Created successfully");

            // Verificando se o repositório foi chamado
            _animeRepositoryMock.Verify(r => r.Create(It.IsAny<Anime>()), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenExceptionIsThrown()
        {
            // Arrange
            var request = new CreateAnimeCommand
            {
                Name = "Naruto",
                Description = "An anime about ninjas.",
                Director = "Masashi Kishimoto"
            };

            _animeRepositoryMock.Setup(r => r.Create(It.IsAny<Anime>()))
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
            _animeRepositoryMock.Verify(r => r.Create(It.IsAny<Anime>()), Times.Once);
        }
    }

}