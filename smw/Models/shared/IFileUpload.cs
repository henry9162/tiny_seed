using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMW.Models.shared
{
    public interface IFileUpload
    {
        string? FilePath { get; set; }
        string? FileName { get; set; }
        string? OriginalFileName { get; set; }
        long FileSize { get; set; }
    }
}