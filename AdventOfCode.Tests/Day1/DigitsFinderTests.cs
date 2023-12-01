using AdventOfCode.Day1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Day1
{
    public class DigitsMatcherTests
    {
        [Theory]
        [InlineData("one", "1")]
        [InlineData("two", "2")]
        [InlineData("three", "3")]
        [InlineData("four", "4")]
        [InlineData("five", "5")]
        [InlineData("six", "6")]
        [InlineData("seven", "7")]
        [InlineData("eight", "8")]
        [InlineData("nine", "9")]
        [InlineData("eightwo", "8")]
        [InlineData("ontwo", "2")]
        [InlineData("on1", "1")]
        [InlineData("one2", "1")]
        [InlineData("2one", "2")]
        [InlineData("threeeight", "3")]
        public void FindFirstDigit_ReturnsExpected(string line, string expected)
        {
            var digit = DigitsMatcher.FindFirstDigit(line);

            digit.Should().Be(expected);
        }

        [Theory]
        [InlineData("one", "1")]
        [InlineData("two", "2")]
        [InlineData("three", "3")]
        [InlineData("four", "4")]
        [InlineData("five", "5")]
        [InlineData("six", "6")]
        [InlineData("seven", "7")]
        [InlineData("eight", "8")]
        [InlineData("nine", "9")]
        [InlineData("eightwo", "2")]
        [InlineData("ontwo", "2")]
        [InlineData("on1", "1")]
        [InlineData("one2", "2")]
        [InlineData("2one", "1")]
        [InlineData("threeeight", "8")]
        public void FindLastDigit_ReturnsExpected(string line, string expected)
        {
            var digit = DigitsMatcher.FindLastDigit(line);

            digit.Should().Be(expected);
        }
    }
}
