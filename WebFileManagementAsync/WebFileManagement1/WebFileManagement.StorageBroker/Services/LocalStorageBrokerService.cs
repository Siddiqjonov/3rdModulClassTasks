using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFileManagement.StorageBroker.Services;

public class LocalStorageBrokerService : IStorageBrokerService
{
    private string _dataPath;
    public LocalStorageBrokerService()
    {
        _dataPath = Path.Combine(Directory.GetCurrentDirectory(), "data");
        if (!Directory.Exists(_dataPath))
            Directory.CreateDirectory(_dataPath);
    }
    public async Task CreateDirectoryAsync(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);
        ValidateParent(directoryPath);
        //await Task.Delay(100);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
    }

    public async Task<Stream> DownloadFileAsync(string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);
        if (!File.Exists(filePath))
        {
            throw new Exception("File not found to download");
        }
        var streamDownload = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        return streamDownload;
    }

    public async Task<List<string>> GetAllFilesAndDirectoriesAsync(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);
        ValidateParent(directoryPath);

        var allFilesAndFolders = Directory.EnumerateFileSystemEntries(directoryPath).ToList();

        allFilesAndFolders = allFilesAndFolders.Select(name => name.Remove(0, directoryPath.Length + 1)).ToList(); // only names
        return allFilesAndFolders;

    }

    public async Task UploadFileAsync(string directoryPath, Stream stream)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);
        ValidateParent(directoryPath);
        using (var fileStream = new FileStream(directoryPath, FileMode.Create, FileAccess.Write))
        {
            await stream.CopyToAsync(fileStream);
        }
    }
    private static void ValidateParent(string directoryPath)
    {
        var parentPath = Directory.GetParent(directoryPath);

        if (!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("Folder is not available");
        }
    }

    public async Task<Stream> DownloadFolderAsZipAsync(string directoryPath)
    {
        if (Path.GetExtension(directoryPath) != string.Empty)
        {
            throw new Exception("File is given insted of folder");
        }

        directoryPath = Path.Combine(_dataPath, directoryPath);
        if (!Directory.Exists(directoryPath))
        {
            throw new Exception("Directory not found to download");
        }
        var zipPath = directoryPath + ".zip";

        ZipFile.CreateFromDirectory(directoryPath, zipPath);
        var stream = new FileStream(zipPath, FileMode.Open, FileAccess.Read);
        return stream;
    }

    public async Task DeleteFileAsync(string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);
        if (!File.Exists(filePath))
        {
            throw new Exception("File not found to delete");
        }
        File.Delete(filePath);
    }

    public async Task DeleteDirecoryAsync(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);
        if (!Directory.Exists(directoryPath))
        {
            throw new Exception("Folder not found to delete");
        }
        Directory.Delete(directoryPath, true);
    }
}
