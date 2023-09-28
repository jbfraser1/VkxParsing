// See https://aka.ms/new-console-template for more information

using Fraser.VkxData;

Console.WriteLine("Hello, World!");

var reader = new VkxReader("c:\\Temp\\track.vkx");
var counter = 1;
foreach (var row in reader)
{
    counter++;
    //Console.Write(counter + ": ");
    //Console.WriteLine(row.Type);
    if(counter % 100 == 0 && row.Type == RowType.PositionVelocityOrientation)
    {
        Console.WriteLine(row.ToString());
    }
}