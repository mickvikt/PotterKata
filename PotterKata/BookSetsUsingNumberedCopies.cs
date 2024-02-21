namespace PotterKata;

public class BookSetsUsingNumberedCopies : BookSetsSelector
{
    public override IEnumerable<IEnumerable<string>> Get(
        Dictionary<string, IEnumerable<string>> booksByTitle)
    {
        var bookCopies = booksByTitle.Keys
            .SelectMany(key => booksByTitle[key].Select((book, index) => new
            {
                CopieNumber = index + 1,
                Book = book
            }))
            .ToList();

        var maxNumberOfCopies = bookCopies
            .Max(book => book.CopieNumber);
        
        var bookSets = Enumerable.Range(1, maxNumberOfCopies)
            .Reverse()
            .Aggregate(
                Enumerable.Empty<IEnumerable<string>>(),
                (acc, numberOfCopies) =>
                    acc.Append(bookCopies
                        .Where(book => book.CopieNumber == numberOfCopies)
                        .Select(book => book.Book)));
        
        return bookSets;
    }
}