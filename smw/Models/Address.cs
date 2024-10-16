using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMW.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? StreetName { get; set; }
        public int StreetNumber { get; set; }
        public int StateId { get; set; }
        public State? State { get; set; }
        public int? LocalGovernmentId { get; set; } 
        //Used nullable int? on the foreign key to prevent cylcles/multiple cascade paths since states also has localgovernment relationship
        public LocalGovernment? LocalGovernment { get; set; }
        public CustomRequest? CustomRequest { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public DateTime CreatedAt;
        public DateTime UpdatedAt;
    }
}