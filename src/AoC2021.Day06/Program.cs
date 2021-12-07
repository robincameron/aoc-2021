using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Aoc2021.Day06.UnitTests")]
namespace Aoc2021.Day06
{
	public static class Program
	{
		internal const int ReproductiveCycleLength = 6;
		internal const int MaturityAge = 3;
		internal const int NumberOfDays_Part1 = 80;
		internal const int NumberOfDays_Part2 = 256;

		public static void Main()
		{
			int[] data = _getData();

            Console.WriteLine(@$"Day_6_pt_1: 
			        Expected: 394994
			        Actual  : { Day06_Part_2(data, NumberOfDays_Part1)}");

            Console.WriteLine(@$"Day_6_pt_2: 
			        Expected: 1765974267455
			        Actual  : { Day06_Part_2(data, NumberOfDays_Part2)}");
		}

		internal static long Day06_Part_2(int[] input, int numberOfDays)
		{
			long[] timerCounts = new long[ReproductiveCycleLength + MaturityAge];

			foreach (int timer in input)
			{
				timerCounts[timer]++;
			}

			for (int i = 0; i < numberOfDays; i++)
			{
				long aboutToSpawn = timerCounts[0];

				for (int j = 0; j < timerCounts.Length - 1; j++)
				{
					timerCounts[j] = timerCounts[j + 1];
				}

				timerCounts[^1] = aboutToSpawn;
				timerCounts[ReproductiveCycleLength] += aboutToSpawn;
			}

			return timerCounts.Sum(timerCount => timerCount);
		}

		private static readonly Func<int[]> _getData = () => 
			File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "day-06.txt"))[0]
			.Split(",")
			.Select(i => int.Parse(i)).ToArray();
	}
}