namespace Aoc2021.Day02
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine(
                @$"Day_2_pt_1: 
			        Expected: 1728414
			        Actual: { Day_02_pt_1(() => File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "day-02.txt")))}");

			Console.WriteLine(
                @$"Day_2_pt_2: 
			        Expected: 1765720035
			        Actual: { Day_02_pt_2(() => File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "day-02.txt")))}");
        }

		public static int Day_02_pt_1(Func<string[]> getData)
		{
			Func<Tuple<int, int>, Tuple<string, int>, Tuple<int, int>> ApplyDirection = (coordinates, direction) =>
				direction.Item1 == "forward"
					? new Tuple<int, int>(coordinates.Item1 + direction.Item2, coordinates.Item2)
					: new Tuple<int, int>(coordinates.Item1, direction.Item1 == "down" ? coordinates.Item2 + direction.Item2 : coordinates.Item2 - direction.Item2);

			return getData()
				.Select(x => x.Split(" "))
				.Select(s => new Tuple<string, int>(s[0], int.Parse(s[1])))
				.Aggregate(
					new Tuple<int, int>(0, 0),
					(c, d) => ApplyDirection(c, d),
					c => c.Item1 * c.Item2);
		}

		public static int Day_02_pt_2(Func<string[]> getData)
		{
			Func<Tuple<int, int, int>, Tuple<string, int>, Tuple<int, int, int>> ApplyDirection = (coordinates, direction) =>
				direction.Item1 == "forward"
					? new Tuple<int, int, int>(coordinates.Item1 + direction.Item2, coordinates.Item2 + coordinates.Item3 * direction.Item2, coordinates.Item3)
					: new Tuple<int, int, int>(coordinates.Item1, coordinates.Item2, direction.Item1 == "down" ? coordinates.Item3 + direction.Item2 : coordinates.Item3 - direction.Item2);

			return getData()
				.Select(x => x.Split(" "))
				.Select(s => new Tuple<string, int>(s[0], int.Parse(s[1])))
				.Aggregate(
					new Tuple<int, int, int>(0, 0, 0),
					(c, d) => ApplyDirection(c, d),
					c => c.Item1 * c.Item2);
		}
	}
}