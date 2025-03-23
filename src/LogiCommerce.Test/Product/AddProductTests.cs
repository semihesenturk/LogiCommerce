using FluentValidation;
using LogiCommerce.Application.Product.Commands.CreateProduct;
using LogiCommerce.Domain.AggregateModels.CategoryAggregate;
using LogiCommerce.Domain.AggregateModels.CategoryAggregate.Specification;
using LogiCommerce.Domain.AggregateModels.ProductAggregate;
using Moq;
using Xunit;

namespace LogiCommerce.Test.Product;

public class AddProductTests
{
    private readonly Mock<IProductRepository> _productRepositoryMock;
    private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
    private readonly Mock<IValidator<CreateProductCommand>> _validatorMock;
    private readonly CreateProductCommandHandler _commandHandler;

    public AddProductTests()
    {
        _productRepositoryMock = new Mock<IProductRepository>();
        _categoryRepositoryMock = new Mock<ICategoryRepository>();
        _validatorMock = new Mock<IValidator<CreateProductCommand>>();
        _commandHandler = new CreateProductCommandHandler(_productRepositoryMock.Object, _categoryRepositoryMock.Object,
            _validatorMock.Object);
    }

    [Fact]
    public async Task should_return_error_if_category_does_not_exist()
    {
        // Arrange
        var command = new CreateProductCommand
        {
            CategoryId = Guid.NewGuid(),
            Description = "description",
            StockQuantity = 100,
            Title = "Test title"
        };

        _categoryRepositoryMock.Setup(x =>
                x.FirstOrDefaultAsync(It.IsAny<GetCategoryByIdSpecification>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Category)null);


        _validatorMock.Setup(v => v.ValidateAsync(It.IsAny<CreateProductCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new FluentValidation.Results.ValidationResult());

        // Act
        var result = await _commandHandler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Category not found", result.Errors[0]);
        Assert.Equal(404, result.StatusCode);
    }

    [Fact]
    public async Task should_return_success_when_product_is_created()
    {
        // Arrange
        var command = new CreateProductCommand
        {
            CategoryId = Guid.NewGuid(),
            Description = "description",
            StockQuantity = 100,
            Title = "Test title"
        };

        var category = new Category
        {
            Id = command.CategoryId,
            Name = "Test Category",
            MinStockLevel = 10
        };

        _categoryRepositoryMock.Setup(x =>
                x.FirstOrDefaultAsync(It.IsAny<GetCategoryByIdSpecification>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(category);

        _validatorMock.Setup(v => v.ValidateAsync(It.IsAny<CreateProductCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new FluentValidation.Results.ValidationResult());

        _productRepositoryMock.Setup(x =>
                x.AddAsync(It.IsAny<Domain.AggregateModels.ProductAggregate.Product>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        _productRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        // Act
        var result = await _commandHandler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.StatusCode);
        Assert.True(result.Data.Result);
    }

}