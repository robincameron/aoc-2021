using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Aoc2021.Day03.UnitTests")]
namespace Aoc2021.Day03
{
    public static class Program
    {
        public static void Main()
        {
            int[][] data = TransformData(_getData);

            Console.WriteLine(@$"Day_3_pt_1: 
			        Expected: 3633500
			        Actual  : { Day03_Part_1(data)}");

            Console.WriteLine(@$"Day_3_pt_2: 
			        Expected: 4550283
			        Actual  : { Day03_Part_2(data)}");
        }

        internal static int Day03_Part_1(int[][] input)
        {
            Func<int, int, int[], int> _increment = (index, instruction, accumulator) => 
                instruction == 1 ? accumulator[index] + 1 : accumulator[index];

            var gamma = input
                .Aggregate((a, line) => line.Select((g, i) => _increment(i, g, a)).ToArray())
                .Select(i => i >= input.Length / 2 ? 1 : 0);

            return _convertOutput(gamma) * _convertOutput(gamma.Select(g => g == 1 ? 0 : 1));
        }

        internal static int Day03_Part_2(int[][] input)
        {
            return _convertOutput(_processDiagnostics(input, true, 0)[0]) * _convertOutput(_processDiagnostics(input, false, 0)[0]);
        }

        internal static readonly Func<IEnumerable<int>, int> _convertOutput = input => Convert.ToInt32(string.Join("", input), 2);


        internal static readonly Func<Func<string[]>, int[][]> TransformData = getRawData => getRawData()
                .Select(s => s.Select(c => c == '1' ? 1 : 0).ToArray()).ToArray();

        private static readonly Func<string[]> _getData = () => File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "day-03.txt"));

        private static readonly Func<int[][], bool, int, int[][]> _processDiagnostics = (input, mostCommon, i) =>
        {
            int bit = input.Where(d => d[i] == 1).Count() >= (input.Length / 2) ? 1 : 0;
            input = input.Where(d => d[i] == (mostCommon ? bit : (bit == 1 ? 0 : 1))).ToArray();
            return input.Length > 1 ? _processDiagnostics(input, mostCommon, i + 1) : input;
        };
    }
}