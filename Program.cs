namespace CSharp17._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "numbers.txt");

            if (!File.Exists(filePath))
            {
                string defaultText = "12 -34 56 -78 90 -123 45 -67 89 10 -11";
                File.WriteAllText(filePath, defaultText);
            }

            string text = File.ReadAllText(filePath);

            List<int> numbers = text.Split(' ')
                                    .Where(s => int.TryParse(s, out _))
                                    .Select(int.Parse)
                                    .ToList();

            List<int> positiveNumbers = numbers.Where(n => n > 0)
                                               .OrderBy(n => n)
                                               .ToList();

            Console.WriteLine("Positive numbers sorted in ascending order:");
            foreach (int number in positiveNumbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
