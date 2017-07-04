﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace blog.Models
{
    public class OdeToFoodDb : DbContext
    {
        public OdeToFoodDb() : base("name = DefaultConnection")
        {

        }
        public DbSet<Restuarant> Restuarants { get; set; }
        public DbSet<RestaurantReview> Reviews { get; set; }
    }
}