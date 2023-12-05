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
var regexGears = new Regex(@"\*");

var gears = new List<Gear>();
var numbers = new List<Number>();
var partsSum = 0;

for (int i = 0; i < input.Count; i++)
{
    var gearMatches = regexGears.Matches(input[i]);
    if (gearMatches.Any())
    {
        for (int j = 0; j < gearMatches.Count; j++)
        {
            List<int> colums = new List<int>
            {
                gearMatches[j].Index,
                gearMatches[j].Index - 1,
                gearMatches[j].Index + 1
            };
            gears.Add(new Gear(i, colums));
        }

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
    var gearNearNumber = gears.Where(s => (s.Row == number.Row || s.Row - 1 == number.Row || s.Row + 1 == number.Row)
        && s.Columns.Intersect(number.Columns).Any());
    if (gearNearNumber.Any())
    {
        var index = gears.IndexOf(gearNearNumber.FirstOrDefault());
        if (index != -1)
        {
            gears[index].Numbers.Add(number.Value);
            Console.WriteLine("Added");
        }
    }
    else
    {
        Console.WriteLine("not added");
    }
    Console.WriteLine("----");
}

var gearRatiosSum = 0;

var gearsWithTwoNumbers = gears.Where(g => g.Numbers.Count == 2);

foreach (var gear in gearsWithTwoNumbers)
{
    var gearRatio = gear.Numbers[0] * gear.Numbers[1];
    gearRatiosSum += gearRatio;
}

Console.WriteLine(gearRatiosSum);


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

public class Gear
{
    public Gear(int row, List<int> columns)
    {
        Row = row;
        Columns = columns;
        Numbers = new List<int>();
    }

    public int Row { get; set; }
    public List<int> Columns { get; set; }
    public List<int> Numbers { get; set; }




}