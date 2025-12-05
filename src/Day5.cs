namespace AoC2025;

public class Day5
{
    private static readonly string Path = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName +
                                          "/Input/Day5.txt";
    private static readonly string Contents = File.ReadAllText(Path);
    private static readonly string[] SplitContents = Contents.Split("\n\n");
    private readonly string[] _ingredientIds = SplitContents[0].Split("\n");
    private readonly string[] _freshIds = SplitContents[1].Split("\n");
    
    public void RunDay()
    {
        Part1();
        Part2();
    }

    private void Part1()
    {
        var answer = 0;
        var listOfRanges = ParseRanges(_ingredientIds);
        
        foreach (var id in _freshIds)
        {
            if (IsIngredientFresh(ulong.Parse(id), listOfRanges))
            {
                answer += 1;
            }
        }
        
        Console.WriteLine($"Part 1: {answer}");
    }

    public List<(ulong, ulong)> ParseRanges(string[] ranges)
    {
        List<(ulong, ulong)> listOfRanges = new List<(ulong, ulong)>();
        
        foreach (var range in ranges)
        {
            var splitRange = range.Split("-");
            var firstNumber = ulong.Parse(splitRange[0]);
            var secondNumber = ulong.Parse(splitRange[1]);
            listOfRanges.Add((firstNumber, secondNumber));
        }

        return listOfRanges;
    }

    public bool IsIngredientFresh(ulong id, List<(ulong, ulong)> listOfRanges)
    {
        foreach (var range in listOfRanges)
        {
            if (id >= range.Item1 && id <= range.Item2)
            {
                return true;
            }
        }

        return false;
    }

    private void Part2()
    {
        var listOfRanges = ParseRanges(_ingredientIds);
        Console.WriteLine($"Part 2: {GetNumberOfIngredient(listOfRanges)}");
    }

    public ulong GetNumberOfIngredient(List<(ulong, ulong)> idRanges)
    {
        ulong answer = 0;
        idRanges.Sort((t1, t2) => t1.Item2.CompareTo(t2.Item2));
        var i = idRanges.Count - 1;
        
        while (i > 0)
        {
            var a = idRanges[i].Item1;
            var b = idRanges[i].Item2;
            var c = idRanges[i - 1].Item1;
            var d = idRanges[i - 1].Item2;

            if (a <= d && c <= b)
            {
                idRanges[i] = (Math.Min(a, c), Math.Max(b, d));
                idRanges.RemoveAt(i - 1);
            }

            i--;
        }
        
        foreach(var range in idRanges)
        {
            var a = range.Item1;
            var b = range.Item2;

            answer += b - a + 1;
        }

        return answer;
    }
}