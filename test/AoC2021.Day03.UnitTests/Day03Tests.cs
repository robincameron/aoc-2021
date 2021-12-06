using System;
using Xunit;
using static Aoc2021.Day03.Program;

namespace AoC2021.Day03.UnitTests
{
    public class Day03Tests
    {
        private static readonly Func<string[]> _getTestData = () => new string[] {
            "00100",
            "11110",
            "10110",
            "10111",
            "10101",
            "01111",
            "00111",
            "11100",
            "10000",
            "11001",
            "00010",
            "01010"
        };

        [Fact]
        public void Verify_Day03_Part_1()
        {
            const int expected = 198;
            int result = Day03_Part_1(TransformData(_getTestData));

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Verify_Day03_Part_2()
        {
            const int expected = 230; // 60
            int result = Day03_Part_2(TransformData(_getTestData));

            Assert.Equal(expected, result);
        }
    }
}