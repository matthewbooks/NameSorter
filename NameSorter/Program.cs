// See https://aka.ms/new-console-template for more information

using System.Collections;
using NameSorter;

IFileReader fileReader;
IStringParser stringParser;
IFileContentParser fileContentParser;

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
    fileContentParser = new FileContentParser(stringParser);
    var people = fileContentParser.ParseContent(fileContents);

    foreach (var person in people)
    {
        Console.WriteLine(person.ToString());
    }
}
else
{
    Console.WriteLine($"Incorrect number of command line arguments ({argsCount}) provided");
}