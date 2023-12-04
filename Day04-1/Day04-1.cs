Console.WriteLine("Please enter game input and press Enter!");

List<String> input = new List<string>();
var oneLineInput = Console.ReadLine();

while (oneLineInput != string.Empty)
{
    input.Add(oneLineInput);
    oneLineInput = Console.ReadLine();
}

var totalPoints = 0;

foreach (var line in input)
{
    var cardID = line.Split(':').FirstOrDefault();
    var allNumbers = line.Split(":").LastOrDefault();
    var winningNumbers = allNumbers.Split('|').FirstOrDefault().Trim();
    var numbers = allNumbers.Split('|').LastOrDefault().Trim();
    var winningNumbersList = winningNumbers.Split(" ", System.StringSplitOptions.RemoveEmptyEntries).ToList();
    var numbersList = numbers.Split(" ", System.StringSplitOptions.RemoveEmptyEntries).ToList();
    var cardPoits = 0;

    foreach (var winNumber in winningNumbersList)
    {
        if (numbersList.Contains(winNumber))
        {
            if (cardPoits == 0)
            {
                cardPoits = 1;
            }
            else
            {
                cardPoits *= 2;
            }
        }
    }
    totalPoints += cardPoits;
    Console.WriteLine($"{cardID} --- {cardPoits}");
}

Console.WriteLine(totalPoints);