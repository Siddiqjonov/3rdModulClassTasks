using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFileManagement.StorageBroker.Services;

public interface IStorageBrokerService
{
    Task UploadFileAsync(string directoryPath, Stream stream);
    Task CreateDirectoryAsync(string directoryPath);
    Task<List<string>> GetAllFilesAndDirectoriesAsync(string directoryPath);
    Task<Stream> DownloadFileAsync(string filePath);
    Task<Stream> DownloadFolderAsZipAsync(string directoryPaht);
    Task DeleteFileAsync(string filePath);
    Task DeleteDirecoryAsync(string directoryPath);
}
