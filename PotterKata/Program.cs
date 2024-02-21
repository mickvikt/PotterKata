
using PotterKata;

var books = new[] { "1", "1", "1", "2", "2", "3" };
var price = PriceCalculator.Calculate(books, new BookSetsUsingQueues());
Console.WriteLine($"Price for provided books is: {price}");
