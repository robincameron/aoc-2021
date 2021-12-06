using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Aoc2021.Day01.UnitTests")]
namespace Aoc2021.Day01
{
    public static class Program
    {
		public static void Main()
        {
			int[] data = _getData();

			Console.WriteLine(
                @$"Day_1_pt_1: 
			        Expected: 1342
			        Actual  : { Day01_Part_1(data)}");

            Console.WriteLine(
                @$"Day_1_pt_2: 
			        Expected: 1378
			        Actual  : { Day01_Part_2(data)}");
        }

		internal static int Day01_Part_1(int[] input)
		{
			return input.Skip(1).Select((x, i) => x > input[i]).Count(x => x);
		}

		internal static int Day01_Part_2(int[] input)
		{
			return input.Skip(3).Select((x, i) => x > input[i]).Count(x => x);
		}

		private static readonly Func<int[]> _getData = () => File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "day-01.txt")).Select(i => int.Parse(i)).ToArray();

	}
}