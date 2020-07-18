using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MunicipalComplaint.Models
{
    public class UC
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int UcId { get; set; }

        [Required]
        public string UCName { get; set; }
        public int TehsilId { get; set; }
    }
}