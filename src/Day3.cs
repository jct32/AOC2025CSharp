using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.JavaScript;

namespace AoC2025;

public class Day3
{
    private static readonly string Path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "/Input/day3.txt";
    private static readonly string Contents = File.ReadAllText(Path);
    private static string[] _batteryBanks = Contents.Split('\n');
    public void RunDay()
    {
        Part1();
        Part2();
    }

    private void Part1()
    {
        var answer = 0;
        
        foreach (var batteryBank in _batteryBanks)
        {
            answer += ParseBatteryBank(batteryBank);
        }
        
        Console.WriteLine($"Part 1: {answer}");
    }

    private int ParseBatteryBank(string batteryBank)
    {
        var firstIndex = -1;
        var secondIndex = -1;
        var firstValue = -1;
        var secondValue = -1;
        
        // do first loop
        for (var i = 0; i < batteryBank.Length - 1; i++)
        {
            if (batteryBank[i] - '0'> firstValue)
            {
                firstIndex = i;
                firstValue = batteryBank[i] - '0';
            }
        }

        // Get second index
        for (var i = firstIndex + 1; i < batteryBank.Length; i++)
        {
            if (batteryBank[i] - '0' > secondValue)
            {
                secondIndex = i;
                secondValue = batteryBank[i] - '0';
            }
        }
        
        var finalAnswer = batteryBank[firstIndex] +  batteryBank[secondIndex].ToString();
        return int.Parse(finalAnswer);
    }

    private void Part2()
    {
        ulong answer = 0;
        
        foreach (var batteryBank in _batteryBanks)
        {
            answer += SortBatteryBank(batteryBank);
        }
        
        Console.WriteLine($"Part 1: {answer}");
    }

    private ulong SortBatteryBank(string batteryBank)
    {
        string answerString = string.Empty;
        var currentIndex = 0;
        
        while (answerString.Length < 12)
        {
            var skipsLeft = batteryBank.Length - 12 - (currentIndex  - answerString.Length);
            var maxIndex = skipsLeft + currentIndex;
            var currentValue = batteryBank[currentIndex] - '0';
            var newIndex = currentIndex;
            
            for (var i = currentIndex; i <= maxIndex; i++)
            {
                if (batteryBank[i] - '0' > currentValue)
                {
                    newIndex = i;
                    currentValue = batteryBank[i] - '0';
                }
            }
            
            answerString += batteryBank[newIndex].ToString();
            
            if (newIndex > currentIndex)
            {
                currentIndex = newIndex + 1;
            }
            else
            {
                currentIndex++;
            }
        }
        return ulong.Parse(answerString);
    }
}