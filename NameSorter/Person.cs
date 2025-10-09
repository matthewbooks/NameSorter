namespace NameSorter;

public class Person(string givenNames, string lastName)
{
    public string GivenNames { get; set; } = givenNames;
    public string LastName { get; set; } = lastName;
    
    public override string ToString() => $"{GivenNames} {LastName}";
}