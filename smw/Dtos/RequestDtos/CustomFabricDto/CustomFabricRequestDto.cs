using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMW.Dtos.RequestDtos.CustomFabricDto
{
    public class CustomFabricRequestDto
    {
        [Required]
        public int Quantity { get; set; } // Yards
        [Required]
        public double UnitPrice { get; set; }
        
        public double Amount 
        { 
            get 
            {
                return UnitPrice * Quantity; 
            }
        }

        [Required]
        public int FabricId { get; set; }
    }
}