using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMW.Models;

namespace SMW.Dtos.ResponseDtos.CustomFabricDto
{
    public class CustomFabricResponseDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Amount { get; set; }
        public Fabric? Fabric { get; set; }
        public List<CustomRequest>? CustomRequests { get; set; }
    }
}