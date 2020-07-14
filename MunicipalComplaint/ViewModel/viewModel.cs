using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MunicipalComplaint.Models;

namespace MunicipalComplaint.ViewModel
{
    public class viewModel
    {
        public List<CustomerSignup> signup { get; set; }
        public List<Province> provinces { get; set; }
        public List<City> cities { get; set; }
        public List<Tehsil> tehsiles { get; set; }
        public List<UC> ucs { get; set; }
    }
}