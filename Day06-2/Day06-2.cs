using System.Numerics;

Console.WriteLine("Please enter game input and press Enter!");

List<String> input = new List<string>();
var oneLineInput = Console.ReadLine();

while (oneLineInput != string.Empty)
{
    input.Add(oneLineInput);
    oneLineInput = Console.ReadLine();
}

var timeInput = input.FirstOrDefault()
                .Split(":", StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
var distanceInput = input.LastOrDefault()
                    .Split(":", StringSplitOptions.RemoveEmptyEntries).LastOrDefault();

var times = timeInput.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
var distances = distanceInput.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

var time = int.Parse(String.Concat(times));
var recordDistance = BigInteger.Parse(String.Concat(distances));

var race = new Race(time, recordDistance);


for (int i = 1; i < race.Time; i++)
{
    var speed = i;
    var travelTime = race.Time - i;
    BigInteger traveledDistance = (BigInteger)speed * (BigInteger)travelTime;

    if (traveledDistance > race.RecordDistance)
    {
        race.WaysToWin += 1;
    }
}


Console.WriteLine(race.WaysToWin);
public class Race
{
    public Race(int time, BigInteger recordDistance)
    {
        Time = time;
        RecordDistance = recordDistance;
        WaysToWin = 0;
    }

    public int Time { get; set; }
    public BigInteger RecordDistance { get; set; }

    public int WaysToWin { get; set; }

}