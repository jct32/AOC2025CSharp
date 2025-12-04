namespace AoC2025;

public class Day4
{
    private static readonly string Path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName +
                                          "/Input/Day4.txt";

    private static readonly string Contents = File.ReadAllText(Path);
    private static string[] _lines = Contents.Split('\n');

    public void RunDay()
    {
        Part1();
        Part2();
    }

    private void Part1()
    {
        Console.WriteLine($"Part 1: {GetAvailableFromLines(_lines)}");
    }

    public int GetAvailableFromLinesPart2(string[] lines)
    {
        var answer = 0;
        var rollsCanBeRemoved = true;
        
        char[][] newlines = new char[lines.Length][];
        for (var i = 0; i < lines.Length; i++)
        {
            newlines[i] = lines[i].ToCharArray();
        }
        
        // Looping through the rows
        while (rollsCanBeRemoved)
        {
            var indexToBeRemoved = new List<(int, int)>();
            var numberRemoved = 0;
            for (int i = 0; i < newlines.Length; i++)
            {
                var checkTop = true;
                var checkBottom = true;

                // check if we are on the top or bottom row
                if (i == 0)
                {
                    checkTop = false;
                }

                if (i == newlines.Length - 1)
                {
                    checkBottom = false;
                }

                // Looping through each column
                for (int k = 0; k < newlines[i].Length; k++)
                {
                    // Don't care about empty spots right now
                    if (newlines[i][k] == '.')
                    {
                        continue;
                    }

                    var adjacentRolls = 0;
                    var checkLeft = true;
                    var checkRight = true;
                    // Check if we are on the left or right column
                    if (k == 0)
                    {
                        checkLeft = false;
                    }

                    if (k == newlines[i].Length - 1)
                    {
                        checkRight = false;
                    }

                    // Check Left
                    if (checkLeft)
                    {
                        if (newlines[i][k - 1] == '@')
                        {
                            adjacentRolls += 1;
                        }
                    }

                    // Check Top Left
                    if (checkLeft && checkTop)
                    {
                        if (newlines[i - 1][k - 1] == '@')
                        {
                            adjacentRolls += 1;
                        }
                    }

                    // Check Top
                    if (checkTop)
                    {
                        if (newlines[i - 1][k] == '@')
                        {
                            adjacentRolls += 1;
                        }
                    }

                    // Check Top Right
                    if (checkTop && checkRight)
                    {
                        if (newlines[i - 1][k + 1] == '@')
                        {
                            adjacentRolls += 1;
                        }
                    }

                    // Check Right
                    if (checkRight)
                    {
                        if (newlines[i][k + 1] == '@')
                        {
                            adjacentRolls += 1;
                        }
                    }

                    // Check Bottom Right
                    if (checkRight && checkBottom)
                    {
                        if (newlines[i + 1][k + 1] == '@')
                        {
                            adjacentRolls += 1;
                        }
                    }

                    // Check Bottom
                    if (checkBottom)
                    {
                        if (newlines[i + 1][k] == '@')
                        {
                            adjacentRolls += 1;
                        }
                    }

                    // Check Bottom Left
                    if (checkBottom && checkLeft)
                    {
                        if (newlines[i + 1][k - 1] == '@')
                        {
                            adjacentRolls += 1;
                        }
                    }

                    if (adjacentRolls < 4)
                    {
                        indexToBeRemoved.Add((i, k));
                        numberRemoved += 1;
                    }
                }
            }

            if (numberRemoved > 0)
            {
                answer += numberRemoved;
                foreach (var index in indexToBeRemoved)
                {
                    newlines[index.Item1][index.Item2] = '.';
                }
            }
            else
            {
                rollsCanBeRemoved = false;
            }
        }
        return answer;
    }


    private void Part2()
    {
        Console.WriteLine($"Part 2: {GetAvailableFromLinesPart2(_lines)}");
    }

    public int GetAvailableFromLines(string[] lines)
    {
        var answer = 0;
        
        // Looping through the rows
        for (int i = 0; i < lines.Length; i++)
        {
            var checkTop = true;
            var checkBottom = true;

            // check if we are on the top or bottom row
            if (i == 0)
            {
                checkTop = false;
            }

            if (i == lines.Length - 1)
            {
                checkBottom = false;
            }

            // Looping through each column
            for (int k = 0; k < lines[i].Length; k++)
            {
                // Don't care about empty spots right now
                if (lines[i][k] == '.')
                {
                    continue;
                }

                var adjacentRolls = 0;
                var checkLeft = true;
                var checkRight = true;
                // Check if we are on the left or right column
                if (k == 0)
                {
                    checkLeft = false;
                }

                if (k == lines[i].Length - 1)
                {
                    checkRight = false;
                }

                // Check Left
                if (checkLeft)
                {
                    if (lines[i][k - 1] == '@')
                    {
                        adjacentRolls += 1;
                    }
                }

                // Check Top Left
                if (checkLeft && checkTop)
                {
                    if (lines[i - 1][k - 1] == '@')
                    {
                        adjacentRolls += 1;
                    }
                }

                // Check Top
                if (checkTop)
                {
                    if (lines[i - 1][k] == '@')
                    {
                        adjacentRolls += 1;
                    }
                }

                // Check Top Right
                if (checkTop && checkRight)
                {
                    if (lines[i - 1][k + 1] == '@')
                    {
                        adjacentRolls += 1;
                    }
                }

                // Check Right
                if (checkRight)
                {
                    if (lines[i][k + 1] == '@')
                    {
                        adjacentRolls += 1;
                    }
                }

                // Check Bottom Right
                if (checkRight && checkBottom)
                {
                    if (lines[i + 1][k + 1] == '@')
                    {
                        adjacentRolls += 1;
                    }
                }

                // Check Bottom
                if (checkBottom)
                {
                    if (lines[i + 1][k] == '@')
                    {
                        adjacentRolls += 1;
                    }
                }

                // Check Bottom Left
                if (checkBottom && checkLeft)
                {
                    if (lines[i + 1][k - 1] == '@')
                    {
                        adjacentRolls += 1;
                    }
                }

                if (adjacentRolls < 4)
                {
                    answer += 1;
                }
            }
        }

        return answer;
    }
}