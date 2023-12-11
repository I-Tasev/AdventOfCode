using System.Data.Common;

Console.WriteLine("Please enter game input and press Enter!");

var map = new List<List<char>>();
var oneLineInput = Console.ReadLine();

var startPosition = new int[2]; //row;column

while (oneLineInput != string.Empty)
{
    var currentLine = oneLineInput.ToCharArray().ToList();
    map.Add(currentLine);
    if (currentLine.Contains('S'))
    {
        startPosition[0] = map.Count - 1; //add row index
        startPosition[1] = currentLine.IndexOf('S'); //add column index
    }
    oneLineInput = Console.ReadLine();
}

var currentPostion = FirstNextPosition(startPosition, map);
var previousPosition = startPosition;
var stepCount = 1;

while (map[currentPostion[0]][currentPostion[1]] != 'S')
{
    var nextPostion = NextPosition(currentPostion, previousPosition, map);
    map[currentPostion[0]][currentPostion[1]] = 'O';
    previousPosition = currentPostion;
    currentPostion = nextPostion;
    stepCount++; 
}

//Print map
foreach (var row in map)
{
    Console.WriteLine(new string(row.ToArray()));
}

Console.WriteLine();
Console.WriteLine();
Console.WriteLine("*****************************************");
Console.WriteLine("FINAL STEPS:");
Console.WriteLine(stepCount / 2);

static int[] NextPosition(int[] currentPosition, int[] previousPosition, List<List<char>> map)
{
    var currentChar = map[currentPosition[0]][currentPosition[1]];
    int[] nextPosition = new int[2] {currentPosition[0], currentPosition[1]};

    if (currentChar == '|')
    {
        if (previousPosition[0] > currentPosition[0]) //current is above previous
        {
            nextPosition[0] -= 1;
            return nextPosition;
        }
        else
        {
            nextPosition[0] += 1;
            return nextPosition;
        }
    }
    else if (currentChar == '-')
    {
        if (previousPosition[1] > currentPosition[1]) //current is left of previous
        {
            nextPosition[1] -= 1;
            return nextPosition;
        }
        else
        {
            nextPosition[1] += 1;
            return nextPosition;
        }
    }
    else if (currentChar == 'L')
    {
        if (previousPosition[1] > currentPosition[1]) //current is left of previous
        {
            nextPosition[0] -= 1;
            return nextPosition;
        }
        else
        {
            nextPosition[1] += 1;
            return nextPosition;
        }
    }
    else if (currentChar == 'F')
    {
        if (previousPosition[1] > currentPosition[1]) //current is left of previous
        {
            nextPosition[0] += 1;
            return nextPosition;
        }
        else
        {
            nextPosition[1] += 1;
            return nextPosition;
        }
    }
    else if (currentChar == '7')
    {
        if (previousPosition[1] < currentPosition[1]) //current is right of previous
        {
            nextPosition[0] += 1;
            return nextPosition;
        }
        else
        {
            nextPosition[1] -= 1;
            return nextPosition;
        }
    }
    else if (currentChar == 'J')
    {
        if (previousPosition[1] < currentPosition[1]) //current is right of previous
        {
            nextPosition[0] -= 1;
            return nextPosition;
        }
        else
        {
            nextPosition[1] -= 1;
            return nextPosition;
        }
    }
    
    return currentPosition;// if no adjacent pipe has been found 
}

static int[] FirstNextPosition(int[] currentPosition, List<List<char>> map)
{
    var isTopRow = currentPosition[0] == 0;
    var isFirstColumn = currentPosition[1] == 0;
    var islastRow = currentPosition[0] == map.Count - 1;
    var isLastColumn = currentPosition[1] == map[currentPosition[0]].Count - 1;
    int[] nextPosition = new int[2] { currentPosition[0], currentPosition[1] };

    if (!islastRow && DownIsPipe(currentPosition, map))
    {
        nextPosition[0] += 1;
        return nextPosition;
    }

    if (!isTopRow && TopIsPipe(currentPosition, map))
    {
        nextPosition[0] -= 1;
        return nextPosition;
    }

    if (!isLastColumn && RightIsPipe(currentPosition, map))
    {
        nextPosition[1] += 1;
        return nextPosition;
    }

    if (!isFirstColumn && LeftIsPipe(currentPosition, map))
    {
        nextPosition[1] -= 1;
        return nextPosition;
    }
    
    return currentPosition;// if no adjacent pipe has been found 
}

static bool TopIsPipe(int[] position, List<List<char>> map)
{
    var topRow = position[0] - 1;
    var column = position[1];
    var topChar = map[topRow][column];
    if (topChar == 'F' || topChar == '7' || topChar == '|')
    {
        return true;
    }
    return false;
}

static bool RightIsPipe(int[] position, List<List<char>> map)
{
    var row = position[0];
    var rightColumn = position[1] + 1;
    var rightChar = map[row][rightColumn];
    if (rightChar == 'J' || rightChar == '7' || rightChar == '-')
    {
        return true;
    }
    return false;
}

static bool DownIsPipe(int[] position, List<List<char>> map)
{
    var downRow = position[0] + 1;
    var column = position[1]; ;
    var downChar = map[downRow][column];
    if (downChar == 'L' || downChar == 'J' || downChar == '|')
    {
        return true;
    }
    return false;
}

static bool LeftIsPipe(int[] position, List<List<char>> map)
{
    var row = position[0];
    var leftColumn = position[1] - 1;
    var leftChar = map[row][leftColumn];
    if (leftChar == 'F' || leftChar == 'L' || leftChar == '-')
    {
        return true;
    }
    return false;
}


