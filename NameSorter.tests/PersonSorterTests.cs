namespace NameSorter.tests;

using NUnit.Framework;

public class PersonSorterTests
{
    private IPersonSorter _personSorter;

    [SetUp]
    public void Setup()
    {
        _personSorter = new PersonSorter();
    }

    [Test]
    public void ItShouldReturnAnEmptyListForAnEmptyInputList()
    {
        var result = _personSorter.Sort(new List<Person>());
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void ItShouldReturnTheSameListForASinglePerson()
    {
        var person = new Person("John", "Doe");
        var result = _personSorter.Sort(new[] { person }).ToList();

        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result[0], Is.EqualTo(person));
    }

    [Test]
    public void ItShouldSortByFirstnameWhereMultiplePeopleHaveTheSameSurname()
    {
        var people = new[]
        {
            new Person("Bob", "Smith"),
            new Person("Alice", "Smith")
        };

        var result = _personSorter.Sort(people).ToList();

        Assert.That(result.Count, Is.EqualTo(2));
        Assert.That(result[0].GivenNames, Is.EqualTo("Alice"));
        Assert.That(result[1].GivenNames, Is.EqualTo("Bob"));
    }

    [Test]
    public void ItShouldSortBySurnameWhereMultiplePeopleHaveTheSameFirstname()
    {
        var people = new[]
        {
            new Person("John", "Smith"),
            new Person("John", "Adams")
        };

        var result = _personSorter.Sort(people).ToList();

        Assert.That(result.Count, Is.EqualTo(2));
        Assert.That(result[0].LastName, Is.EqualTo("Adams"));
        Assert.That(result[1].LastName, Is.EqualTo("Smith"));
    }
}