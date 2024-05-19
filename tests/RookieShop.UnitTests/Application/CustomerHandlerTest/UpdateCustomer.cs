using Ardalis.GuardClauses;
using Microsoft.Extensions.Logging;
using RookieShop.Application.Customers.Commands.Update;
using RookieShop.Domain.Entities.CustomerAggregator;
using RookieShop.Domain.Entities.CustomerAggregator.Enums;
using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.UnitTests.Application.CustomerHandlerTest;

public sealed class UpdateCustomer
{
    private readonly UpdateCustomerHandler _handler;
    private readonly Mock<IRepository<Customer>> _repositoryMock;

    public UpdateCustomer()
    {
        Mock<ILogger<UpdateCustomerHandler>> loggerMock = new();
        _repositoryMock = new();
        _handler = new(_repositoryMock.Object, loggerMock.Object);
    }

    private static Customer CreateCustomerEntity() =>
        new("Customer Name", "customer@gmail.com", "0123456789", Gender.Male, Guid.NewGuid());

    [Fact]
    public async Task GivenValidRequest_ShouldUpdateCustomer_IfCustomerExists()
    {
        // Arrange
        var command = new UpdateCustomerCommand(new(Guid.NewGuid()), "Customer Name", "customer@gmail.com",
            "0123456789", Gender.Male, Guid.NewGuid());
        _repositoryMock.Setup(repo =>
                repo.GetByIdAsync(It.IsAny<CustomerId>(), CancellationToken.None))
            .ReturnsAsync(CreateCustomerEntity);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.Value.Name.Should().Be("Customer Name");
        result.Value.Email.Should().Be("customer@gmail.com");
        result.Value.Phone.Should().Be("0123456789");
    }

    [Fact]
    public async Task GivenValidRequest_ShouldThrowNotFoundException_IfCustomerIsNotExists()
    {
        // Arrange
        var command = new UpdateCustomerCommand(new(Guid.NewGuid()), "Customer Name", "customer@gmail.com",
            "0123456789", Gender.Male, Guid.NewGuid());
        _repositoryMock.Setup(repo =>
                repo.GetByIdAsync(It.IsAny<CustomerId>(), CancellationToken.None))
            .ReturnsAsync((Customer?)null);

        // Act
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
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
        var command =
            new UpdateCustomerCommand(new(Guid.NewGuid()), name!, email!, phone!, Gender.Male, Guid.NewGuid());
        _repositoryMock.Setup(repo =>
                repo.GetByIdAsync(It.IsAny<CustomerId>(), CancellationToken.None))
            .ReturnsAsync(CreateCustomerEntity);

        // Act
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ArgumentException>();
    }
}