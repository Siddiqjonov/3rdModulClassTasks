namespace FoldersAndFiles;

internal class Program
{
    static void Main(string[] args)
    {
        /*
        File
        FileInfo
        Directory
        DirectoryInfo
        Path
        FileStream
        StreamWriter
        StreamReader
        */
        var filePath = @"C:\Users\ACer\Downloads\Telegram Desktop\video_2025-01-10_07-51-48.mp4";
        string fileName = "file6";
        CopyFileWithChunks(filePath, fileName);
        //CopyFileAtOnce(filePath, fileName);
    }
    public static void CopyFileWithChunks(string filePath, string newFileName)
    {
        var fileExtension = Path.GetExtension(filePath);
        var destinationFilePath = Path.Combine(Directory.GetCurrentDirectory(), "data", newFileName + fileExtension);
        FileInfo fileInfo = new FileInfo(filePath);
        var size = fileInfo.Length;

        var bytes = 1024 * 1024 * 2;
        byte[] buffer = new byte[bytes];
        int bytesRead = 0;
        var bytesPercent = bytes * 100d / size;
        var percent = bytesPercent;

        using (FileStream fileStreamPath = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            using (FileStream fileDestination = new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write))
            {
                while (true)
                {
                    bytesRead = fileStreamPath.Read(buffer, 0, buffer.Length);
                    if (bytesRead <= 0) break;
                    fileDestination.Write(buffer, 0, bytesRead);
                    Console.WriteLine($"{(int)percent} % written");
                    percent += bytesPercent;

                }
            }
        }
    }
    public static void CopyFileAtOnce(string filePath, string newFileName)
    {
        var fileExtension = Path.GetExtension(filePath);
        var destinationFilePath = Path.Combine(Directory.GetCurrentDirectory(), "data", newFileName + fileExtension);
        using (FileStream fileStreamPath = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            using (FileStream fileDestination = new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write))
            {
                //fileDestination.CopyTo(fileStreamPath);
                fileStreamPath.CopyTo(fileDestination);
            }
        }
    }

    public static void InfoOfPath()
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "file.txt");
        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "data");
        //var filePathToJson = Path.Combine(Directory.GetCurrentDirectory(), "stuentInfo.json");

        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "dot net C# g10 guruh o'quvchisi Saidabror");
        }

        //if (!File.Exists(filePathToJson))
        //{
        //    File.Create(filePathToJson).Close();
        //}


        FileInfo fileInfo = new FileInfo(filePath);

        Console.WriteLine($"FIle" + Path.GetExtension(filePath));
        Console.WriteLine($"Folder" + Path.GetExtension(folderPath));
        var jsonPath = filePath.Replace("text", "json");

        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "dot net C# g10 guruh o'quvchisi Saidabror");
        }



        //fileInfo.CopyTo(filePathToJson);
    }
    public static int GetNUmber1()
    {
        return 1;
    }
    public static int GetNumber2() => 2;

    public static void InfoFileInfo()
    {
        // Working with file info

        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "test.txt");
        string qovunFilePath = Path.Combine(Directory.GetCurrentDirectory(), "qovun.txt");
        FileInfo fileInfo = new FileInfo(filePath);
        FileInfo qovunFileInfo = new FileInfo(qovunFilePath);
        if (!fileInfo.Exists)
        {
            fileInfo.Create().Close();
        }
        if (!qovunFileInfo.Exists)
        {
            qovunFileInfo.Create().Close();
        }

        //var streamWriter = fileInfo.AppendText();
        //streamWriter.Write("salom");
        //streamWriter.Write("hello");
        //streamWriter.Write("prpivat");
        //streamWriter.Close();

        fileInfo.Replace(qovunFilePath, null);

        Console.WriteLine(fileInfo.CreationTime);
        Console.WriteLine(fileInfo.CreationTimeUtc);
        Console.WriteLine(fileInfo.FullName);
        Console.WriteLine(fileInfo.Name);
        Console.WriteLine(fileInfo.Directory);
        Console.WriteLine(fileInfo.DirectoryName);
        Console.WriteLine(fileInfo.Length);
        Console.WriteLine(fileInfo.LastWriteTime);
    }
    public static void InformationDirectoryInfo()
    {
        string directoryPath = Path.Combine(Directory.GetCurrentDirectory());
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
        Console.WriteLine(Directory.GetCreationTime(directoryPath));

        DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
        Console.WriteLine(directoryInfo.CreationTime);
        Console.WriteLine(directoryInfo.Parent);
        Console.WriteLine(directoryInfo.FullName);
        Console.WriteLine(directoryInfo.LinkTarget);
        var res = directoryInfo.EnumerateFileSystemInfos();
        var res2 = directoryInfo.EnumerateFiles();
    }
}
