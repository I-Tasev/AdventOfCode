Console.WriteLine("Please enter game input with last line \"end\" press Enter!");

List<String> input = new List<string>();
var oneLineInput = Console.ReadLine();

while (oneLineInput == "end")
{
    input.Add(oneLineInput);
    oneLineInput = Console.ReadLine();
}