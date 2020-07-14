using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MunicipalComplaint.Models
{
    public class Tehsil
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int TehsilId { get; set; }

        [Required]
        public string TehsilName { get; set; }
        public int DistrictId { get; set; }
    }
}