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
                var firstAndLastCombined = digits.First() + "" + digits.Last();
                callibrationValues.Add(int.Parse(firstAndLastCombined));
            }

            return callibrationValues.Sum();
        }
    }

    public class Part2 : IPartSolution<long>
    {
        public long Solve(string input)
        {
            var lines = input.SplitByEndOfLine();
            var callibrationValues = new List<int>();
            foreach (var line in lines)
            {
                var firstAndLastCombined = DigitsMatcher.FindFirstDigit(line) + DigitsMatcher.FindLastDigit(line);
                callibrationValues.Add(int.Parse(firstAndLastCombined));
            }

            return callibrationValues.Sum();
        }
    }
}
