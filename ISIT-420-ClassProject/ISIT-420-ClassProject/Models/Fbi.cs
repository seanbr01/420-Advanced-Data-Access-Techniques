using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISIT_420_ClassProject.Models
{
    public class Fbi
    {
        public int ID { get; set; }
        public int YearID { get; set; }
        public int Murder { get; set; }
        public int ViolentCrime { get; set; }
        public int Rape { get; set; }
        public int Robbery { get; set; }
        public int Assault { get; set; }
        public int PropertyCrime { get; set; }
        public int Burglary { get; set; }
        public int LarcenyTheft { get; set; }
        public int MoterVehicleTheft { get; set; }
    }
}