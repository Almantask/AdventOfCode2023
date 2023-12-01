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
            private MatchCollection Matches { get; }

            public bool Matched => Matches.Any();
            public string Digit => Numbers[Word];
            public int FirstMatchIndex => Matches.Select(m => m.Index).Min();
            public int LastMatchIndex => Matches.Select(m => m.Index).Max();

            public NumberLookup(string number, MatchCollection matches)
            {
                Word = number;
                Matches = matches;
            }

            public static string ReplaceTheFirstFoundDigitWordWithDigit(string line)
            {
                List<NumberLookup> numberTranslationLookups = LookupForNumbers(line);

                var firstNumberFound = numberTranslationLookups
                    .Where(l => l.Matched)
                    .OrderBy(l => l.FirstMatchIndex)
                    .FirstOrDefault();

                if (firstNumberFound == null) return line;
                return ReplaceLookupWordWithDigit(line, firstNumberFound.FirstMatchIndex, firstNumberFound.Digit, firstNumberFound.Word.Length);
            }

            public static string ReplaceTheLastFoundDigitWordWithDigit(string line)
            {
                List<NumberLookup> numberTranslationLookups = LookupForNumbers(line);

                var lastNumberFound = numberTranslationLookups
                    .Where(l => l.Matched)
                    .OrderByDescending(l => l.LastMatchIndex)
                    .FirstOrDefault();

                if (lastNumberFound == null) return line;
                return ReplaceLookupWordWithDigit(line, lastNumberFound.LastMatchIndex, lastNumberFound.Digit, lastNumberFound.Word.Length);
            }

            private static List<NumberLookup> LookupForNumbers(string line)
            {
                var numberTranslationLookups = new List<NumberLookup>();
                foreach (var numberTranslation in NumberLookup.Numbers)
                {
                    var index = Regex.Matches(line, numberTranslation.Key);
                    numberTranslationLookups.Add(new NumberLookup(numberTranslation.Key, index));
                }

                return numberTranslationLookups;
            }

            private static string ReplaceLookupWordWithDigit(string line, int index, string numberToBeReplaced, int lenghtOfNumber)
            {
                return
                    line.Substring(0, index) +
                    numberToBeReplaced +
                    line.Substring(index + lenghtOfNumber);
            }

        }
    }
}
