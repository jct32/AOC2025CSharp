using Xunit;

namespace AoC2025;

public class Day4Tests
{
    private string[] _input = """
                              ..@@.@@@@.
                              @@@.@.@.@@
                              @@@@@.@.@@
                              @.@@@@..@.
                              @@.@@@@.@@
                              .@@@@@@@.@
                              .@.@.@.@@@
                              @.@@@.@@@@
                              .@@@@@@@@.
                              @.@.@@@.@.
                              """.Split("\n");

    [Fact]
    public void Part1Test()
    {
        Day4 day4 = new Day4();
        var answer = 0;
        answer += day4.GetAvailableFromLines(_input);
        Assert.Equal(13, answer);
    }

    [Fact]
    public void Part2Test()
    {
        Day4 day4 = new Day4();
        var answer = day4.GetAvailableFromLinesPart2(_input);
        Assert.Equal(43, answer);
    }
    
}