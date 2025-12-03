namespace AoC2025;

public class Day2
{
    public void RunDay()
    {
        Part1();
        Part2();
    }

    private void Part1()
    {
        ulong answer = 0;
        var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        path += "/Input/Day2.txt";
        var contents = File.ReadAllText(path);
        var idRanges = contents.Split(',');
        
        foreach (var idRange in idRanges)
        {
            answer += ParseRangePart1(idRange);
        }
        
        Console.WriteLine($"Part 1: {answer}");
    }

    private ulong ParseRangePart1(string idRange)
    {
        ulong answer = 0;
        var ranges = idRange.Split('-');
        ulong startRange = ulong.Parse(ranges[0]);
        ulong endRange = ulong.Parse(ranges[1]);
        
        for (ulong i = startRange; i <= endRange; i++)
        {
            if (DoesNumberRepeat(i.ToString()))
            {
                answer += i;
            }
        }
        return answer;
    }

    private bool DoesNumberRepeat(string number)
    {
        for (int i = 0; i < number.Length / 2; i++)
        {
            if (number.Substring(0, i + 1) == number.Substring(i + 1, number.Length - i - 1))
            {
                return true;
            }
        }
        return false;
    }

    private void Part2()
    {
        ulong answer = 0;
        var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        path += "/Input/Day2.txt";
        var contents = File.ReadAllText(path);
        var idRanges = contents.Split(',');
        
        foreach (var idRange in idRanges)
        {
            answer += ParseRangePart2(idRange);
        }
        
        Console.WriteLine($"Part 1: {answer}");
    }
    
    private ulong ParseRangePart2(string idRange)
    {
        ulong answer = 0;
        var ranges = idRange.Split('-');
        ulong startRange = ulong.Parse(ranges[0]);
        ulong endRange = ulong.Parse(ranges[1]);
        
        for (ulong i = startRange; i <= endRange; i++)
        {
            var twoContinue = false;
            var number = i.ToString();
            if (number.Length == 2)
            {
                if (number[0] == number[1])
                {
                    answer += i;
                }
                twoContinue = true; 
            }

            if (twoContinue)
            {
                continue;
            }
            
            var halfway = number.Length / 2;
            
            for (int j = halfway; j >= 0; j--)
            {
                if (number.Length % number.Substring(0, j+1).Length != 0 || number.Length == number.Substring(0, j+1).Length)
                {
                    continue;
                }
                
                var chunks = number.Length /  number.Substring(0, j+1).Length;
                var subStringLength = number.Substring(0, j+1).Length;
                var numberRepeats = true;
                
                for (int k = 0 ; k < chunks - 1; k++)
                {
                    if (number.Substring(k * subStringLength, subStringLength) != number.Substring((k+1) * subStringLength, subStringLength))
                    {
                        numberRepeats = false;
                        break;
                    }
                }
                
                if (numberRepeats)
                {
                    answer += i;
                    break;
                }
            }
        }
        return answer;
    }
}