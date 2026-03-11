using System;
using System.Threading.Tasks;

class Two_Async_TaskAtATime
{
	private static readonly Random _random = new Random();

	static async Task Main(string[] args)
	{
		Console.WriteLine("Random execution starts...");

		// Start both tasks concurrently
		Task sitaTask = LongTask("SITA");
		Task ramTask = LongTask("RAM");

		await Task.WhenAll(sitaTask, ramTask);

		Console.WriteLine("Random execution complete!");
	}

	static async Task LongTask(string name)
	{
		for (int i = 1; i <= 50; i++)
		{
			// Random delay between 500ms to 3500ms (instead of fixed 2000ms)
			int randomDelay = _random.Next(500, 3501);
			await Task.Delay(randomDelay);

			Console.Write(name + " ");
		}
		Console.WriteLine();  // New line at end
	}
}
