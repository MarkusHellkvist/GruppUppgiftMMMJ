//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class CarSale
    {
        public int carsales_id { get; set; }
        public int country_id { get; set; }
        public string country_name { get; set; }
        public System.DateTime date { get; set; }
        public int year_no { get; set; }
        public int month_no { get; set; }
        public string month_name { get; set; }
        public string quarter { get; set; }
        public Nullable<int> electric { get; set; }
        public int hybrids { get; set; }
        public Nullable<int> liquid_fuel { get; set; }
        public int total { get; set; }
        public Nullable<int> avg_CO2 { get; set; }
    
        public virtual Country Country { get; set; }
    }
}
