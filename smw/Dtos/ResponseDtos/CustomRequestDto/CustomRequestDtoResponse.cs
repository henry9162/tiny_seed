using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMW.Models;

namespace SMW.Dtos.ResponseDtos.CustomRequestDto
{
    public class CustomRequestDtoResponse
    {
        public int Id { get; set; }
        public string? RequestId { get; set; }
        public int Type { get; set; } // Who is the request for, Self? or third-party?
        public string? ThirdPartyFirstName { get; set; }
        public string? ThirdPartyEmail { get; set; }
        public string? ThirdPartySex { get; set; }
        public Style? Style { get; set; }
        public int SizeChartId { get; set; }
        public SizeChart? SizeChart { get; set; }
        public bool ProvidedFabric { get; set; }
        public List<CustomRequestFabric>? CustomRequestFabrics { get; set; }
        public List<CustomRequestImage>? CustomRequestImages { get; set; }
        public string? ClientComment { get; set; }
        public string? AdminComment { get; set; }
        public int Status { get; set; }
        public double TotalAmount { get; set; }
        public Payment? Payment { get; set; }
        public Address? Address { get; set; }
        public ApplicationUser? User { get; set; }
    }
}