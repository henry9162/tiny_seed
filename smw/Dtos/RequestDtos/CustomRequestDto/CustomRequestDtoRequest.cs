using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SMW.Models;

namespace SMW.Dtos.RequestDtos.CustomRequestDto
{
    public class CustomRequestDtoRequest
    {
        [Required]
        public string? RequestId { get; set; }
        [Required]
        public int Type { get; set; } // Who is the request for, Self? or third-party?
        public string? ThirdPartyFirstName { get; set; }
        public string? ThirdPartyEmail { get; set; }
        public string? ThirdPartySex { get; set; }
        [Required]
        public int StyleId { get; set; }
        [Required]
        public int SizeChartId { get; set; }
        [Required]
        public int AddressId { get; set; }
        [Required]
        public string? UserId { get; set; }
        [Required]
        public bool ProvidedFabric { get; set; }
        [Required]
        public List<CustomRequestFabric>? CustomRequestFabrics { get; set; }
        [Required]
        public List<IFormFile>? ImageFiles { get; set; }
        public string? ClientComment { get; set; }
        public string? AdminComment { get; set; }
        public int Status { get; set; }
        public Payment? Payment { get; set; }
    }
}