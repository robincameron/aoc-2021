namespace Aoc2021.Day01
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine(
                @$"Day_1_pt_1: 
			        Expected: 1342
			        Actual: { Day_01_pt_1(() => File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "day-01.txt")))}");

            Console.WriteLine(
                @$"Day_1_pt_2: 
			        Expected: 1378
			        Actual: { Day_01_pt_2(() => File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "day-01.txt")))}");
        }

		private static int Day_01_pt_1(Func<string[]> getData)
		{
			var input = getData().Select(i => int.Parse(i)).ToArray();

			return input.Skip(1).Select((x, i) => x > input[i]).Count(x => x);
			//input.Where((num, index) => index > 0 && num > input[index - 1]).Count();
			//input.Zip(input.Skip(1), (a, b) => a < b).Count(x => x);
			//input.Where((x, i) => i >= 1 && x > input[i - 1]).Count();
		}

		private static int Day_01_pt_2(Func<string[]> getData)
		{
			var input = getData().Select(i => int.Parse(i)).ToArray();

			return input.Skip(3).Select((x, i) => x > input[i]).Count(x => x);
			//input.Where((num, index) => index > 2 && num > input[index - 3]).Count();
			//input.Zip(input.Skip(3), (a, b) => a < b).Count(x => x);
			//input.Where((x, i) => i >= 3 && x > input[i - 3]).Count();
		}
	}
}