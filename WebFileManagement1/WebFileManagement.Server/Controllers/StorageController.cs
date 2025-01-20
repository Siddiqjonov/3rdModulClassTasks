using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebFileManagement.Service.Services;

namespace WebFileManagement.Server.Controllers
{
    [Route("api/storage")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private IStorageService _storageService;

        public StorageController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpPost("createFolder")]
        public void CreateFolder(string directoryPath)
        {
            _storageService.CreateDirectory(directoryPath);
        }
        [HttpPost("uploadFile")]
        public void UploadFile(string? folderPath, IFormFile file)
        {
            folderPath = folderPath ?? string.Empty;
            if (file is null || string.IsNullOrEmpty(file.FileName))
            {
                throw new Exception("Folder is empty");
            }
            folderPath = Path.Combine(folderPath, file.FileName);
            using (var stream = file.OpenReadStream())
            {
                _storageService.UploadFile(folderPath, stream);
            }
        }
        [HttpPost("uploadFiles")]
        public void UploadFiles(string? folderPath, List<IFormFile> files)
        {
            //folderPath = folderPath ?? string.Empty;
            folderPath ??= string.Empty;
            var mainPath = folderPath;
            if (files is null || files.Count == 0)
            {
                throw new Exception("Folder is empty");
            }
            foreach (var file in files)
            {
                folderPath = Path.Combine(mainPath, file.FileName);
                using (var stream = file.OpenReadStream())
                {
                    _storageService.UploadFile(folderPath, stream);
                }
            }
        }
        [HttpGet("getAll")]
        public List<string> GetAll(string? directoryPath)
        {
            directoryPath = directoryPath ?? string.Empty;
            var all = _storageService.GetAllFileAndDirectories(directoryPath);
            return all;
        }
        [HttpGet("downloadFile")]
        public FileStreamResult DownloadFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new Exception("Error");
            }
            var fileName = Path.GetFileName(filePath);

            var stream = _storageService.DownloadFIle(filePath);


            var result = new FileStreamResult(stream, "application/octet-stream") // contentType is needed to understand file type like: pdf, txt, mp3, mp4. Is it a video, photo, music or smth else
            {
                FileDownloadName = fileName,
            };
            

            return result;
        }
        [HttpGet("downloadFolderAsZip")]
        public FileStreamResult DownloadFoldersAsZip(string directoryPath) // IActionResult can return any type
        {
            if (string.IsNullOrEmpty(directoryPath))
            {
                throw new Exception("Erroe");
            }

            var directoryName = Path.GetFileName(directoryPath);

            var stream = _storageService.DownloadFolderAsZip(directoryPath);

            var result = new FileStreamResult(stream, "application/octet-stream")
            {
                FileDownloadName = directoryName + ".zip",
            };
            return result;
        }
        [HttpDelete("deleteFile")]
        public void DeleteFile(string filePath)
        {
            _storageService.DeleteFile(filePath);
        }
        [HttpDelete("deleteFolder")]
        public void DeleteFolders(string directoryPath)
        {
            _storageService.DeleteDirectory(directoryPath);
        }
    }
}
