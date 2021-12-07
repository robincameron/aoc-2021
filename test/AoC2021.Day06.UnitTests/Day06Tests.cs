using System;
using Xunit;
using static Aoc2021.Day06.Program;

namespace AoC2021.Day06.UnitTests
{
    public class Day06Tests
    {
        private static readonly Func<int[]> getTestData = () => new []{ 3, 4, 3, 1, 2 };

        [Fact]
        public void Verify_Day06_Part_1()
        {
            const long expected = 5934;
            long actual = Day06_Part_2(getTestData(), NumberOfDays_Part1);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Verify_Day06_Part_2()
        {
            const long expected = 26984457539;
            long actual = Day06_Part_2(getTestData(), NumberOfDays_Part2);

            Assert.Equal(expected, actual);
        }
    }
}