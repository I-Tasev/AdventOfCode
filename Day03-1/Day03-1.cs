using System.Text.RegularExpressions;

Console.WriteLine("Please enter game input and press Enter!");

List<String> input = new List<string>();
var oneLineInput = Console.ReadLine();

while (oneLineInput != string.Empty)
{
    input.Add(oneLineInput);
    oneLineInput = Console.ReadLine();
}

var regexNumbers = new Regex(@"\d+");
var regexSymbols = new Regex(@"[^\d.]", RegexOptions.Compiled);

var symbows = new List<Symbol>();
var numbers = new List<Number>();
var partsSum = 0;

for (int i = 0; i < input.Count; i++)
{
    var symbolMatches = regexSymbols.Matches(input[i]);
    if (symbolMatches.Any())
    {
        List<int> colums = new List<int>();
        for (int j = 0; j < symbolMatches.Count; j++)
        {
            colums.Add(symbolMatches[j].Index);
            colums.Add(symbolMatches[j].Index - 1);
            colums.Add(symbolMatches[j].Index + 1);
        }
        symbows.Add(new Symbol(i, colums));
    }

    var numberMatches = regexNumbers.Matches(input[i]);
    if (numberMatches.Any())
    {
        for (int j = 0; j < numberMatches.Count; j++)
        {
            var number = numberMatches[j];
            var numberToAdd = new Number(int.Parse(number.Value), i);
            for (int k = number.Index; k < number.Index + number.Length; k++)
            {
                numberToAdd.Columns.Add(k);
            }
            numbers.Add(numberToAdd);
        }
    }
}

foreach (var number in numbers)
{
    Console.WriteLine("----");
    Console.WriteLine(number.Value);
    if (symbows.Where(s => (s.Row == number.Row || s.Row - 1 == number.Row || s.Row + 1 == number.Row)
        && s.Columns.Intersect(number.Columns).Any()).Any())
    {
        partsSum += number.Value;
        Console.WriteLine("Added");
    }
    else
    {
        Console.WriteLine("not added");
    }
    Console.WriteLine("----");
}

Console.WriteLine(partsSum);


public class Number
{
    public Number(int value, int row)
    {
        Value = value;
        Row = row;
        Columns = new List<int>();
    }

    public int Value { get; set; }
    public int Row { get; set; }
    public List<int> Columns { get; set; }
}

public class Symbol
{
    public Symbol(int row, List<int> columns)
    {
        Row = row;
        Columns = columns;
    }

    public int Row { get; set; }
    public List<int> Columns { get; set; }

}