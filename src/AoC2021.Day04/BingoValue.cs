using System.Diagnostics;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Aoc2021.Day04.UnitTests")]
namespace AoC2021.Day04
{
    [DebuggerDisplay("Value = {Value}; IsMarked = {IsMarked}")]
    internal class BingoValue
    {
        internal BingoValue(int value)
        {
            Value = value;
        }

        internal int Value { get; }

        internal bool IsMarked { get; set; }

        internal static BingoValue Create(int value) => new BingoValue(value);

        internal bool Mark(int value)
        {
            if (!IsMarked && value == Value)
            {
                IsMarked = true;
                return true;
            }

            return false;
        }
    }
}
