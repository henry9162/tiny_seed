using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMW.Models;
using SMW.Models.shared;
using SMW.Services.StyleService;

namespace SMW.Services.StorageService
{
    public class StorageService : IStorageService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IHttpContextAccessor _httpContext;

        public StorageService(IHttpContextAccessor httpContext, IWebHostEnvironment environment)
        {
            _httpContext = httpContext;
            _environment = environment;
            if (!Directory.Exists(ImageUploadDirectory))
                CreateFolder("");
        }

        public string WebRoot => string.IsNullOrEmpty(_environment.WebRootPath) ? _environment.WebRootPath : _environment.WebRootPath.Replace("\\", "/");

        public string ContentRootPath => string.IsNullOrEmpty(_environment.ContentRootPath) ? _environment.ContentRootPath : _environment.ContentRootPath.Replace("\\", "/");

        public string ImageUploadDirectory
        {
            get
            {
                var path = WebRoot ?? Path.Combine(ContentRootPath, "wwwroot");
                
                path = Path.Combine(path, "images");

                return path;
            }
        }

        public string? OriginalFileName { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public long FileSize { get; set; }

        readonly string separator = "/"; //readonly string _separator = Path.DirectorySeparatorChar.ToString();

        public async Task<FileUpload> UploadFormFile(IFormFile file, string path = "", string dbFilePath = "")
        {
            CreateFolder(path);

            var fileName = GetRandomFileName() + GetFileExtension(file.FileName); // System.IO.Path.GetExtension(file.FileName);
            var filePath = string.IsNullOrEmpty(path)
                ? Path.Combine(ImageUploadDirectory, fileName)
                : Path.Combine(ImageUploadDirectory, path + separator + fileName);

            filePath = filePath.Replace("\\", "/");

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);

                return new FileUpload
                {
                    OriginalFileName = file.FileName,
                    FileName = fileName,
                    FilePath = TrimFilePath(filePath),
                    FileSize = file.Length,
                };
            }
        }

        public async Task<List<T>> UploadMultipleFiles<T>(List<IFormFile> ImageFiles, string FileDirectoryName, List<string> dbFilePaths) where T : IFileUpload, new()
        {
            List<T> fileUploads = new List<T>(ImageFiles.Count);

            DeleteImageFromFileDirectory(dbFilePaths);

            for (int i = 0; i < ImageFiles.Count; i++)
            {
                var file = ImageFiles![i];
                FileUpload fileUpload = await UploadFormFile(file, FileDirectoryName);

                if(fileUpload is null)
                    throw new ArgumentException("fileUpload cannot be null, please check image size and type, then try again");

                fileUploads.Add(new T
                {
                    OriginalFileName = fileUpload.OriginalFileName!,
                    FileName = fileUpload.FileName!,
                    FilePath = fileUpload.FilePath!,
                    FileSize = file.Length,
                });
            }

            return fileUploads;
        }

        public bool DeleteImageFromFileDirectory(List<string>? dbFilePaths)
        {
            try
            {
                if(dbFilePaths != null && dbFilePaths.Count > 0){
                    foreach(var dbFilePath in dbFilePaths){
                        if (!string.IsNullOrEmpty(dbFilePath)){
                            var dbFile = Path.Combine(WebRoot, dbFilePath.Substring(1)); //removes the first back slash from the path.

                            if (File.Exists(dbFile))
                                File.Delete(dbFile);
                        }
                    }
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<string> GetDbFilePaths<T>(List<T> Images) where T : IFileUpload
        {
            var dbPaths = new List<string>();

            foreach (var image in Images){
                dbPaths.Add(image.FilePath!);
            }

            return dbPaths;
        }

        public void CreateFolder(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                Directory.CreateDirectory(ImageUploadDirectory);
            } 
            else 
            {
                var dir = Path.Combine(ImageUploadDirectory, path);
                dir = dir.Replace("/", separator);

                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
            }
        }

        public string GetRandomFileName()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", "");
            return path;
        }

        public string TrimFilePath(string path)
        {
            var p = path.Replace(WebRoot, "");
            if (p.StartsWith("\\")) p = p.Substring(1);
            return p;
        }

        public string GetFileExtension(string fileName)
        {
            string[] parts = fileName.Split(".");
            string extension = parts[parts.Length - 1];
            
            if (extension.StartsWith("png", StringComparison.OrdinalIgnoreCase)
                || extension.StartsWith("jpeg", StringComparison.OrdinalIgnoreCase)
                || extension.StartsWith("jpg", StringComparison.OrdinalIgnoreCase))

                return "." + extension;
            else
            {
                throw new Exception("For security reasons it is not allowed to upload files other than png or jpeg");
            }
        }
    }
}