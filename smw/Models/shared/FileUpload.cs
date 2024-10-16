using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMW.Models.shared
{
    public class FileUpload : IFileUpload
    {
        public string? FilePath { get; set; }
        public string? FileName { get; set; }
        public string? OriginalFileName { get; set; }
        public long FileSize { get; set; }
    }
}