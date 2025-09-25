namespace NameSorter;

public class StringParser : IStringParser
{
    public Person? ParsePersonFromString(string input)
    {
        var nameParts = input.Split(' ');
        string givenNames;
        var surname = string.Empty;
        
        switch (nameParts.Length)
        {
            case 0:
                return null;
            case 1:
                givenNames = nameParts[0];
                break;
            case 2:
                givenNames = nameParts[0];
                surname = nameParts[1];
                break;
            default:
                givenNames = string.Join(" ", nameParts.Take(nameParts.Length - 1));
                surname = nameParts[^1];
                break;
        }

        return new  Person(givenNames, surname);
    }
}