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
while (!currentElements.All(e => e.LastOrDefault() == 'Z'))
{
    foreach (var instruction in instructions)
    {
        counter++;
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
        }
        if (currentElements.All(e => e.LastOrDefault() == 'Z'))
        {
            break;
        }
    }
}

Console.WriteLine("Steps:");
Console.WriteLine(counter);

