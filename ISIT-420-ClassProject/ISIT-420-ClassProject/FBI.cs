//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ISIT_420_ClassProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class FBI
    {
        public int ID { get; set; }
        public int YearID { get; set; }
        public int ViolentCrime { get; set; }
        public int Murder { get; set; }
        public int Rape { get; set; }
        public int Robbery { get; set; }
        public int Assault { get; set; }
        public int PropertyCrime { get; set; }
        public int Burglary { get; set; }
        public int LarcenyTheft { get; set; }
        public int MoterVehicleTheft { get; set; }
    
        public virtual Year Year { get; set; }
    }
}
