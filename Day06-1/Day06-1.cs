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

var times = timeInput.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x)).ToList();
var distances = distanceInput.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => int.Parse(x)).ToList();

var races = new List<Race>();

if (times.Count == distances.Count)
{
    for (int i = 0; i < times.Count; i++)
    {
        races.Add(new Race(times[i], distances[i]));
    }
}

var multiply = 1;

foreach (var race in races)
{
    for (int i = 1; i < race.Time; i++)
    {
        var speed = i;
        var travelTime = race.Time - i;
        var traveledDistance = speed * travelTime;

        if (traveledDistance > race.RecordDistance)
        {
            race.WaysToWin += 1;
        }
    }

    if (race.WaysToWin > 0)
    {
        multiply *= race.WaysToWin;
    }
}

Console.WriteLine(multiply);
public class Race
{
    public Race(int time, int recordDistance)
    {
        Time = time;
        RecordDistance = recordDistance;
        WaysToWin = 0;
    }

    public int Time { get; set; }
    public int RecordDistance { get; set; }

    public int WaysToWin { get; set; }

}