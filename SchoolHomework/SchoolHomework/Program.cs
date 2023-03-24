using System;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string pattern = Console.ReadLine();

        bool shaken = false;
        int count = 0;

        while (true)
        {
            int firstIndex = input.IndexOf(pattern);
            int lastIndex = input.LastIndexOf(pattern);

            if (firstIndex == -1 || lastIndex == -1 || firstIndex == lastIndex)
            {
                break;
            }

            shaken = true;
            input = input.Remove(lastIndex, pattern.Length);
            input = input.Remove(firstIndex, pattern.Length);

            int midIndex = pattern.Length / 2;
            pattern = pattern.Remove(midIndex, 1);

            count++;
        }

        if (shaken)
        {
            Console.WriteLine("Shaked it.");
            Console.WriteLine($"Shaked {count} times.");
        }
        else
        {
            Console.WriteLine("No shake.");
        }

        Console.WriteLine(input);
    }
}
