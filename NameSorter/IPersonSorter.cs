namespace NameSorter;

public interface IPersonSorter
{
    IEnumerable<Person> Sort(IEnumerable<Person> people);
}