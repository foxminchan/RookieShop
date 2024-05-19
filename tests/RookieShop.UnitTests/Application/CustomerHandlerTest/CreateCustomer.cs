using Microsoft.Extensions.Logging;
using RookieShop.Application.Customers.Commands.Create;
using RookieShop.Domain.Entities.CustomerAggregator;
using RookieShop.Domain.Entities.CustomerAggregator.Enums;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.UnitTests.Application.CustomerHandlerTest;

public sealed class CreateCustomer
{
    private readonly CreateCustomerHandler _handler;
    private readonly Mock<IRepository<Customer>> _repositoryMock;

    public CreateCustomer()
    {
        Mock<ILogger<CreateCustomerHandler>> loggerMock = new();
        _repositoryMock = new();
        _handler = new(_repositoryMock.Object, loggerMock.Object);
    }

    private static Customer CreateCustomerEntity() =>
        new("Customer Name", "customer@gmail.com", "0123456789", Gender.Male, Guid.NewGuid());

    [Fact]
    public async Task GivenValidData_ShouldReturnSuccessResult()
    {
        // Arrange
        var command = new CreateCustomerCommand("Customer Name", "customer@gmail.com", "0123456789", Gender.Male,
            Guid.NewGuid());
        _repositoryMock.Setup(repo =>
                repo.AddAsync(It.IsAny<Customer>(), CancellationToken.None))
            .ReturnsAsync(CreateCustomerEntity);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Theory]
    [InlineData("", "", "")]
    [InlineData(null, null, null)]
    [InlineData(null, "", "0123456789")]
    [InlineData("Customer Name", "", null)]
    [InlineData("Customer Name", "", "0123456789")]
    public async Task GivenNullOrEmptyData_ShouldThrowArgumentException(string? name, string? email, string? phone)
    {
        // Arrange
        var command = new CreateCustomerCommand(name!, email!, phone!, Gender.Male, Guid.NewGuid());

        // Act
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ArgumentException>();
    }
}