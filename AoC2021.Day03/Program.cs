namespace Aoc2021.Day03
{
    public static class Program
    {
        private static readonly Func<int[][], bool, int, int[][]> _processDiagnostics = (input, mostCommon, i) =>
        {
            int bit = input.Where(d => d[i] == 1).Count() >= (input.Length / 2) ? 1 : 0;
            input = input.Where(d => d[i] == (mostCommon ? bit : (bit == 1 ? 0 : 1))).ToArray();
            return input.Length > 1 ? _processDiagnostics(input, mostCommon, i + 1) : input;
        };

        private static readonly Func<Func<string[]>, int[][]> _getInput = getRawData => getRawData()
                .Select(s => s.Select(c => c == '1' ? 1 : 0).ToArray()).ToArray();

        private static readonly Func<IEnumerable<int>, int> _convertOutput = input => Convert.ToInt32(string.Join("", input), 2);

        public static void Main()
        {
            Console.WriteLine(
                @$"Day_3_pt_1: 
			        Expected: 3633500
			        Actual: { Day_3_pt_1(() => File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "day-03.txt")))}");

            Console.WriteLine(
                @$"Day_3_pt_2: 
			        Expected: 4550283
			        Actual: { Day_3_pt_2(() => File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "day-03.txt")))}");
        }

        public static int Day_3_pt_1(Func<string[]> getData)
        {
            Func<int, int, int[], int> _increment = (index, instruction, accumulator) => instruction == 1 ? accumulator[index] + 1 : accumulator[index];

            int[][] input = _getInput(getData);

            var gamma = input
                .Aggregate((a, line) => line.Select((g, i) => _increment(i, g, a)).ToArray())
                .Select(i => i >= input.Length / 2 ? 1 : 0);

            return _convertOutput(gamma) * _convertOutput(gamma.Select(g => g == 1 ? 0 : 1));
        }

        public static int Day_3_pt_2(Func<string[]> getData)
        {
            int[][] input = _getInput(getData);

            return _convertOutput(_processDiagnostics(input, true, 0)[0]) * _convertOutput(_processDiagnostics(input, false, 0)[0]);
        }
    }
}