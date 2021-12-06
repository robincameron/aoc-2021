using Xunit;
using static Aoc2021.Day01.Program;

namespace AoC2021.Day01.UnitTests
{
    public class Day01Tests
    {
        private static readonly int[] testData = new int[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };

        [Fact]
        public void Verify_Day01_Part_1()
        {
            const int expected = 7;
            int result = Day01_Part_1(testData);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Verify_Day01_Part_2()
        {
            const int expected = 5;
            int result = Day01_Part_2(testData);

            Assert.Equal(expected, result);
        }
    }
}