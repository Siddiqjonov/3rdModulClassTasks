using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFileManagement.StorageBroker.Services;

namespace WebFileManagement.Service.Services;

public class StorageService : IStorageService
{
    private IStorageBrokerService _storageBrokerService;

    public StorageService(IStorageBrokerService storageBrokerService)
    {
        _storageBrokerService = storageBrokerService;
    }

    public async Task CreateDirectoryAsync(string directoryPath)
    {
        await _storageBrokerService.CreateDirectoryAsync(directoryPath);
    }

    public async Task DeleteFileAsync(string filePath)
    {
        await _storageBrokerService.DeleteFileAsync(filePath);
    }

    public async Task DeleteDirectoryAsync(string directoryPath)
    {
        await _storageBrokerService.DeleteDirecoryAsync(directoryPath);
    }

    public async Task<Stream> DownloadFIleAsync(string filePath)
    {
        var downloadStream = await _storageBrokerService.DownloadFileAsync(filePath);
        return downloadStream;
    }

    public async Task<Stream> DownloadFolderAsZipAsync(string directoryPath)
    {
        var stream = await _storageBrokerService.DownloadFolderAsZipAsync(directoryPath);
        return stream;
    }

    public async Task<List<string>> GetAllFileAndDirectoriesAsync(string directoryPath)
    {
        var all = await _storageBrokerService.GetAllFilesAndDirectoriesAsync(directoryPath);
        return all;
    }

    public async Task UploadFileAsync(string directoryPath, Stream stream)
    {
        await _storageBrokerService.UploadFileAsync(directoryPath, stream);
    }
}
