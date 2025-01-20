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

    public void CreateDirectory(string directoryPath)
    {
        _storageBrokerService.CreateDirectory(directoryPath);
    }

    public void DeleteFile(string filePath)
    {
        _storageBrokerService.DeleteFile(filePath);
    }

    public void DeleteDirectory(string directoryPath)
    {
        _storageBrokerService.DeleteDirecory(directoryPath);
    }

    public Stream DownloadFIle(string filePath)
    {
        var downloadStream = _storageBrokerService.DownloadFile(filePath);
        return downloadStream;
    }

    public Stream DownloadFolderAsZip(string directoryPath)
    {
        var stream = _storageBrokerService.DownloadFolderAsZip(directoryPath);
        return stream;
    }

    public List<string> GetAllFileAndDirectories(string directoryPath)
    {
        var all = _storageBrokerService.GetAllFilesAndDirectories(directoryPath);
        return all;
    }

    public void UploadFile(string directoryPath, Stream stream)
    {
        _storageBrokerService.UploadFile(directoryPath, stream);
    }
}
