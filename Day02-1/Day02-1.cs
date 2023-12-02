Console.WriteLine("Please enter game input and press Enter!");

List<String> input = new List<string>();
var oneLineInput = Console.ReadLine();

while (oneLineInput != string.Empty)
{
    input.Add(oneLineInput);
    oneLineInput = Console.ReadLine();
}

var redLimit = 12;
var greenLimit = 13;
var blueLimit = 14;
var gameSum = 0;

foreach (var line in input)
{
    var gameIDString = line.Split(':')[0];
    var setOfCubes = line.Split(':')[1];
    var gameID = int.Parse(gameIDString.Split()[1]);
    var subsetCubes = setOfCubes.Split(';');
    var gameIsPossible = true;

    foreach (var subSet in subsetCubes)
    {
        var cubes = subSet.Split(",");
        var redSum = 0;
        var greenSum = 0;
        var blueSum = 0;

        foreach (var cube in cubes)
        {
            var number = int.Parse(cube.Trim().Split()[0]);
            var color = cube.Trim().Split()[1];
            switch (color)
            {
                case "red":
                    redSum += number;
                    break;
                case "green":
                    greenSum += number;
                    break;
                case "blue":
                    blueSum += number;
                    break;
                default:
                    break;
            }
        }

        if (!(redSum <= redLimit && greenSum <= greenLimit && blueSum <= blueLimit))
        {
            gameIsPossible= false;
        }
    }

    if (gameIsPossible)
    {
        gameSum += gameID;
    }   
       
}
Console.WriteLine();
Console.WriteLine("GameSum");
Console.WriteLine(gameSum);