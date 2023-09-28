// See https://aka.ms/new-console-template for more information

using Fraser.VkxData;

Console.WriteLine("Hello, World!");

var reader = new VkxReader("c:\\Temp\\track.vkx");
var counter = 1;

var values = Enum.GetValues(typeof(RowType));
var counts = new Dictionary<RowType, int>();
foreach (var value in values)
{
    counts[(RowType)value] = 0;
}

foreach (var row in reader)
{
    counter++;
    counts[row.Type]++;
    //Console.Write(counter + ": ");
    //Console.WriteLine(row.Type);
    if (counter % 100 == 0 && row.Type == RowType.PositionVelocityOrientation)
    {
        Console.WriteLine(row.ToString());
    }
}

// write out counts of line types
foreach (var count in counts)
{
    Console.WriteLine($"{count.Key}: {count.Value}");
}