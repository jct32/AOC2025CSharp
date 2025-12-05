namespace AoC2025;
using System;

public class Day1
{
    public void RunDay()
    {
        Part1();
        Part2();
    }

    private void Part1()
    {
        var path = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName;
        path += "/Input/Day1.txt";
        var contents = File.ReadAllText(path);
        var lines = contents.Split("\n");
        var answer = 0;
        int pointer = 50;
        foreach (var line in lines)
        {
            answer += CalculatePart1(ref pointer, line);
        }

        Console.WriteLine($"Part 1 answer: {answer}");
    }

    private int CalculatePart1(ref int pointer, string command)
    {
        var direction = command.Substring(0, 1);
        var increment = int.Parse(command.Substring(1));
        if (direction == "L")
        {
            pointer -= increment;
        }

        if (direction == "R")
        {
            pointer += increment;
        }

        while (pointer < 0)
        {
            pointer += 100;
        }

        while (pointer >= 100)
        {
            pointer -= 100;
        }
        
        if (pointer == 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    private int CalculatePart2(ref int pointer, string command)
    {
        var answer = 0;
        var staringPosition = pointer;
        var direction = command.Substring(0, 1);
        var increment = int.Parse(command.Substring(1));

        for (var i = 0; i < increment; i++)
        {
            if (direction == "L")
            {
                pointer--;
            }

            if (direction == "R")
            {
                pointer++;
            }
            
            if (pointer == 100)
            {
                pointer = 0;
            }

            if (pointer < 0)
            {
                pointer = 100 + pointer;
            }

            if (pointer == 0)
            {
                answer++;
            }

            
        }
        
        return answer;
    }
    
    private void Part2()
    {
        var path = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName;
        path += "/Input/Day1.txt";
        var contents = File.ReadAllText(path);
        var lines = contents.Split("\n");
        var answer = 0;
        int pointer = 50;
        foreach (var line in lines)
        {
            answer += CalculatePart2(ref pointer, line);
        }

        Console.WriteLine($"Part 2 answer: {answer}");
    }
}