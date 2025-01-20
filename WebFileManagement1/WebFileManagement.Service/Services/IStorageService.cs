namespace WebFileManagement.Service.Services;

public interface IStorageService
{
    void UploadFile(string directoryPath, Stream stream);
    void CreateDirectory(string directoryPath);
    List<string> GetAllFileAndDirectories(string directoryPath);
    Stream DownloadFIle(string filePath);
    Stream DownloadFolderAsZip(string directoryPath);
    void DeleteFile(string filePath);
    void DeleteDirectory(string directoryPath);
}