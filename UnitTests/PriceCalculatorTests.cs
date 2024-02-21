using FluentAssertions;
using PotterKata;

namespace UnitTests;

public class PriceCalculatorTests
{
    [Fact]
    public void GivenOneBookShouldReturnPriceForOneBook()
    {
        var books = new[] { "1" };
        var totalPrice = PriceCalculator.Calculate(books, new BookSetsUsingQueues());
        
        totalPrice.Should().Be(10);
    }
    
    [Theory]
    [InlineData(new[] { "1", "1" }, 20)]
    public void GivenMultipleCopiesOfTheSameBookShouldApplyNoDiscount(string[] books, decimal expectedPrice)
    {
        var totalPrice = PriceCalculator.Calculate(books, new BookSetsUsingQueues());
        
        totalPrice.Should().Be(expectedPrice);
    }

    [Theory]
    [InlineData(new[] { "1", "2", "3", "4" }, 34)]
    [InlineData(new[] { "1", "1", "2" }, 29)]
    [InlineData(new[] { "1", "1", "1", "2", "2", "3" }, 56)]
    public void GivenMixedBooksShouldApplyDiscount(string[] books, decimal expectedPrice)
    {
        var totalPrice = PriceCalculator.Calculate(books, new BookSetsUsingQueues());
        
        totalPrice.Should().Be(expectedPrice);
    }
}