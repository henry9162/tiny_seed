using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SMW.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class FabricCategory
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<FabricSubCategory>? FabricSubCategories { get; set; }
        public DateTime CreatedAt;
        public DateTime UpdatedAt;
    }
}