using BugStore.Domain.Entities;

namespace BugStore.Domain.Tests.Entities;
public class CustomerTest
{
    private static Customer ValidCustomer()
    {
        return new Customer
        {
            Id = Guid.NewGuid(),
            Name = "Alice Pais Maravilhas",
            Phone = "11999989712",
            BirthDate = new DateTime(1999, 12, 31),
        };
    }

    [Fact]

    public void TheCustomerFieldCannotBeEmpty() 
    {
        var customer = ValidCustomer();        

        Assert.NotNull(customer);
    }

    [Fact]

    public void TheCustomerFieldIDCannotBeEmpty()
    {
        var customer = ValidCustomer().Id;       

        Assert.NotEqual(Guid.Empty,customer);
    }

    [Fact]

    public void TheCustomerFieldNameCannotBeEmpty()
    {
        var customer = ValidCustomer().Name;

        

        Assert.NotEqual("", customer);
    }

    [Fact]
    public void TheCustomerFieldEmailCannotBeEmpty()
    {
        var customer = ValidCustomer().Email;

        Assert.NotEqual("", customer);
    }

    [Fact]
    public void TheCustomerFieldBirthDateCannotBeEmpty()
    {
        var customer = ValidCustomer().BirthDate = DateTime.Now;

        var email = DateTime.Now;

        Assert.NotEqual(email, customer);
    }
}
