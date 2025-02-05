﻿using System;
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
        public DbSet<complains> compalin { get; set; }
        public DbSet<ContactForm> ContactMessage { get; set; }
        public DbSet<Feedback> feedback { get; set; }
        public MyDbContext(): base("MunicipalDB")
        {

        }
    }
}