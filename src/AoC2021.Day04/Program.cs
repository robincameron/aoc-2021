using System.Runtime.CompilerServices;
using AoC2021.Day04;

[assembly: InternalsVisibleTo("Aoc2021.Day04.UnitTests")]
namespace Aoc2021.Day04
{
	public static class Program
	{
		public static void Main()
		{
			var (input, boards) = TransformData(_getData);

            Console.WriteLine(@$"Day_4_pt_1: 
			        Expected: 16674
			        Actual  : { Day04_Part_1(input, boards)}");

            Console.WriteLine(@$"Day_4_pt_2: 
                    Expected: 7075
                    Actual  : { Day04_Part_2(input, boards)}");
        }

		internal static int Day04_Part_1(int[] input, IEnumerable<BingoBoard> bingoBoards)
		{
            foreach (int number in input)
            {
				if (bingoBoards.Select(x => x.TryMarkNumber(number)).ToList().Count > 0)
                {
					var completedBoard = bingoBoards.FirstOrDefault(b => b.IsCompleted());
					if (completedBoard != null)
                    {
						return completedBoard.CalculateScore(number);
                    }
				}
			}

			return 0;
		}

		internal static int Day04_Part_2(int[] input, IEnumerable<BingoBoard> bingoBoards)
		{
			return input.SelectMany((n, i) => bingoBoards.Select(b => b.TryComplete(n, i)))
				.ToList()
				.Where(r => r.Item1 != 0)
				.OrderByDescending(r => r.Item1)
				.Select(v => v.Item2)
                .FirstOrDefault();
		}

		internal static readonly Func<Func<string[]>, (int[], BingoBoard[])> TransformData = getData =>
        {
			string[] file = getData();

			int[] input = file[0].Split(",").Select(i => int.Parse(i)).ToArray();

			var bingoBoards = new List<BingoBoard>();

            for (int i = 2; i < file.Length; i = i + 6)
            {
				bingoBoards.Add(new BingoBoard(new[]
				{
					file[i].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(r => int.Parse(r)).ToArray(),
					file[i+1].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(r => int.Parse(r)).ToArray(),
					file[i+2].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(r => int.Parse(r)).ToArray(),
					file[i+3].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(r => int.Parse(r)).ToArray(),
					file[i+4].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(r => int.Parse(r)).ToArray()
				}));
			}

			return (input, bingoBoards.ToArray());
        };

		private static readonly Func<string[]> _getData = () => File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "day-04.txt"));
	}
}