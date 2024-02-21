namespace PotterKata;

public abstract class BookSetsSelector
{
    public abstract IEnumerable<IEnumerable<string>> Get(Dictionary<string, IEnumerable<string>> booksByTitle);
}