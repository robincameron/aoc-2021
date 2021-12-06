using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Aoc2021.Day04.UnitTests")]
namespace AoC2021.Day04
{
    internal class BingoBoard
    {
        internal BingoBoard(int[][] input)
        {
            Row1 = input[0].Select(x => BingoValue.Create(x)).ToArray();
            Row2 = input[1].Select(x => BingoValue.Create(x)).ToArray();
            Row3 = input[2].Select(x => BingoValue.Create(x)).ToArray();
            Row4 = input[3].Select(x => BingoValue.Create(x)).ToArray();
            Row5 = input[4].Select(x => BingoValue.Create(x)).ToArray();
        }

        private BingoValue[] Row1 { get; }
        private BingoValue[] Row2 { get; }
        private BingoValue[] Row3 { get; }
        private BingoValue[] Row4 { get; }
        private BingoValue[] Row5 { get; }

        public bool TryMarkNumber(int markedNumber)
        {
            return Row1.Select(x => x.Mark(markedNumber))
                    .Concat(Row2.Select(x => x.Mark(markedNumber)))
                    .Concat(Row3.Select(x => x.Mark(markedNumber)))
                    .Concat(Row4.Select(x => x.Mark(markedNumber)))
                    .Concat(Row5.Select(x => x.Mark(markedNumber)))
                    .Any(v => v);
        }

        public (int, int) TryComplete(int markedNumber, int attempt)
        {
            if (IsCompleted())
                return (0, 0);

            if (TryMarkNumber(markedNumber) && IsCompleted())
            {
                return (attempt, CalculateScore(markedNumber));
            }

            return (0, 0);
        }

        public int CalculateScore(int lastValue)
        {
            return Row1.Where(x => !x.IsMarked)
                    .Concat(Row2.Where(x => !x.IsMarked))
                    .Concat(Row3.Where(x => !x.IsMarked))
                    .Concat(Row4.Where(x => !x.IsMarked))
                    .Concat(Row5.Where(x => !x.IsMarked))
                    .Sum(v => v.Value) * lastValue;
        }

        internal bool IsCompleted() => IsARowCompleted() || IsAColumnCompleted();

        private bool IsARowCompleted() => Row1.All(x => x.IsMarked)
                || Row2.All(x => x.IsMarked)
                || Row3.All(x => x.IsMarked)
                || Row4.All(x => x.IsMarked)
                || Row5.All(x => x.IsMarked);

        private bool IsAColumnCompleted() => GetVerticalValues(0).All(x => x.IsMarked)
                || GetVerticalValues(1).All(x => x.IsMarked)
                || GetVerticalValues(2).All(x => x.IsMarked)
                || GetVerticalValues(3).All(x => x.IsMarked)
                || GetVerticalValues(4).All(x => x.IsMarked);

        private BingoValue[] GetVerticalValues(int columnIndex) => new[]
            {
                Row1[columnIndex],
                Row2[columnIndex],
                Row3[columnIndex],
                Row4[columnIndex],
                Row5[columnIndex]
            };
    }
}
