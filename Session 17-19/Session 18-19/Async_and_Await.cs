using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Sequential execution starts...");
        
        await LongTask("A");
        await LongTask("B");
        await LongTask("C");
        
        Console.WriteLine("Sequential execution complete!");
    }

    static async Task LongTask(string name)
    {
        await Task.Delay(2000);
        Console.WriteLine(name + " done");
    }
}
