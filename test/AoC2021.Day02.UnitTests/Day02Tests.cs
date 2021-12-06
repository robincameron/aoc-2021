using System;
using Xunit;
using static Aoc2021.Day02.Program;

namespace AoC2021.Day02.UnitTests
{
    public class Day02Tests
    {
        private static readonly Func<string[]> _getTestData = () => new string[] { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" };

        [Fact]
        public void Verify_Day02_Part_1()
        {
            const int expected = 150;
            int result = Day02_Part_1(TransformData(_getTestData));

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Verify_Day02_Part_2()
        {
            const int expected = 900;
            int result = Day02_Part_2(TransformData(_getTestData));

            Assert.Equal(expected, result);
        }
    }
}