using MunicipalComplaint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MunicipalComplaint.ViewModel
{
    public class ComplaintDistrict
    {
        public List<complains> allcomplaints { get; set; }
        public List<City> city { get; set; }
    }
}