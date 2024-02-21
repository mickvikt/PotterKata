using FluentAssertions;
using PotterKata;

namespace UnitTests;

public class BookSetsUsingQueuesTests
{
    private readonly BookSetsUsingQueues _bookSetsUsingQueues= new ();
    
    [Theory]
    [MemberData(nameof(GetTestData))]
    public void GivenBooksByTitleShouldPutOnlyDifferentBooksToTheSameSet(
        Dictionary<string, IEnumerable<string>> booksByTitle,
        IEnumerable<IEnumerable<string>> expectedSets)
    {
        var actualBookSets = _bookSetsUsingQueues.Get(booksByTitle);
        
        actualBookSets.Should().BeEquivalentTo(expectedSets);
    }

    public static IEnumerable<object[]> GetTestData()
    {
        yield return new object[]
        {
            new Dictionary<string, IEnumerable<string>>
            {
                { "1", new[] { "1" } }
            },
            new[] { new[] { "1" } }
        };
        yield return new object[]
        {
            new Dictionary<string, IEnumerable<string>>
            {
                { "1", new[] { "1", "1" } }
            },
            new[] { new[] { "1" }, new[] { "1" } }
        };
        yield return new object[]
        {
            new Dictionary<string, IEnumerable<string>>
            {
                { "1", new[] { "1" } },
                { "2", new[] { "2" } },
                { "3", new[] { "3" } }
            },
            new[] { new[] { "1", "2", "3" } }
        };
        yield return new object[]
        {
            new Dictionary<string, IEnumerable<string>>
            {
                { "1", new[] { "1", "1", "1" } },
                { "2", new[] { "2", "2" } },
                { "3", new[] { "3" } }
            },
            new[] { new[] { "1", "2", "3" }, new[] { "1", "2"}, new[] { "1" } }
        };
    }
}