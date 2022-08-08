namespace Roslyn.Generator.Example
{
	internal static class Program
	{
		private static void Main(string[] args)
		{
			string greeting = Greeter.GetHelloWorld();

			Console.WriteLine(greeting);
		}
	}
}
