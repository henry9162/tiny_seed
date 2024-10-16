using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SMW.Utilities;

namespace SMW.Dtos.RequestDtos
{
    public class RegisterRequestDto
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required, EmailAddress]
        public string? Email { get; set; }
        [Required]
        public int UserType { get; set; }
        [Required]
        public string? Password { get; set; }
        [JsonIgnore]
        public string? UserName 
        { 
            get
            {
                return Email;
            } 
        } 

        [JsonIgnore]
        public string? EmailConfirmationToken 
        {
            get
            {
                return RandomString.GenerateRandomString(40);
            }
        }
    }
}