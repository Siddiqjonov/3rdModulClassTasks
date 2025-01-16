namespace NumberOfDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\ACer\Downloads\Telegram Desktop\testTXT.txt";
            var digits = GetNumberOfDigits(filePath);
            foreach (var digit in digits)
            {
                Console.WriteLine(digit);
            }

        }

        public static List<int> GetNumberOfDigits(string filePath)
        {
            List<int> ints = new List<int>();
            using (StreamReader streamReader = new(filePath))
            {
                string? line = string.Empty;
                while (true)
                {
                    line = streamReader.ReadLine();
                    if (line == null) break;
                    int count = line.Count(character => char.IsDigit(character));
                    ints.Add(count);
                }

            }
            return ints;
        }
    }
}
