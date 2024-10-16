using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SMW.Models.shared
{
    public class ModelTags : IModelTags
    {
        [Required]
        public int Id { get; set ; }
        public string? Name { get; set; }
        [Required]
        public double Price { get; set; }
    }
}