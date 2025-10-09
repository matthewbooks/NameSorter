// See https://aka.ms/new-console-template for more information

using NameSorter;

IFileReader fileReader;
IStringParser stringParser;

var argsCount = args.Length;
if (argsCount == 1)
{
    //TODO: Move instantiation into IoC container
    fileReader = new FileReader();
    var fileContents = fileReader.ReadAllLines(args[0]);

    if (fileContents == null)
    {
        Console.WriteLine("Invalid file path provided");
        Environment.Exit(1);
    }
    
    stringParser = new StringParser();
    var namesList = new List<string>();
    foreach (var fileLine in fileContents)
    {
        var parsedName = stringParser.ParsePersonFromString(fileLine);
        if(parsedName != null) namesList.Add(parsedName.ToString());
    }
    
    foreach (var name in namesList)
    {
        Console.WriteLine(name);
    }
}
else
{
    Console.WriteLine($"Incorrect number of command line arguments ({argsCount}) provided");
}