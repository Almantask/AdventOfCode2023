using AdventOfCode.Day1;

namespace AdventOfCode.Tests.Day1
{
    public class Day1Tests
    {
        // All characters.
        [Theory]
        [MemberData(nameof(Part1Expectation))]
        public void Part1_Solve_Returns_SumsOfFirstAndLastDigitsCombinedInEveryLine(string calories, long expectedSum)
        {
            // Each line - find first and last digits combined.
            // Sum
            var part1 = new Part1();

            var sumOfCalibrationValues = part1.Solve(calories);

            sumOfCalibrationValues.Should().Be(expectedSum);
        }

        // Some are characters, some are words.
        [Theory]
        [MemberData(nameof(Part2Expectation))]
        public void Part2_Solve_Returns_SumsOfFirstAndLastDigitsCombinedInEveryLine(string calories, long expectedSum)
        {
            var part2 = new Part2();

            var sumOfCalibrationValues = part2.Solve(calories);

            sumOfCalibrationValues.Should().Be(expectedSum);
        }

        public static IEnumerable<object[]> Part1Expectation
        {
            get
            {
                yield return Expect(day: 1, file: "Part1", result: 142);
            }
        }

        public static IEnumerable<object[]> Part2Expectation
        {
            get
            {
                yield return Expect(day: 1, file: "Part2", result: 281);
            }
        }
    }
}
