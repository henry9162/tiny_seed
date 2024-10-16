using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMW.Models;
using SMW.Models.shared;

namespace SMW.Services.StorageService
{
    public interface IStorageService
    {
        string ImageUploadDirectory { get; }
        string? OriginalFileName { get; set; }
        string? FileName { get; set; }
        string? FilePath { get; set; }
        long FileSize { get; set; }
        void CreateFolder(string path);
        string GetRandomFileName();
        Task<FileUpload> UploadFormFile(IFormFile file, string path = "", string dbFilePath = "");
        Task<List<T>> UploadMultipleFiles<T>(List<IFormFile> ImageFiles, string FileDirectoryName, List<string> dbFilePaths) where T : IFileUpload, new();
        bool DeleteImageFromFileDirectory(List<string>? dbFilePaths = null);
        List<string> GetDbFilePaths<T>(List<T> Images) where T : IFileUpload;
    }
}