using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMW.Models
{
    public class CustomRequest
    {
        // - Remember to factor in delivery address and delivery amount computation
        // - Remember to factor in fitting schedule and verification
        // - Remeber to factor in minimum quantity per yard for fabric length

        [Key]
        public int Id { get; set; }
        public string? RequestId { get; set; }
        public int Type { get; set; } // Who is the request for, Self? or third-party?
        public string? ThirdPartyFirstName { get; set; }
        public string? ThirdPartyEmail { get; set; }
        public string? ThirdPartySex { get; set; }
        public int StyleId { get; set; }
        public Style? Style { get; set; }
        public int SizeChartId { get; set; }
        public SizeChart? SizeChart { get; set; }
        public bool ProvidedFabric { get; set; }
        public List<CustomRequestFabric>? CustomRequestFabrics { get; set; }
        public List<CustomRequestImage>? CustomRequestImages { get; set; }
        public string? ClientComment { get; set; }
        public string? AdminComment { get; set; }
        public int Status { get; set; }
        public double PickUpAmount { get; set; }
        public double DeliveryAmount { get; set; }
        public double TotalAmount { get; set; }
        public Payment? Payment { get; set; }
        public int AddressId { get; set; }
        public Address? Address { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public DateTime CreatedAt;
        public DateTime UpdatedAt;
    }
}