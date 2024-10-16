using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SMW.Models
{
    public class Fabric
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; } 
        public List<FabricImage>? FabricImages { get; set; }
        public double Price { get; set; }
        public string? Colors { get; set; }
        public int? FabricSubCategoryId { get; set; }
        public FabricSubCategory? FabricSubCategory { get; set; }
        public List<CustomRequestFabric>? CustomRequestFabrics { get; set; }
        public DateTime CreatedAt;
        public DateTime UpdatedAt;
    }
}