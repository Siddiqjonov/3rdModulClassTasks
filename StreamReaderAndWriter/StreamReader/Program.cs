namespace _StreamReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pathCSV = Path.Combine(Directory.GetCurrentDirectory(), "exampleCSV.csv");
            //FileCreate(pathCSV);
            string destinationFilePath = Path.Combine(Directory.GetCurrentDirectory(), "misha.txt");
            //StreamReaderInformationAppend(pathCSV, destinationFilePath);
            //StreamReaderInformation(pathCSV, destinationFilePath);
            StreamInformation(pathCSV, destinationFilePath);
        }
        public static List<int> GetNumberOfDigitsInEachLine(string path)
        {
            List<int> digits = new();
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
                    lines.Add($"{i}, Sample Name {i}, Value {i}");
                    File.WriteAllLines(path, lines);
                }
            }
        }
        public static void StreamReaderInformation(string filePath, string distinatonFilePath)
        {
            using (var streamReader = new StreamReader(filePath))
            {
                using (var streamWrite = new StreamWriter(distinatonFilePath))
                {
                    var line = string.Empty;
                    while (true)
                    {
                        line = streamReader.ReadLine();
                        if (line == null) break;
                        streamWrite.WriteLine(line);
                    }
                }
            }
        }
        public static void StreamReaderInformationAppend(string filePath, string distinatonFilePath)
        {
            using (var streamReader = new StreamReader(filePath))
            {
                using (var streamWrite = new StreamWriter(distinatonFilePath, true))
                {
                    var line = string.Empty;
                    while (true)
                    {
                        line = streamReader.ReadLine();
                        if (line == null) break;
                        streamWrite.WriteLine(line);
                    }
                }
            }
        }
        public static void StreamInformation(string filePath, string distinatonFilePath)
        {
            using (var readStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                var writeFile = new FileStream(distinatonFilePath, FileMode.Create, FileAccess.Write);

                byte[] buffer = new byte[1024];
                int byteRead;
                while ((byteRead = readStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    writeFile.Write(buffer, 0, byteRead);
                }
                writeFile.Dispose(); // using () can also be used
            }
        }
    }
}
