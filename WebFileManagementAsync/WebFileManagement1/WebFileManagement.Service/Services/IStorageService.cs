namespace WebFileManagement.Service.Services;

public interface IStorageService
{
    Task UploadFileAsync(string directoryPath, Stream stream);
    Task CreateDirectoryAsync(string directoryPath);
    Task<List<string>> GetAllFileAndDirectoriesAsync(string directoryPath);
    Task<Stream> DownloadFIleAsync(string filePath);
    Task<Stream> DownloadFolderAsZipAsync(string directoryPath);
    Task DeleteFileAsync(string filePath);
    Task DeleteDirectoryAsync(string directoryPath);
}