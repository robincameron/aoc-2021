using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Aoc2021.Day05.UnitTests")]
namespace Aoc2021.Day05
{
	public static class Program
	{
		public static void Main()
		{
			var data = TransformData(_getData);

			Console.WriteLine(@$"Day_5_pt_1: 
			        Expected: 7142
			        Actual  : { Day05_Part_1(data)}");

            Console.WriteLine(@$"Day_5_pt_2: 
                    Expected: 
                    Actual  : { Day05_Part_2(data)}");
        }

		internal static int Day05_Part_1(IEnumerable<(int, int)[]> input)
		{
			var grid = new int[1000, 1000];

			var coordinates = input
				.SelectMany(r => GetExpandedCoordinates(r))
				.Select(coordinate => grid[coordinate.Item2, coordinate.Item1]++)
				.ToList();

			return grid.Cast<int>().Count(i => i >= 2);
		}

		internal static int Day05_Part_2(IEnumerable<(int, int)[]> input)
		{
			var grid = new int[1000, 1000];

			return 0;
		}

		public static IEnumerable<(int, int)> GetExpandedCoordinates((int, int)[] points)
		{
			if (points[0].Item1 == points[1].Item1)
			{
				var start = points.Select(p => p.Item2).OrderBy(p => p).First();
				var count = points.Select(p => p.Item2).OrderBy(p => p).Last() - start + 1;
				return Enumerable.Range(start, count).Select(e => ValueTuple.Create(points[0].Item1, e));
			}
			else if (points[0].Item2 == points[1].Item2)
			{
				var start = points.Select(p => p.Item1).OrderBy(p => p).First();
				var count = points.Select(p => p.Item1).OrderBy(p => p).Last() - start + 1;
				return Enumerable.Range(start, count).Select(e => ValueTuple.Create(e, points[0].Item2));
			}

			return Array.Empty<(int, int)>();
		}

		internal static readonly Func<Func<string[]>, IEnumerable<(int,int)[]>> TransformData = getRawData => getRawData()
				.Select(r => r.Split(" -> ").Select(i => i.Split(",")).Select(i => ValueTuple.Create(int.Parse(i[0]), int.Parse(i[1]))).ToArray());

		private static readonly Func<string[]> _getData = () => File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "day-05.txt"));
	}
}