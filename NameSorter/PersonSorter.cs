namespace NameSorter;

public class PersonSorter : IPersonSorter
{
    public IEnumerable<Person> Sort(IEnumerable<Person> people)
    {
        return people.OrderBy(p => p.GivenNames)
                    .ThenBy(p => p.LastName)
                    .ToList();
    }
}