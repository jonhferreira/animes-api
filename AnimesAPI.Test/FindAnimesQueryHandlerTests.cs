

using AnimesAPI.Application.Animes.Queries;
using AnimesAPI.Application.DTO;
using AnimesAPI.Domain.Entities;
using AnimesAPI.Domain.Interfaces.Abstractions;
using AnimesAPI.Domain.Interfaces.Repositories;
using FluentAssertions;
using Moq;
using System.Net;

namespace AnimesAPI.Test;

public class FindAnimesQueryHandlerTests
{
    private readonly Mock<IAnimeRepository> _animeRepositoryMock;
    private readonly Mock<MessageGet> _messageGetMock;
    private readonly Mock<IErrorMessage> _errorMessageMock;
    private readonly FindAnimesQueryHandler _handler;

    public FindAnimesQueryHandlerTests()
    {
        
        _animeRepositoryMock = new Mock<IAnimeRepository>();
        _messageGetMock = new Mock<MessageGet>();
        _errorMessageMock = new Mock<IErrorMessage>();

        
        _handler = new FindAnimesQueryHandler(
            _animeRepositoryMock.Object,
            _messageGetMock.Object,
            _errorMessageMock.Object
        );
    }

    [Fact]
    public async Task Handle_ShouldReturnAnimes_WhenQueryIsSuccessful()
    {
        // Arrange
        var request = new FindAnimesQuery
        {
            Id = 1,
            Director = "Masashi Kishimoto",
            Name = "Naruto"
        };

        var animes = new List<Anime>
    {
        new Anime
        {
            Id = 1,
            Name = "Naruto",
            Description = "An anime about ninjas.",
            Director = "Masashi Kishimoto",
            IsDeleted = false
        }
    };

        
        _animeRepositoryMock.Setup(r => r.Get(request.Id, request.Director, request.Name))
                            .ReturnsAsync(animes);

        
        _messageGetMock.Setup(m => m.Message200Mult(It.IsAny<string>()))
                       .Returns("Animes retrieved successfully");

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        result.Data.Should().NotBeNull();
        result.Success.Should().BeTrue();
        result.StatusCode.Should().Be(HttpStatusCode.OK);
        result.Data.Should().BeEquivalentTo(animes);
        result.Message.Should().Be("Animes retrieved successfully");

        // Verificando se o método Get foi chamado corretamente
        _animeRepositoryMock.Verify(r => r.Get(request.Id, request.Director, request.Name), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldReturnError_WhenExceptionOccurs()
    {
        // Arrange
        var request = new FindAnimesQuery
        {
            Id = 1,
            Director = "Masashi Kishimoto",
            Name = "Naruto"
        };

        
        _animeRepositoryMock.Setup(r => r.Get(request.Id, request.Director, request.Name))
                            .ThrowsAsync(new Exception("Database error"));

        
        _errorMessageMock.Setup(m => m.ErrorMessage500())
                         .Returns("Internal server error");

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Success.Should().BeFalse();
        result.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        result.Message.Should().Be("Internal server error");
        result.Data.Should().BeNull();

        // Verificando se o método Get foi chamado corretamente
        _animeRepositoryMock.Verify(r => r.Get(request.Id, request.Director, request.Name), Times.Once);
    }
}
