class Program
{
    static void Main()
    {
        string path = "D:\\KT14_1.txt";
        string text = File.ReadAllText(path);

        string lower = text.ToLower();
        string trimmed = lower.Trim();
        var words = trimmed.Split(' ');

        Dictionary<string, int> frequency = new Dictionary<string, int>();

        foreach (var word in words)
        {
            if (frequency.ContainsKey(word))
                frequency[word]++;
            else
                frequency[word] = 1;
        }
        var sorted = frequency.OrderByDescending(p => p.Value);

        foreach (var pair in sorted)
        {
            Console.WriteLine($"{pair.Key} — {pair.Value}");
        }
    }
}
