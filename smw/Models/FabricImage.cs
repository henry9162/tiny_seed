using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing.Patterns;
using SMW.Models.shared;

namespace SMW.Models
{
    public class FabricImage : FileUpload
    {
        [Key]
        public int Id { get; set; }
        public int FabricId { get; set; } 
        //public Fabric? Fabric { get; set; }
        public DateTime CreatedAt;
        public DateTime UpdatedAt;
    }
}