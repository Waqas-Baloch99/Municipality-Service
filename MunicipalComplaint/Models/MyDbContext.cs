using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MunicipalComplaint.Models
{
    public class MyDbContext:DbContext
    {
        public DbSet<CustomerSignup> customer { get; set; }
        public DbSet<Province> province { get; set; }
        public DbSet<City> city { get; set; }
        public DbSet<Tehsil> tehsil { get; set; }
        public DbSet<UC> uc { get; set; }
        public MyDbContext(): base("MunicipalDB")
        {

        }
    }
}