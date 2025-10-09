namespace NameSorter;

public class FileContentParser(IStringParser stringParser) : IFileContentParser
{
    IStringParser _stringParser = stringParser;

    public List<Person> ParseContent(string[] fileContents)
    {
        var people = new List<Person>();
        foreach (var line in fileContents)
        {
            var person = _stringParser.ParsePersonFromString(line);
            if(person != null) people.Add(person);
        }
        return people;
    }
}