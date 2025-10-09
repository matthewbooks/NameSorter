namespace NameSorter;

public interface IFileContentParser
{
    List<Person> ParseContent(string[] fileContents);
}