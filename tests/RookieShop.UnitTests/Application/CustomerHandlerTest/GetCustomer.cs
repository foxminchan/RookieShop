using Ardalis.GuardClauses;
using RookieShop.Application.Customers.Queries.Get;
using RookieShop.Domain.Entities.CustomerAggregator;
using RookieShop.Domain.Entities.CustomerAggregator.Enums;
using RookieShop.Domain.Entities.CustomerAggregator.Specifications;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.UnitTests.Application.CustomerHandlerTest;

public sealed class GetCustomer
{
    private readonly GetCustomerHandler _handler;
    private readonly Mock<IReadRepository<Customer>> _repositoryMock;

    public GetCustomer()
    {
        _repositoryMock = new();
        _handler = new(_repositoryMock.Object);
    }

    [Fact]
    public async Task GivenValidId_ShouldReturnCustomer_IfCustomerExists()
    {
        // Arrange
        var customer = new Customer("Customer Name", "customer@gmail.com", "0123456789", Gender.Male,
            Guid.NewGuid());
        _repositoryMock.Setup(repo =>
                repo.FirstOrDefaultAsync(It.IsAny<CustomerByIdSpec>(), CancellationToken.None))
            .ReturnsAsync(customer);

        var query = new GetCustomerQuery(new(Guid.NewGuid()));

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        _repositoryMock.Verify(repo =>
            repo.FirstOrDefaultAsync(It.IsAny<CustomerByIdSpec>(), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task GivenValidId_ShouldThrowNotFoundException_IfCustomerNotExists()
    {
        // Arrange
        var query = new GetCustomerQuery(new(Guid.NewGuid()));
        _repositoryMock.Setup(repo =>
                repo.FirstOrDefaultAsync(It.IsAny<CustomerByIdSpec>(), CancellationToken.None))
            .ReturnsAsync((Customer?)null);

        // Act
        Func<Task> act = async () => await _handler.Handle(query, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
        _repositoryMock.Verify(repo =>
            repo.FirstOrDefaultAsync(It.IsAny<CustomerByIdSpec>(), CancellationToken.None), Times.Once);
    }
}