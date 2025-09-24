namespace NameSorter;

public interface IFileReader
{
    string[]? ReadAllLines(string path);
}