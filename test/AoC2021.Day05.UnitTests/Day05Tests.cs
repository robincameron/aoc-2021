using System;
using Xunit;
using static Aoc2021.Day05.Program;

namespace AoC2021.Day05.UnitTests
{
    public class Day05Tests
    {
        private static readonly Func<string[]> getTestData = () => new [] {
            "0,9 -> 5,9",
            "8,0 -> 0,8",
            "9,4 -> 3,4",
            "2,2 -> 2,1",
            "7,0 -> 7,4",
            "6,4 -> 2,0",
            "0,9 -> 2,9",
            "3,4 -> 1,4",
            "0,0 -> 8,8",
            "5,5 -> 8,2"
        };

        [Fact]
        public void Verify_Day05_Part_1()
        {
            const int expected = 5;
            int actual = Day05_Part_1(TransformData(getTestData));

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Verify_Day05_Part_2()
        {
            const int expected = 12;
            int actual = Day05_Part_2(TransformData(getTestData));

            Assert.Equal(expected, actual);
        }
    }
}