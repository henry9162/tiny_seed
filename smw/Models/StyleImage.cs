using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMW.Models.shared;
using SMW.Services.StorageService;

namespace SMW.Models
{
    public class StyleImage : FileUpload
    {
        public int Id { get; set; }
        public int StyleId { get; set; }
        public DateTime CreatedAt;
        public DateTime UpdatedAt;
    }
}