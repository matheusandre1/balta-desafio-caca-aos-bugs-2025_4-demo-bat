using BugStore.Domain.Entities;

namespace BugStore.Domain.Tests.Entities;
public class ProductTest
{
    private static Product ValidProduct()
    {
        return new Product
        {
            Id = Guid.NewGuid(),
            Title = "Macbook Maravilhas",
            Description = "Computador",
            Slug = "Macbook-slug",
            Price = 90.90m
        };
    }

    [Fact]

    public void TheProductFieldCannotBeEmpty()
    {
        var product = ValidProduct();

        Assert.NotNull(product);
    }

    [Fact]

    public void TheProductFieldIDCannotBeEmpty()
    {
        var product = ValidProduct().Id = Guid.Empty;

        var guid = Guid.Empty;

        Assert.Equal(guid, product);
    }

    [Fact]
    public void TheProductFieldTitleCannotBeEmpty()
    {
        var product = ValidProduct().Title;
       

        Assert.NotEqual("", product);
    }

    [Fact]
    public void TheProductFieldDescriptionCannotBeEmpty()
    {
        var product = ValidProduct().Description;
        

        Assert.NotEqual("", product);
    }

}
