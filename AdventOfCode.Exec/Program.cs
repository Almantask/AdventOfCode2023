﻿using AdventOfCode.Common;
using AdventOfCode.Common.Day;

namespace AdventOfCode.Exec
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Solve<Day1.Solution>();
            Solve<Day2.Solution>();
            Solve<Day3.Solution>();
            Solve<Day4.Solution>();
            Solve<Day5.Solution>();
        }

        private static void Solve<TAdventOfCodeDay>() where TAdventOfCodeDay : IAdventOfCodeDay, new()
        {
            new TAdventOfCodeDay().Solve();
        }
    }
}
