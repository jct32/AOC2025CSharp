using Xunit;

namespace AoC2025;

public class Day5Tests
{
    private static readonly string Lines = """
                                            3-5
                                            10-14
                                            16-20
                                            12-18

                                            1
                                            5
                                            8
                                            11
                                            17
                                            32
                                            """;
    private static readonly string[] SplitContents = Lines.Split("\n\n");
    private readonly string[] _ingredientIds = SplitContents[0].Split("\n");
    private readonly string[] _freshIds = SplitContents[1].Split("\n");

    [Fact]
    public void Part1Test()
    {
        Day5 day = new Day5();
        var answer = 0;
        var listOfRanges = day.ParseRanges(_ingredientIds);
        
        foreach (var id in _freshIds)
        {
            if (day.IsIngredientFresh(ulong.Parse(id), listOfRanges))
            {
                answer += 1;
            }
        }
        
        Assert.Equal(3, answer);
    }

    [Fact]
    public void Part2Test()
    {
        Day5 day = new Day5();
        var listOfRanges = day.ParseRanges(_ingredientIds);
        var answer = day.GetNumberOfIngredient(listOfRanges);
        ulong expected = 14;
        Assert.Equal(expected, answer);
    }   
}