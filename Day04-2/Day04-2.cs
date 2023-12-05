
Console.WriteLine("Please enter game input and press Enter!");

List<String> input = new List<string>();
var oneLineInput = Console.ReadLine();

while (oneLineInput != string.Empty)
{
    input.Add(oneLineInput);
    oneLineInput = Console.ReadLine();
}

var cards = new List<Card>();

foreach (var line in input)
{
    var cardID = line.Split(':').FirstOrDefault();
    var allNumbers = line.Split(":").LastOrDefault();
    var winningNumbers = allNumbers.Split('|').FirstOrDefault().Trim();
    var numbers = allNumbers.Split('|').LastOrDefault().Trim();
    var winningNumbersList = winningNumbers.Split(" ", System.StringSplitOptions.RemoveEmptyEntries).ToList();
    var numbersList = numbers.Split(" ", System.StringSplitOptions.RemoveEmptyEntries).ToList();
    var mathcingNumbers = 0;

    foreach (var winNumber in winningNumbersList)
    {
        if (numbersList.Contains(winNumber))
        {
            mathcingNumbers += 1;
        }
    }

    cards.Add(new Card(cardID, mathcingNumbers));
}

for (int i = 0; i < cards.Count; i++)
{
    var currentCard = cards[i];
    if (currentCard.MatchingNumbers != 0)
    {
        for (int j = i + 1; j <= currentCard.MatchingNumbers + i; j++)
        {
            if (j < cards.Count)
            {
                cards[j].Copies += currentCard.Copies;
            }
        }
    }
}

foreach (var card in cards)
{
    Console.WriteLine($"{card.Id} -- Matching: {card.MatchingNumbers} -- Copies: {card.Copies}");
    Console.WriteLine($"Total cards = {cards.Sum(c => c.Copies)}");
}

public class Card
{
    public Card(string id, int matchingNumbers)
    {
        Id = id;
        MatchingNumbers = matchingNumbers;
        Copies = 1;
    }

    public string Id { get; set; }
    public int MatchingNumbers { get; set; }
    public int Copies { get; set; }

}