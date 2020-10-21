using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Mono.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Mono.Context
{
    public class VehicleModelContext:DbContext
    {
        public VehicleModelContext() :base ("VehicleModelContextDB")
        {

        }

        public DbSet<VehicleMake> Makes { get; set; }
        public DbSet<VehicleModel> Models { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}