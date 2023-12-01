using AdventOfCode.Common.Day;
using AdventOfCode.Common.Extensions;
using System.Text;

namespace AdventOfCode.Day1
{
    public class Solution : AdventOfCodeDay<Part1, Part2, long>
    {
        protected override int Day => 1;
    }

    public class Part1 : IPartSolution<long>
    {
        public long Solve(string input)
        {
            var lines =  input.SplitByEndOfLine();
            var callibrationValues = new List<int>();
            foreach (var line in lines)
            {
                var digits = line.Where(char.IsDigit).ToList().ToArray();
                var firstTwoDigitsCombined = digits.First() + "" + digits.Last();
                callibrationValues.Add(int.Parse(firstTwoDigitsCombined));
            }

            return callibrationValues.Sum();
        }
    }

    public class Part2 : IPartSolution<long>
    {
        public long Solve(string input)
        {
            var wordsReplacedWithDigits = ReplaceFirstAndLastWordsWithDigits(input);
            var part1 = new Part1();
            return part1.Solve(wordsReplacedWithDigits);
        }

        private static string ReplaceFirstAndLastWordsWithDigits(string input)
        {
            var lines = input.SplitByEndOfLine();
            var sb = new StringBuilder();
            foreach (var line in lines)
            {
                string replaced = line;
                replaced = DigitsMatcher.ReplaceTheFirstFoundDigitWordWithDigit(replaced);
                replaced = DigitsMatcher.ReplaceTheLastFoundDigitWordWithDigit(replaced);
                sb.AppendLine(replaced);
            }

            return sb.ToString();
        }
    }
}
