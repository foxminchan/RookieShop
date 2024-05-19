using RookieShop.Domain.Entities.CustomerAggregator;
using RookieShop.Domain.Entities.CustomerAggregator.Enums;

namespace RookieShop.UnitTests.Domain.CustomerTest;

public sealed class UpdateCustomer
{
    private const string TestName = "Name 1";
    private const string TestEmail = "email1@gmail.com";
    private const string TestPhone = "0123456789";
    private const Gender TestGender = Gender.Male;

    public static TheoryData<Customer> InvalidCustomerData
    {
        get
        {
            var data = new TheoryData<Customer>
            {
                new() { Name = null!, Email = null!, Phone = null!, Gender = Gender.Male, AccountId = null },
                new() { Name = "Name 1", Email = null!, Phone = null!, Gender = Gender.Male, AccountId = null },
                new()
                {
                    Name = "Name 1", Email = "email2@gmail.com", Phone = null!, Gender = Gender.Male, AccountId = null
                },
                new() { Name = "Name 1", Email = null!, Phone = "0987654321", Gender = Gender.Male, AccountId = null }
            };

            return data;
        }
    }

    [Fact]
    public void GivenValidaData_ShouldUpdateCustomer()
    {
        // Arrange
        var customer = new Customer(TestName, TestEmail, TestPhone, TestGender, null);
        const string newName = "Name 2";
        const string newEmail = "email2@gmail.com";
        const string newPhone = "0987654321";

        // Act
        customer.Update(newName, newEmail, newPhone, TestGender, null);

        // Assert
        Assert.Equal(newName, customer.Name);
        Assert.Equal(newEmail, customer.Email);
        Assert.Equal(newPhone, customer.Phone);
    }

    [Theory]
    [MemberData(nameof(InvalidCustomerData))]
    public void GivenInvalidData_ShouldThrowArgumentNullException(Customer data)
    {
        // Arrange
        var customer = new Customer(TestName, TestEmail, TestPhone, TestGender, null);

        // Act
        Assert.Throws<ArgumentNullException>(() =>
            customer.Update(data.Name, data.Email, data.Phone, data.Gender, data.AccountId));
    }
}