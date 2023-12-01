using System.Text.RegularExpressions;
using System.Threading;

Console.WriteLine("Please enter calibration document!");

List<String> input = new List<string>();

var oneLineInput = Console.ReadLine();

while (oneLineInput != string.Empty)
{
    input.Add(oneLineInput);
    oneLineInput = Console.ReadLine();
}

var calibrationSum = 0;
var wordsToFind = new List<string>() { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

foreach (var line in input)
{
    var firstNumberChar = 'x';
    var lastNumberChar = 'x';
    var minIndex = line.Length;
    var maxIndex = 0;

    IEnumerable<char> stringQuery =
         from ch in line
         where Char.IsDigit(ch)
         select ch;

    if (stringQuery.Count() >= 1)
    {
        firstNumberChar = (char)stringQuery.FirstOrDefault();
        lastNumberChar = (char)stringQuery.LastOrDefault();

        minIndex = line.IndexOf(firstNumberChar);
        maxIndex = line.LastIndexOf(lastNumberChar);
    }

    foreach (var word in wordsToFind)
    {
        var firstIndexCurrent = line.IndexOf(word);
        if (firstIndexCurrent == -1)
        {
            continue;
        }
        var lastIndexCurrent = line.LastIndexOf(word);

        if (minIndex > firstIndexCurrent)
        {
            minIndex = firstIndexCurrent;
            firstNumberChar = WordsToChar.ConvertToChar(word);
        }

        if (maxIndex < lastIndexCurrent)
        {
            maxIndex = lastIndexCurrent;
            lastNumberChar = WordsToChar.ConvertToChar(word);
        }
    }

    char[] chars = { firstNumberChar, lastNumberChar };
    var calibrationValueString = new string(chars);
    var calibrationValue = int.Parse(calibrationValueString);
    calibrationSum += calibrationValue;
    Console.WriteLine($"{line} -- {calibrationValueString} - {calibrationValue}");
}

Console.WriteLine(calibrationSum);


class WordsToChar
{
    private static Dictionary<string, char> numberTable = new Dictionary<string, char>{
        {"one",'1'},{"two",'2'},{"three",'3'},{"four",'4'},{"five",'5'},{"six",'6'},
        {"seven",'7'},{"eight",'8'},{"nine",'9'}
    };

    public static char ConvertToChar(string numberString)
    {
        var numbers = Regex.Matches(numberString, @"\w+").Cast<Match>()
                .Select(m => m.Value.ToLowerInvariant())
                .Where(v => numberTable.ContainsKey(v))
                .Select(v => numberTable[v]);

        return numbers.FirstOrDefault();
    }
}