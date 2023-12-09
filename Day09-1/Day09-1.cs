Console.WriteLine("Please enter game input and press Enter!");

List<String> input = new List<string>();
var oneLineInput = Console.ReadLine();

while (oneLineInput != string.Empty)
{
    input.Add(oneLineInput);
    oneLineInput = Console.ReadLine();
}

var sum = 0;

foreach (var history in input)
{
    var historyValues = history.Split().Select(n => int.Parse(n)).ToList();
    var historyPyramid = new List<List<int>>();
    historyPyramid.Add(historyValues);

    var currentLine = historyValues;

    while (!currentLine.All(n => n == 0))
    {
        var nextLine = new List<int>();

        for (int i = 0; i < currentLine.Count - 1; i++)
        {
            nextLine.Add(currentLine[i+1] - currentLine[i]);
        }

        currentLine = nextLine;

        historyPyramid.Add(currentLine);
    }

    foreach (var line in historyPyramid)
    {
        var lineString = "";
        foreach (var num in line)
        {
           lineString += $"{num} ";
        }
        Console.WriteLine(lineString);              
    }
    var newValue = historyPyramid.Select(x => x.LastOrDefault()).Sum();
    Console.WriteLine(newValue);
    sum+= newValue;
}

Console.WriteLine("---------");
Console.WriteLine("---------");
Console.WriteLine(sum);
