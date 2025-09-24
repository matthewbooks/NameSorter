namespace NameSorter;

public class FileReader : IFileReader
{
    public string[]? ReadAllLines(string path)
    {
        try
        {
            return File.ReadAllLines(path);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
}