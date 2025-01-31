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
        public async Task CreateFolder(string directoryPath)
        {
            await _storageService.CreateDirectoryAsync(directoryPath);
        }
        [HttpPost("uploadFile")]
        public async Task UploadFile(string? folderPath, IFormFile file)
        {
            folderPath = folderPath ?? string.Empty;
            if (file is null || string.IsNullOrEmpty(file.FileName))
            {
                throw new Exception("Folder is empty");
            }
            folderPath = Path.Combine(folderPath, file.FileName);
            using (var stream = file.OpenReadStream())
            {
                await _storageService.UploadFileAsync(folderPath, stream);
            }
        }
        [HttpPost("uploadFiles")]
        public async Task UploadFiles(string? folderPath, List<IFormFile> files)
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
                    await _storageService.UploadFileAsync(folderPath, stream);
                }
            }
        }
        [HttpGet("getAll")]
        public async Task<List<string>> GetAll(string? directoryPath)
        {
            directoryPath = directoryPath ?? string.Empty;
            var all = await _storageService.GetAllFileAndDirectoriesAsync(directoryPath);
            return all;
        }
        [HttpGet("downloadFile")]
        public async Task<FileStreamResult> DownloadFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new Exception("Error");
            }
            var fileName = Path.GetFileName(filePath);

            var stream = await _storageService.DownloadFIleAsync(filePath);


            var result = new FileStreamResult(stream, "application/octet-stream") // contentType is needed to understand file type like: pdf, txt, mp3, mp4. Is it a video, photo, music or smth else
            {
                FileDownloadName = fileName,
            };
            

            return result;
        }
        [HttpGet("downloadFolderAsZip")]
        public async Task<FileStreamResult> DownloadFoldersAsZip(string directoryPath) // IActionResult can return any type
        {
            if (string.IsNullOrEmpty(directoryPath))
            {
                throw new Exception("Erroe");
            }

            var directoryName = Path.GetFileName(directoryPath);

            var stream = await _storageService.DownloadFolderAsZipAsync(directoryPath);

            var result = new FileStreamResult(stream, "application/octet-stream")
            {
                FileDownloadName = directoryName + ".zip",
            };
            return result;
        }
        [HttpDelete("deleteFile")]
        public async Task DeleteFile(string filePath)
        {
            await _storageService.DeleteFileAsync(filePath);
        }
        [HttpDelete("deleteFolder")]
        public async Task DeleteFolders(string directoryPath)
        {
            await _storageService.DeleteDirectoryAsync(directoryPath);
        }
    }
}
