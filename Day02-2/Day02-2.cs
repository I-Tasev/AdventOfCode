Console.WriteLine("Please enter game input and press Enter!");

List<String> input = new List<string>();
var oneLineInput = Console.ReadLine();

while (oneLineInput != string.Empty)
{
    input.Add(oneLineInput);
    oneLineInput = Console.ReadLine();
}

var gameSum = 0;

foreach (var line in input)
{
    var gameIDString = line.Split(':')[0];
    var setOfCubes = line.Split(':')[1];
    var gameID = int.Parse(gameIDString.Split()[1]);
    var subsetCubes = setOfCubes.Split(';');

    var redMax = 0;
    var greenMax = 0;
    var blueMax = 0;
    var gamePower = 0;

    foreach (var subSet in subsetCubes)
    {
        var cubes = subSet.Split(",");

        foreach (var cube in cubes)
        {
            var number = int.Parse(cube.Trim().Split()[0]);
            var color = cube.Trim().Split()[1];
            switch (color)
            {
                case "red":
                    if (redMax < number)
                    {
                        redMax = number;
                    };
                    break;
                case "green":
                    if (greenMax < number)
                    {
                        greenMax = number;
                    };
                    break;
                case "blue":
                    if (blueMax < number)
                    {
                        blueMax = number;
                    };
                    break;
                default:
                    break;
            }
        }
    }
    gamePower = redMax * greenMax * blueMax;
    gameSum += gamePower;
}
Console.WriteLine("----------------------");
Console.WriteLine("GameSum");
Console.WriteLine(gameSum);