using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Aoc2021.Day02.UnitTests")]
namespace Aoc2021.Day02
{
    public static class Program
    {
		public static void Main()
        {
			var data = TransformData(_getData);

			Console.WriteLine(@$"Day_2_pt_1: 
			        Expected: 1728414
			        Actual  : { Day02_Part_1(data)}");

			Console.WriteLine(@$"Day_2_pt_2: 
			        Expected: 1765720035
			        Actual  : { Day02_Part_2(data)}");
        }

		internal static int Day02_Part_1(IEnumerable<(string, int)> input)
		{
            return input.Aggregate(
				(0, 0),
				(c, d) => ApplyDirection_Part1(c, d),
				c => c.Item1 * c.Item2);
		}

		internal static int Day02_Part_2(IEnumerable<(string, int)> input)
		{
            return input.Aggregate(
				(0, 0, 0),
				(c, d) => ApplyDirection_Part2(c, d),
				c => c.Item1 * c.Item2);
		}

		internal static (int, int) ApplyDirection_Part1((int, int) coordinates, (string, int) direction) =>
				direction.Item1 == "forward"
					? (coordinates.Item1 + direction.Item2, coordinates.Item2)
					: (coordinates.Item1, direction.Item1 == "down" ? coordinates.Item2 + direction.Item2 : coordinates.Item2 - direction.Item2);

		internal static (int, int, int) ApplyDirection_Part2((int, int, int) coordinates, (string, int) direction) =>
				direction.Item1 == "forward"
					? (coordinates.Item1 + direction.Item2, coordinates.Item2 + (coordinates.Item3 * direction.Item2), coordinates.Item3)
					: (coordinates.Item1, coordinates.Item2, direction.Item1 == "down" ? coordinates.Item3 + direction.Item2 : coordinates.Item3 - direction.Item2);

		internal static readonly Func<Func<string[]>, IEnumerable<(string, int)>> TransformData =
			getData => getData().Select(x => x.Split(" "))
								.Select(s => (s[0], int.Parse(s[1])));

		private static readonly Func<string[]> _getData = () => File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "day-02.txt"));
	}
}