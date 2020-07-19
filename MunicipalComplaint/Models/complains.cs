using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MunicipalComplaint.Models
{
    public class complains
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int ComplainId { get; set; }
        [Required]
        public string Title { get; set; }
        public string ComplainType { get; set; }
        public string Description { get; set; }
        public int DistrictId { get; set; }
        public int TownId { get; set; }
        public string AdminMessage { get; set; }
        public string createdat { get; set; } 
        public string ImagePath { get; set; }
        public int Status { get; set; }
        public int isvalid { get; set; }
        [NotMapped]

        public HttpPostedFileBase ImageFile { get; set; }
        public string closeDate { get; set; }
        public int UserId { get; set; }
    }
}