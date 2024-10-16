using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SMW.Models
{
    public class SizeChart
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int BodyHeight { get; set; } // Measure the height from the top of the head to the floor (Without shoes). The body height can be measured exactly if the client stands in front of a wall measuring strip. Mark the highest point of the head with a square
        public int ChestGirth { get; set; } // Measure the circumference over the fullest part of the bust (bust points) and across the lower part of the shoulder blades, With the measuring tape slightly lifted at the back. Take the measurement from the back of the client
        public int UnderBurstGirth_F { get; set; } // Measure the chest circumference horizontally just below the bust.
        public int WaistGirth { get; set; } // Measure the circumference at the narrowest part of the waist. Place the measuring tape horizontally around the waist. Take the measurement from the front of the client.
        public int LowerWaistGirth { get; set; } // Measure the horizontal circumference 8 cm below the waist.
        public int HipGirth_F { get; set; } // Measure the circumference over the strongest part of the seat and / or the hip. Take the measurement from the front of the client. Note any obvious figure proportions: e.g. one-sided high or strong hip, full or flat seat, and full or flat abdomen
        public int SleeveLength { get; set; } // Measure the sleeve length over the bended elbow from the shoulder tip to the wrist bone. This length can be measured at the sleeve from the sleeve cap to the hem. Add the shoulder Width to the sleeve length to determine the Kimono sleeve length
        public int ScyeDepth { get; set; } // Measure the scye depth from the vertebra (base of the neck) to the armhole depth
        public int BackWaistLength { get; set; } // Measure the back waist length from the vertebra (base of the neck) to the lower edge of the waist tape measure. Place the waist tape measure (measuring tape With hook and eye) at the narrowest part of the waist
        public int Hipdepth_F { get; set; } // Measure the hip depth from the vertebra (base of the neck) to fullest part of the hip. This measurement is  only necessary for strong hips or thighs. Use the calculated hip depth for normal figure types.
        public int BurstLength_F { get; set; } // Measure the bust length I from the vertebra (base of the neck) over the shoulder up to the bust point
        public int FrontLength_F { get; set; } // Measure the front waist length from the vertebra (base of the neck) over the shoulder and the bust point to the lower edge of the waist tape measure
        public int BackWidth { get; set; } // Measure the back Width over the lower part of the shoulder blades from arm fold to arm fold
        public int NeckWidth { get; set; } // Measure from the nape of the neck (7th cervical vertebra) horizontally to the shoulder seam
        public int ScyeWidth { get; set; } // Measure the scye width between the front and back armhole pitch line. The scye width determines the armhole width. The scye width can also be calculated.
        public int ChestWidth { get; set; } // Measure horizontally from the centre front to the beginning of the arm. The chest width can also be calculated.
        public int BicepsGirth { get; set; } // Measure the biceps horizontally around the fullest part of the upper arm
        public int ElbowLength { get; set; } // Measure the elbow length over the hanging arm from the arm head to the elbow
        public int ShoulderWidth { get; set; } // Measure the shoulder from the beginning of the neck to the beginning of the arm at the shoulder
        public int WristGirth { get; set; } // Measure the wrist circumference horizontally over the wrist bone
        public int NeckGirth { get; set; } // Measure the circumference of the neck at the transition to the upper body.
        public int BurstPointDistance_F { get; set; } // Measure horizontally from the left to the right bust point.
        public int HeadGirth { get; set; } // Measure the horizontal circumference over the fullest part of the head.
        public int KneeLength { get; set; } // Measure the finished length from the vertebra (base of the neck) to the desired length.
        public int SideLength { get; set; } // Measure vertically along the side from the waist to the floor.
        public int ThighGirth { get; set; } // Measure the thigh circumference horizontally over the fullest part of the thigh.
        public int BodyRise_F { get; set; } // Sit the client being measured on a hard chair or stool, and measure along the side from the lower edge of the waist measure tape vertically down wards to the seat of the chair.
        public int KneeBandGirth { get; set; } // Measure the circumference at the narrowest part just below the knee.
        public int CalfGirth { get; set; } // Measure the circumference over the fullest part of the calf.
        public int AnkleGirth { get; set; } // Measure the circumference over the fullest part of the ankle.
        public CustomRequest? CustomRequest { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public DateTime CreatedAt;
        public DateTime UpdatedAt;
    }
}