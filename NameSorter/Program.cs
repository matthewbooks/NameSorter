// See https://aka.ms/new-console-template for more information

using NameSorter;

IFileReader fileReader;

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
    
    Array.ForEach(fileContents, Console.WriteLine);
}
else
{
    Console.WriteLine($"Incorrect number of command line arguments ({argsCount}) provided");
}