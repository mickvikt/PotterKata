namespace PotterKata;

public static class PriceCalculator
{
    public static object Calculate(
        string[] books,
        BookSetsSelector bookSetsSelector)
    {
        var booksByTitle = books
            .GroupBy(b => b)
            .ToDictionary(b => b.Key, b => b.AsEnumerable());

        var bookSets = bookSetsSelector.Get(booksByTitle);

        return bookSets.Sum(CalculateSetPrice);
    }

    private static decimal CalculateSetPrice(IEnumerable<string> bookSet)
    {
        var setPrice = 0m;
        var currentDiscountFactor = 1m;
        for (var i = 1; i <= bookSet.Count(); i++)
        {
            setPrice = i * 10 * currentDiscountFactor;
            currentDiscountFactor -= 0.05m;
        }

        return setPrice;
    }
}