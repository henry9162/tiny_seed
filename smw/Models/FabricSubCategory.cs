using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SMW.Models.shared;

namespace SMW.Models
{
    public class FabricSubCategory : ModelTags
    {
        public int FabricCategoryId { get; set; }
        public FabricCategory? FabricCategory { get; set; }
        public List<Fabric>? Fabrics { get; set; }
        public DateTime CreatedAt;
        public DateTime UpdatedAt;
    }
}
