﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GruppuppgiftMMMJ
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CarsDWEntities : DbContext
    {
        public CarsDWEntities()
            : base("name=CarsDWEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Avg_Salary> Avg_Salary { get; set; }
        public virtual DbSet<CarSale> CarSales { get; set; }
        public virtual DbSet<ChargingPoint> ChargingPoints { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<GasPrice> GasPrices { get; set; }
        public virtual DbSet<MarketEvent> MarketEvents { get; set; }
        public virtual DbSet<BigView> BigViews { get; set; }
    }
}
