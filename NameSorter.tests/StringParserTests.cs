using NUnit.Framework;

namespace NameSorter.tests;

[TestFixture]
public class StringParserTests
{
    private StringParser _parser;

    [SetUp]
    public void Setup()
    {
        _parser = new StringParser();
    }

    [TestCase("")]
    [TestCase(" ")]
    public void ItShouldReturnNullForAnEmptyStringInput(string input)
    {
        var result = _parser.ParsePersonFromString(input);
        
        Assert.That(result, Is.Null);
    }

    [TestCase(" John Smith", "John", "Smith")]
    [TestCase("John Smith ", "John", "Smith")]
    [TestCase(" John Smith ", "John", "Smith")]
    public void ItShouldIgnoreBeginningAndTrailingSpaces(string input, string expectedFirstName, string expectedLastName)
    {
        var result = _parser.ParsePersonFromString(input);
        
        Assert.That(result?.GivenNames == expectedFirstName);
        Assert.That(result?.LastName == expectedLastName);
    }
    
    [Test]
    public void ItShouldParseAFirstNameOnlyString()
    {
        var name = "Prince";
        var result = _parser.ParsePersonFromString(name);
        
        Assert.That(result?.GivenNames == name);
        Assert.That(result?.LastName == string.Empty);
    }
    
    [TestCase("John Smith", "John", "Smith")]
    public void ItShouldParseASingleFirstNameAndSurname(string input, string expectedFirstName, string expectedSurname)
    {
        var result = _parser.ParsePersonFromString(input);
        
        Assert.That(result?.GivenNames == expectedFirstName);
        Assert.That(result?.LastName == expectedSurname);
    }

    [TestCase("John Stanley Smith", "John Stanley", "Smith")]
    [TestCase("John Stanley Bradley Smith", "John Stanley Bradley", "Smith")]
    public void ItShouldParseMultipleGivenNamesAndASurname(string input, string expectedFirstNames, string expectedSurname)
    {
        var result = _parser.ParsePersonFromString(input);
        
        Assert.That(result?.GivenNames == expectedFirstNames);
        Assert.That(result?.LastName == expectedSurname);
    }
}