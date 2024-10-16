using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMW.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public int GatewayRequestId { get; set; }
        public int Status { get; set; }
        public string? Description { get; set; }
        public double Amount { get; set; }
        public int CustomRequestId { get; set; }
        public CustomRequest? CustomRequest { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public DateTime CreatedAt;
        public DateTime UpdatedAt;
    }
}