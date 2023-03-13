using APP.Domain;
using APP.Services;
using APP.Services.Contracts;
using APP.Settings;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace APP.Tests.Services;

public class BasketItemServiceTests
{
    private readonly IBasketItemService _service;
    
    public BasketItemServiceTests()
    {
        var contextMock = new Mock<ApplicationContext>(new DbContextOptionsBuilder().Options, It.IsAny<AppSettings>());
        _service = new BasketItemService(contextMock.Object);
    }

    [Theory]
    [InlineData(1, 1, 0.1, 2, 1)]
    [InlineData(1, 1, 0.1, 1, 0.9)]
    [InlineData(1, 1, 0, 0, 1)]
    public void SimpleGetDiscountTests(decimal itemPrice, int itemQuantity, decimal discountPercentage, 
        int requiredAmount, decimal expectedResult)
    {
        //Arrange
        var basket = new Basket
        {
            Id = Guid.NewGuid(),
            Items = new List<BasketItem>()
        };
        
        var basketItem = new BasketItem
        {
            Id = Guid.NewGuid(),
            Basket = basket,
            Item = new Item
            {
                Id = Guid.NewGuid(),
                Name = "Apple",
                Price = itemPrice
            },
            Quantity = itemQuantity
        };

        basket.Items.Add(basketItem);

        if (discountPercentage > 0 && requiredAmount > 0)
        {
            var specialOffer = new SpecialOffer
            {
                Id = Guid.NewGuid(),
                Item = basketItem.Item,
                Description = "Apples have 10% off their normal price this week",
                Percentage = discountPercentage,
                ItemId = basketItem.Item.Id,
                RequiredAmount = requiredAmount
            };

            basketItem.Item.SpecialOffer = specialOffer;
        }

        
        
        //Act
        var actualResult = _service.GetDiscount(basketItem);

        //Assert
        Assert.Equal(expectedResult, actualResult);
    }


    [Theory]
    [InlineData(1, 2d, 0.5, 2, 0.5)]
    public void ComplexGetDiscountTests(decimal itemPrice, int itemQuantity, decimal discountPercentage,
        int requiredAmount, decimal expectedResult)
    {
        //Arrange
        var basket = new Basket
        {
            Id = Guid.NewGuid(),
            Items = new List<BasketItem>()
        };

        var discountItem = new Item
        {
            Id = Guid.NewGuid(),
            Name = "Soup",
            Price = 1
        };
        
        var soup = new BasketItem
        {
            Id = Guid.NewGuid(),
            Basket = basket,
            Item = discountItem,
            Quantity = itemQuantity
        };
        
        var bread = new BasketItem
        {
            Id = Guid.NewGuid(),
            Basket = basket,
            Item = new Item
            {
                Id = Guid.NewGuid(),
                Name = "Bread",
                Price = itemPrice
            },
            Quantity = itemQuantity
        };

        basket.Items.Add(soup);
        basket.Items.Add(bread);

        if (discountPercentage > 0 && requiredAmount > 0)
        {
            var specialOffer = new SpecialOffer
            {
                Id = Guid.NewGuid(),
                Item = soup.Item,
                Description = "Buy 2 tins of soup and get a loaf of bread for half price",
                Percentage = discountPercentage,
                ItemId = soup.Item.Id,
                RequiredAmount = requiredAmount,
                DiscountItem = bread.Item,
                DiscountItemId = discountItem.Id
            };

            soup.Item.SpecialOffer = specialOffer;
        }
        
        //Act
        var actualResult = _service.GetDiscount(bread);
        
        //Assert
        Assert.Equal(expectedResult, actualResult);
    }
}