namespace PotterKata;

public class BookSetsUsingQueues : BookSetsSelector
{
    public override IEnumerable<IEnumerable<string>> Get(Dictionary<string, IEnumerable<string>> booksByTitle)
    {
        var sets = Enumerable.Empty<IEnumerable<string>>().ToList();
        
        var sameBookQueues = booksByTitle.Keys
            .Select(key => new Queue<string>(booksByTitle[key]))
            .ToArray();
        
        while (sameBookQueues.Any(q => q.Any()))
        {
            var currentSet = Enumerable.Empty<string>().ToList();
            foreach (var queue in sameBookQueues)
            {
                if (queue.Any())
                {
                    currentSet.Add(queue.Dequeue());
                }
            }
            
            sets.Add(currentSet);
        }

        return sets;
    }
}