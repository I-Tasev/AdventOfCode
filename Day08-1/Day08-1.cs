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

var elements = new Dictionary<string, string[]>();

var regexAZ = new Regex(@"[A-Z]+");

for (int i = 2; i < input.Count; i++)
{
    var matches = regexAZ.Matches(input[i]);
    elements.Add(matches[0].Value, new string[] { matches[1].Value, matches[2].Value });
}

var counter = 0;
var element = "AAA";
while (element != "ZZZ")
{    
    foreach (var instruction in instructions)
    {
        counter++;
        if (instruction == 'L')
        {
            element = elements[element][0];
        }
        else if (instruction == 'R')
        {
            element = elements[element][1];
        }
        else
        {
            break;
        }
        if (element == "AAA")
        {
            break;
        }
    }    
}

Console.WriteLine("Steps:");
Console.WriteLine(counter);

