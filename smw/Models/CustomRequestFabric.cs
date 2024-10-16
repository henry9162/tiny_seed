using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMW.Models
{
    public class CustomRequestFabric
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public int FabricId { get; set; }
        public Fabric? Fabric { get; set; }
        public DateTime CreatedAt;
        public DateTime UpdatedAt;
    }
}