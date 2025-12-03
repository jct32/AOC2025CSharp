using Xunit;

namespace AoC2025;

public class Day3Tests
{
    private string[] input = """
                             987654321111111
                             811111111111119
                             234234234234278
                             818181911112111
                             """.Split("\n");
    
    [Fact]
    public void TestPart1()
    {
        Day3 day3 = new Day3();
        var answer = 0;
        
        foreach (var line in input)
        {
            answer += day3.ParseBatteryBank(line);
        }
        
        Assert.Equal(357, answer);
    }

    [Fact]
    public void TestPart2()
    {
        Day3 day3 = new Day3();
        ulong answer = 0;
        
        foreach (var line in input)
        {
            answer += day3.SortBatteryBank(line);
        }

        ulong expected = 3121910778619;
        Assert.Equal(expected, answer);
    }
}