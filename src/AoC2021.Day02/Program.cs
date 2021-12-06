using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Aoc2021.Day02.UnitTests")]
namespace Aoc2021.Day02
{
    public static class Program
    {
		public static void Main()
        {
			IEnumerable<Tuple<string, int>> data = TransformData(_getData);

			Console.WriteLine(
                @$"Day_2_pt_1: 
			        Expected: 1728414
			        Actual  : { Day02_Part_1(data)}");

			Console.WriteLine(
                @$"Day_2_pt_2: 
			        Expected: 1765720035
			        Actual  : { Day02_Part_2(data)}");
        }

		internal static int Day02_Part_1(IEnumerable<Tuple<string, int>> input)
		{
            static Tuple<int, int> ApplyDirection(Tuple<int, int> coordinates, Tuple<string, int> direction) =>
                direction.Item1 == "forward"
                    ? new Tuple<int, int>(coordinates.Item1 + direction.Item2, coordinates.Item2)
                    : new Tuple<int, int>(coordinates.Item1, direction.Item1 == "down" ? coordinates.Item2 + direction.Item2 : coordinates.Item2 - direction.Item2);

            return input.Aggregate(
				new Tuple<int, int>(0, 0),
				(c, d) => ApplyDirection(c, d),
				c => c.Item1 * c.Item2);
		}

		internal static int Day02_Part_2(IEnumerable<Tuple<string, int>> input)
		{
            static Tuple<int, int, int> ApplyDirection(Tuple<int, int, int> coordinates, Tuple<string, int> direction) =>
                direction.Item1 == "forward"
                    ? new Tuple<int, int, int>(coordinates.Item1 + direction.Item2, coordinates.Item2 + (coordinates.Item3 * direction.Item2), coordinates.Item3)
                    : new Tuple<int, int, int>(coordinates.Item1, coordinates.Item2, direction.Item1 == "down" ? coordinates.Item3 + direction.Item2 : coordinates.Item3 - direction.Item2);

            return input.Aggregate(
				new Tuple<int, int, int>(0, 0, 0),
				(c, d) => ApplyDirection(c, d),
				c => c.Item1 * c.Item2);
		}

		internal static readonly Func<Func<string[]>, IEnumerable<Tuple<string, int>>> TransformData = (getData) => getData()
			.Select(x => x.Split(" "))
			.Select(s => new Tuple<string, int>(s[0], int.Parse(s[1])));

		private static readonly Func<string[]> _getData = () => File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "day-02.txt"));
	}
}