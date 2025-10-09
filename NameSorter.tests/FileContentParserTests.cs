using NUnit.Framework;
using Moq;

namespace NameSorter.tests;

[TestFixture]
public class FileContentParserTests
{
    private Mock<IStringParser> _mockStringParser;
    private FileContentParser _parser;

    [SetUp]
    public void Setup()
    {
        _mockStringParser = new Mock<IStringParser>();
        _parser = new FileContentParser(_mockStringParser.Object);
    }

    [Test]
    public void ItShouldReturnAnEmptyListForAnEmptyInputArray()
    {
        var fileContent = Array.Empty<string>();

        var result = _parser.ParseContent(fileContent);

        Assert.That(result, Is.Empty);
    }

    [Test]
    public void ItShouldSkipOverEmptyLinesInInputArray()
    {
        var fileContent = new[] { "John Smith", "", "Jane Doe" };
        var person1 = new Person("John", "Smith");
        var person2 = new Person("Jane", "Doe");
        _mockStringParser.Setup(x => x.ParsePersonFromString("John Smith")).Returns(person1);
        _mockStringParser.Setup(x => x.ParsePersonFromString("Jane Doe")).Returns(person2);

        var result = _parser.ParseContent(fileContent);

        Assert.That(result.Count, Is.EqualTo(2));
        Assert.That(result[0], Is.EqualTo(person1));
        Assert.That(result[1], Is.EqualTo(person2));
    }

    [Test]
    public void ItShouldParseAllLinesInInputArray()
    {
        var fileContent = new[] { "John Smith", "Jane Doe" };
        var person1 = new Person("John", "Smith");
        var person2 = new Person("Jane", "Doe");
        _mockStringParser.Setup(x => x.ParsePersonFromString("John Smith")).Returns(person1);
        _mockStringParser.Setup(x => x.ParsePersonFromString("Jane Doe")).Returns(person2);

        var result = _parser.ParseContent(fileContent);

        Assert.That(result.Count, Is.EqualTo(2));
        Assert.That(result[0], Is.EqualTo(person1));
        Assert.That(result[1], Is.EqualTo(person2));
    }
}