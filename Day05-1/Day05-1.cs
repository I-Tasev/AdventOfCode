using System.Numerics;

Console.WriteLine("Please enter game input with last line \"end\" press Enter!");

List<String> input = new List<string>();
var oneLineInput = Console.ReadLine();

while (oneLineInput != "end")
{
    input.Add(oneLineInput);
    oneLineInput = Console.ReadLine();
}

var seeds = new List<BigInteger>();

seeds = input[0].Split(':').LastOrDefault().Trim().
    Split(" ", StringSplitOptions.RemoveEmptyEntries).
    Select(s => BigInteger.Parse(s)).ToList();

var seedSoilStartIndex = input.IndexOf("seed-to-soil map:");
var soilFertStartIndex = input.IndexOf("soil-to-fertilizer map:");
var fertWaterStartIndex = input.IndexOf("fertilizer-to-water map:");
var waterLightStartIndex = input.IndexOf("water-to-light map:");
var lightTempStartIndex = input.IndexOf("light-to-temperature map:");
var tempHumidityStartIndex = input.IndexOf("temperature-to-humidity map:");
var humidityLocationStartIndex = input.IndexOf("humidity-to-location map:");

var seedSoilMaps = new List<Map>();
var soilFertMaps = new List<Map>();
var fertWaterMaps = new List<Map>();
var waterLightMaps = new List<Map>();
var lightTempMaps = new List<Map>();
var tempHumidityMaps = new List<Map>();
var humidityLocationMaps = new List<Map>();

ReadMaps(input, seedSoilStartIndex, soilFertStartIndex - 1, seedSoilMaps);
var soils = seeds.Select(s => ConverFromTo(s, seedSoilMaps)).ToList();

ReadMaps(input, soilFertStartIndex, fertWaterStartIndex - 1, soilFertMaps);
var fertalizers = soils.Select(f => ConverFromTo(f, soilFertMaps)).ToList();

ReadMaps(input, fertWaterStartIndex, waterLightStartIndex - 1, fertWaterMaps);
var waters = fertalizers.Select(w => ConverFromTo(w, fertWaterMaps)).ToList();

ReadMaps(input, waterLightStartIndex, lightTempStartIndex - 1, waterLightMaps);
var lights = waters.Select(l => ConverFromTo(l, waterLightMaps)).ToList();

ReadMaps(input, lightTempStartIndex, tempHumidityStartIndex - 1, lightTempMaps);
var temps = lights.Select(t => ConverFromTo(t, lightTempMaps)).ToList();

ReadMaps(input, tempHumidityStartIndex, humidityLocationStartIndex - 1, tempHumidityMaps);
var humidities = temps.Select(t => ConverFromTo(t, tempHumidityMaps)).ToList();

ReadMaps(input, humidityLocationStartIndex, input.Count - 1, humidityLocationMaps);
var locations = humidities.Select(h => ConverFromTo(h, humidityLocationMaps)).ToList();

var minLocation = locations.Min();
Console.WriteLine(minLocation);

static void ReadMaps(List<string> input, int StartIndex, int EndIndex, List<Map> Maps)
{
    for (int i = StartIndex + 1; i < EndIndex; i++)
    {
        var mapLine = input[i].Split().Select(n => BigInteger.Parse(n)).ToList();
        BigInteger from = mapLine[1];
        BigInteger to = mapLine[0];
        BigInteger timesToRepeat = mapLine[2];
        BigInteger difference = from - to;

        Maps.Add(new Map(from, from + timesToRepeat, difference));
    }
}

static BigInteger ConverFromTo(BigInteger value, List<Map> Maps)
{
    foreach (var map in Maps)
    {
        if (value >= map.StartValue && value <= map.EndValue)
        {
            return value - map.Difference;
        }
    }
    return value;
}

public class Map
{
    public Map(BigInteger startValue, BigInteger endValue, BigInteger difference)
    {
        StartValue = startValue;
        EndValue = endValue;
        Difference = difference;
    }

    public BigInteger StartValue { get; set; }
    public BigInteger EndValue { get; set; }
    public BigInteger Difference { get; set; }
}