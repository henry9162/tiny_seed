using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMW.Models;

namespace SMW.Dtos.ResponseDtos.SizeChartDto
{
    public class SizeChartResponseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int BodyHeight { get; set; } 
        public int ChestGirth { get; set; } 
        public int UnderBurstGirth_F { get; set; } 
        public int WaistGirth { get; set; } 
        public int LowerWaistGirth { get; set; } 
        public int HipGirth_F { get; set; } 
        public int SleeveLength { get; set; } 
        public int ScyeDepth { get; set; } 
        public int BackWaistLength { get; set; } 
        public int Hipdepth_F { get; set; } 
        public int BurstLength_F { get; set; } 
        public int FrontLength_F { get; set; } 
        public int BackWidth { get; set; } 
        public int NeckWidth { get; set; } 
        public int ScyeWidth { get; set; } 
        public int ChestWidth { get; set; } 
        public int BicepsGirth { get; set; } 
        public int ElbowLength { get; set; } 
        public int ShoulderWidth { get; set; } 
        public int WristGirth { get; set; } 
        public int NeckGirth { get; set; } 
        public int BurstPointDistance_F { get; set; } 
        public int HeadGirth { get; set; } 
        public int KneeLength { get; set; } 
        public int SideLength { get; set; } 
        public int ThighGirth { get; set; } 
        public int BodyRise_F { get; set; } 
        public int KneeBandGirth { get; set; } 
        public int CalfGirth { get; set; } 
        public int AnkleGirth { get; set; } 
        public ApplicationUser? User { get; set; }
    }
}