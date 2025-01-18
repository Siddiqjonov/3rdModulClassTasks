namespace GetNumberOfDigitsInEachLine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "test.txt");
            //Console.WriteLine(path);
            FileCreate(path);
            var digits = GetNumberOfDigitsInEachLine(path);
            foreach (var digit in digits)
            {
                Console.WriteLine(digit);
            }
            File.Delete(path);
        }
        public static List<int> GetNumberOfDigitsInEachLine(string path)
        {
            List<int> digits = new ();
            using (var streamReader = new StreamReader(path))
            {
                string? line = string.Empty;
                while (true)
                {
                    line = streamReader.ReadLine();
                    if (line is null) break;
                    int digit = line.Count(chrt => char.IsDigit(chrt));
                    digits.Add(digit);
                }
            }
            return digits;
        }
        private static void FileCreate(string path)
        {
            if (!File.Exists(path))
            {
                List<string> lines = new();
                Random random = new Random();
                for (int i = 1; i <= 10; i++)
                {
                    lines.Add($"this is line number {random.Next(0, 1999999)}");
                    File.WriteAllLines(path, lines);
                }
                
            }
        }
    }
}
