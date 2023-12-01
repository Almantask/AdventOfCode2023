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
        [InlineData("onetwo", "1two")]
        [InlineData("ontwo", "on2")]
        [InlineData("on", "on")]
        [InlineData("ontwothree", "on2three")]
        [InlineData("one3two2lcbcvhfive72", "13two2lcbcvhfive72")]
        public void ReplaceTheFirstFoundDigitWordWithDigit_ReturnsExpected(string line, string expected)
        {
            var replaced = DigitsMatcher.ReplaceTheFirstFoundDigitWordWithDigit(line);

            replaced.Should().Be(expected);
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
        [InlineData("onetwo", "one2")]
        [InlineData("ontwo", "on2")]
        [InlineData("on", "on")]
        [InlineData("ontwothree", "ontwo3")]
        [InlineData("ontwo34three", "ontwo343")]
        [InlineData("smdn65foureight7fiveeight", "smdn65foureight7five8")]
        public void ReplaceTheLastFoundDigitWordWithDigit_ReturnsExpected(string line, string expected)
        {
            var replaced = DigitsMatcher.ReplaceTheLastFoundDigitWordWithDigit(line);

            replaced.Should().Be(expected);
        }
    }
}
