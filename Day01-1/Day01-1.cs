
Console.WriteLine("Please enter calibration document!");

List<String> input = new List<string>();

var oneLineInput = Console.ReadLine();

while (oneLineInput != string.Empty)
{
    input.Add(oneLineInput);
    oneLineInput = Console.ReadLine();
}

var calibrationSum = 0;

foreach (var line in input)
{
    IEnumerable<char> stringQuery =
         from ch in line
         where Char.IsDigit(ch)
         select ch;
    char[] chars = { (char)stringQuery.FirstOrDefault(), (char)stringQuery.LastOrDefault() };
    var calibrationValueString = new string(chars);
    var calibrationValue = int.Parse(calibrationValueString);
    calibrationSum += calibrationValue;
}

Console.WriteLine(calibrationSum);
