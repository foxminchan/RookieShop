using RookieShop.Application.Customers.Queries.List;
using RookieShop.Domain.Entities.CustomerAggregator;
using RookieShop.Domain.Entities.CustomerAggregator.Enums;
using RookieShop.Domain.Entities.CustomerAggregator.Specifications;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.UnitTests.Application.CustomerHandlerTest;

public sealed class ListCustomer
{
    private readonly ListCustomersHandler _handler;
    private readonly Mock<IReadRepository<Customer>> _repositoryMock;

    public ListCustomer()
    {
        _repositoryMock = new();
        _handler = new(_repositoryMock.Object);
    }

    [Fact]
    public async Task GivenValidRequest_ShouldReturnNotEmptyList_IfCustomersExist()
    {
        // Arrange
        List<Customer> customers =
        [
            new("Customer Name1", "customer1@gmail.com", "0123456789", Gender.Male, Guid.NewGuid()),
            new("Customer Name2", "customer2@gmail.com", "0123456789", Gender.Male, Guid.NewGuid()),
            new("Customer Name3", "customer3@gmail.com", "0123456789", Gender.Male, Guid.NewGuid())
        ];
        _repositoryMock.Setup(repo =>
                repo.ListAsync(It.IsAny<CustomersFilterSpec>(), CancellationToken.None))
            .ReturnsAsync(customers);

        var query = new ListCustomersQuery(1, 0, null);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Value.Should().NotBeEmpty().And.HaveCount(3);
        _repositoryMock.Verify(repo =>
            repo.ListAsync(It.IsAny<CustomersFilterSpec>(), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task GivenValidRequest_ShouldReturnEmptyList_IfCustomersNotExist()
    {
        // Arrange
        var query = new ListCustomersQuery(1, 0, null);
        _repositoryMock.Setup(repo =>
                repo.ListAsync(It.IsAny<CustomersFilterSpec>(), CancellationToken.None))
            .ReturnsAsync([]);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Value.Should().BeEmpty();
        _repositoryMock.Verify(repo =>
            repo.ListAsync(It.IsAny<CustomersFilterSpec>(), CancellationToken.None), Times.Once);
    }
}