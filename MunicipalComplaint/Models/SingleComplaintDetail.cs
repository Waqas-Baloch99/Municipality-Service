using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MunicipalComplaint.Models
{
    public class SingleComplaintDetail
    {
        public complains complains { get; set; }
        public CustomerSignup user { get; set; }
        public City city { get; set; }
        public Feedback feedback { get; set; }
    }
}