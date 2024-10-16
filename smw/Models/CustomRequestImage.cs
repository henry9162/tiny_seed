using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMW.Models.shared;

namespace SMW.Models
{
    public class CustomRequestImage : FileUpload
    {
        public int Id { get; set; }
        public int CustomRequestId { get; set; }
        public CustomRequest? CustomRequest { get; set; }
        public DateTime CreatedAt;
        public DateTime UpdatedAt;
    }
}