class Program
{
    static void Main()
    {
        Dictionary<string, string> capitals = new Dictionary<string, string>
        {
            { "Россия", "Москва" },
            { "США", "Вашингтон" },
            { "Франция", "Париж" },
            { "Германия", "Берлин" },
            { "Япония", "Токио" }
        };

        Dictionary<string, int> population = new Dictionary<string, int>
        {
            { "Россия", 146 },
            { "США", 331 },
            { "Франция", 67 },
            { "Германия", 83 },
            { "Япония", 126 }
        };

        Console.WriteLine("Введите название страны:");
        string country = Console.ReadLine();

        if (capitals.ContainsKey(country) && population.ContainsKey(country))
        {
            Console.WriteLine($"Столица: {capitals[country]}");
            Console.WriteLine($"Население: {population[country]} млн человек");
        }
        else
        {
            Console.WriteLine("Информация о такой стране отсутствует.");
        }
    }
}
