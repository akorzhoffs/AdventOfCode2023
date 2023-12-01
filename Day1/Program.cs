var lines = File.ReadLines("input.txt").ToList();

Console.WriteLine(Sum(ReplaceWordsWithNumbers(lines)));

static int Sum(IEnumerable<string> lines)
{
    return lines
        .Select(line => line
            .Where(symbol => int.TryParse(symbol.ToString(), out _))
            .ToList())
        .Select(values => int.Parse(values[0].ToString() + values[^1]))
        .Sum();
}


static IEnumerable<string> ReplaceWordsWithNumbers(IList<string> lines)
{
    var stringNumbers = new List<string> { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };


    for (var i = 0; i < lines.Count; i++)
    {
        foreach (var stringNumber in stringNumbers)
        {
            while (lines[i].Contains(stringNumber))
            {
                var valueToInsert = (stringNumbers.IndexOf(stringNumber) + 1).ToString();
                var insertionIndex = lines[i].IndexOf(stringNumber, StringComparison.Ordinal) + 1;
                lines[i] = lines[i].Insert(insertionIndex,
                    valueToInsert);
            }
                
        }
    }
    return lines;
}