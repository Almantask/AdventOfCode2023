using System.Text.RegularExpressions;

namespace AdventOfCode.Day1
{
    public static class DigitsMatcher
    {
        private class NumberLookup
        {
            public static Dictionary<string, string> Numbers = new Dictionary<string, string>
            {
                {"one", "1"},
                {"two", "2"},
                {"three", "3"},
                {"four", "4"},
                {"five", "5"},
                {"six", "6"},
                {"seven", "7"},
                {"eight", "8"},
                {"nine", "9"}
            };

            public string Word { get; }
            public List<Match> Matches { get; }

            public bool Matched => Matches.Any();
            public string Digit => Numbers[Word];
            public int FirstMatchIndex => Matches.Select(m => m.Index).Min();
            public int LastMatchIndex => Matches.Select(m => m.Index).Max();

            public NumberLookup(string number, List<Match> matches)
            {
                Word = number;
                Matches = matches;
            }
        }

        public static string? FindFirstDigit(string line)
        {
            List<NumberLookup> numberTranslationLookups = LookupForNumbers(line);

            var firstNumberFound = numberTranslationLookups
                .Where(l => l.Matched)
                .OrderBy(l => l.FirstMatchIndex)
                .FirstOrDefault();

            return firstNumberFound?.Digit;
        }

        public static string? FindLastDigit(string line)
        {
            List<NumberLookup> numberTranslationLookups = LookupForNumbers(line);

            var lastNumberFound = numberTranslationLookups
                .Where(l => l.Matched)
                .OrderByDescending(l => l.LastMatchIndex)
                .FirstOrDefault();

            return lastNumberFound?.Digit;
        }

        private static List<NumberLookup> LookupForNumbers(string line)
        {
            var numberTranslationLookups = new List<NumberLookup>();
            foreach (var numberTranslation in NumberLookup.Numbers)
            {
                var matchesWords = Regex.Matches(line, numberTranslation.Key);
                var matchesNumbers = Regex.Matches(line, numberTranslation.Value);
                var matches = matchesWords.Concat(matchesNumbers).ToList();
                numberTranslationLookups.Add(new NumberLookup(numberTranslation.Key, matches));
            }

            return numberTranslationLookups;
        }
    }
}
