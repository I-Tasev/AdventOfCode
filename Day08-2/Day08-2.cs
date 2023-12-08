using System.Text.RegularExpressions;

Console.WriteLine("Please enter game input with last line \"end\" press Enter!");

List<String> input = new List<string>();
var oneLineInput = Console.ReadLine();

while (oneLineInput != "end")
{
    input.Add(oneLineInput);
    oneLineInput = Console.ReadLine();
}

var instructions = input[0];

var allElements = new Dictionary<string, string[]>();

var regexAZ = new Regex(@"[A-Z\d]+");

for (int i = 2; i < input.Count; i++)
{
    var matches = regexAZ.Matches(input[i]);
    allElements.Add(matches[0].Value, new string[] { matches[1].Value, matches[2].Value });
}

var counter = 0;
var currentElements = allElements.Select(e => e.Key).Where(e => e.LastOrDefault() == 'A').ToList();

//how many steps are neede to find each element
var stepsForElements = new List<int>();

while (currentElements.Any())
{
    foreach (var instruction in instructions)
    {
        counter++;
        var elementsToRemove = new List<string>();
        for (int i = 0; i < currentElements.Count; i++)
        {
            if (instruction == 'L')
            {
                currentElements[i] = allElements[currentElements[i]][0];
            }
            else if (instruction == 'R')
            {
                currentElements[i] = allElements[currentElements[i]][1];
            }
            else
            {
                break;
            }
            if (currentElements[i].LastOrDefault() == 'Z')
            {
                stepsForElements.Add(counter);
                elementsToRemove.Add(currentElements[i]);
            }
        }

        foreach (var element in elementsToRemove)
        {
            currentElements.Remove(element);
        }

        if (!currentElements.Any())
        {
            break;
        }
    }
}

var longStepsArray = stepsForElements.Select(e => (long)e).ToArray();

Console.WriteLine("Steps:");
Console.WriteLine(LCM(longStepsArray));

//Calculate the greatest common divisor
static long gcd(long n1, long n2)
{
    if (n2 == 0)
    {
        return n1;
    }
    else
    {
        return gcd(n2, n1 % n2);
    }
}

//The Least Common Multiple 
static long LCM(long[] numbers)
{
    return numbers.Aggregate((S, val) => S * val / gcd(S, val));
}