using AutoFixture;
using AutoMapper;
using BugStore.Application.Services.Customers.Dto.Request;
using BugStore.Application.Services.Customers.Dto.Response;
using BugStore.Application.Services.Customers.Services;
using BugStore.Application.Services.Interfaces;
using BugStore.Application.Services.Products.Dto.Request;
using BugStore.Application.Services.Products.Dto.Response;
using BugStore.Application.Services.Products.Services;
using BugStore.Domain.Base;
using BugStore.Domain.Entities;
using Moq;

namespace BugStore.Application.Tests.Services;
public class ProductServiceTests
{
    private readonly IFixture _fixture = new Fixture();
    private readonly Mock<IRepository<Product>> _productRepositoryMock;
    private readonly ProductService _productService;
    private readonly IMapper _mapper;

    public ProductServiceTests()
    {
        _fixture = new Fixture();
        _productRepositoryMock = new Mock<IRepository<Product>>();

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ProductDtoRequest, Product>();
            cfg.CreateMap<Product, ProductDto>();
        });
        _mapper = config.CreateMapper();
        _productService = new ProductService
            (_productRepositoryMock.Object, _mapper);
    }

    [Fact]
    
    public async Task CreateAsync_ShouldAddProduct()
    {
        var request = _fixture.Create<ProductDtoRequest>();

        _productRepositoryMock.Setup(r => r.AddAsync(It.IsAny<Product>()))
                 .Returns(Task.CompletedTask);

        await _productService.CreateAsync(request);

        _productRepositoryMock
            .Verify(r => r.AddAsync(It.IsAny<Product>()),
            Times.Once);
    }
}
