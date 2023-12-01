namespace AdventOfCode.Common.Extensions;

public static class StringExtensions
{
    public static string[] SplitByEndOfLine(this string text)
        => text // Had to split by \n because the input files may be saved in different formats.
        .Split(new[] { Environment.NewLine, "\n" }, StringSplitOptions.RemoveEmptyEntries);
}
