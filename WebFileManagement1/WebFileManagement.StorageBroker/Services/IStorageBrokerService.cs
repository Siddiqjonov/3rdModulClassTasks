using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFileManagement.StorageBroker.Services;

public interface IStorageBrokerService
{
    void UploadFile(string directoryPath, Stream stream);
    void CreateDirectory(string directoryPath);
    List<string> GetAllFilesAndDirectories(string directoryPath);
    Stream DownloadFile(string filePath);
    Stream DownloadFolderAsZip(string directoryPaht);
    void DeleteFile(string filePath);
    void DeleteDirecory(string directoryPath);
}
