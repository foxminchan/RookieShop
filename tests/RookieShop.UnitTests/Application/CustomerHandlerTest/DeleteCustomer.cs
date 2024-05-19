using Ardalis.GuardClauses;
using RookieShop.Application.Customers.Commands.Delete;
using RookieShop.Domain.Entities.CategoryAggregator.Primitives;
using RookieShop.Domain.Entities.CustomerAggregator;
using RookieShop.Domain.Entities.CustomerAggregator.Enums;
using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.UnitTests.Application.CustomerHandlerTest;

public sealed class DeleteCustomer
{
    private readonly DeleteCustomerHandler _handler;
    private readonly Mock<IRepository<Customer>> _repositoryMock;

    public DeleteCustomer()
    {
        _repositoryMock = new();
        _handler = new(_repositoryMock.Object);
    }

    private static Customer CreateCustomerEntity() =>
        new("Customer Name", "customer@gmail.com", "0123456789", Gender.Male, Guid.NewGuid());


    [Fact]
    public async Task GivenValidId_ShouldReturnSuccessResult_IfCustomerExists()
    {
        // Arrange
        var command = new DeleteCustomerCommand(new(Guid.NewGuid()));
        _repositoryMock.Setup(repo =>
                repo.GetByIdAsync(It.IsAny<CustomerId>(), CancellationToken.None))
            .ReturnsAsync(CreateCustomerEntity);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        _repositoryMock.Verify(repo =>
            repo.UpdateAsync(It.IsAny<Customer>(), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task GivenValidId_ShouldThrowNotFoundException_IfCustomerIsNotExists()
    {
        // Arrange
        var command = new DeleteCustomerCommand(new(Guid.NewGuid()));
        _repositoryMock.Setup(repo =>
                repo.GetByIdAsync(It.IsAny<CategoryId>(), CancellationToken.None))
            .ReturnsAsync((Customer?)null);

        // Act
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}