using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MunicipalComplaint.Models
{
    public class CustomerSignup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string CNIC { get; set; }

        [Required]
        public string Address { get; set; }
        [Required]
        public string Contact { get; set; }
        
        public string DOB { get; set; }
        
        public string Gender { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Type { get; set; }        
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileWrapper ImageFile { get; set; }
        public int DistrictId { get; set; }
        public string Status { get; set; }
        public string createdat { get; set; }
        public string createdby { get; set; }
        public string updatedat { get; set; }
        public string updatedby { get; set; }
    }
}