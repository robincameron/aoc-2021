using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Aoc2021.Day05.UnitTests")]
namespace Aoc2021.Day05
{
	public static class Program
	{
		public static void Main()
		{
			(int, int)[][] data = TransformData(_getData);

			Console.WriteLine(@$"Day_5_pt_1: 
			        Expected: 7142
			        Actual  : { Day05_Part_1(data)}");

            Console.WriteLine(@$"Day_5_pt_2: 
                    Expected: 20012
                    Actual  : { Day05_Part_2(data)}");
        }

		internal static int Day05_Part_1((int, int)[][] input)
		{
			var grid = new int[1000, 1000];

			var coordinates = input
				.SelectMany(r => GetExpandedCoordinates_Part1(r))
				.Select(coordinate => grid[coordinate.Item2, coordinate.Item1]++)
				.ToList();

			return grid.Cast<int>().Count(i => i >= 2);
		}

		internal static int Day05_Part_2((int, int)[][] input)
		{
			var grid = new int[1000, 1000];

			var coordinates = input
				.SelectMany(r => GetExpandedCoordinates_Part2(r))
				.Select(coordinate => grid[coordinate.Item2, coordinate.Item1]++)
				.ToList();

			return grid.Cast<int>().Count(i => i >= 2);
		}

		internal static IEnumerable<(int, int)> GetExpandedCoordinates_Part1((int, int)[] points)
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

		internal static (int, int)[] GetExpandedCoordinates_Part2((int, int)[] points)
		{
			var expanded = new List<(int, int)>();

			int x1 = points[0].Item1;
			int y1 = points[0].Item2;
			int x2 = points[1].Item1;
			int y2 = points[1].Item2;

			var dx = x2 > x1 ? 1 : -1;
			var dy = y2 > y1 ? 1 : -1;

			if (x1 == x2)
			{
				dx = 0;
			}

			if (y1 == y2)
			{
				dy = 0;
			}

			expanded.Add((x1, y1));

			while (x1 != x2 || y1 != y2)
			{
				x1 += dx;
				y1 += dy;
				expanded.Add((x1, y1));
			}

			return expanded.ToArray();
		}

		internal static readonly Func<Func<string[]>, (int,int)[][]> TransformData = getRawData => getRawData()
				.Select(r => r.Split(" -> ").Select(i => i.Split(",")).Select(i => ValueTuple.Create(int.Parse(i[0]), int.Parse(i[1]))).ToArray()).ToArray();

		private static readonly Func<string[]> _getData = () => File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "day-05.txt"));
	}
}