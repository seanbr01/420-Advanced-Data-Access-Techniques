using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ISIT_420_ClassProject.Controllers
{
    public class FbiController : ApiController
    {
        ISIT420Entities myEntities = new ISIT420Entities();
        ISIT420_RevisedEntities myRevisedEntities = new ISIT420_RevisedEntities();

        [Route("api/Fbi/GetAll")]
        [HttpGet]
        public IHttpActionResult GetAllFbis()
        {
            myEntities.Configuration.ProxyCreationEnabled = false;
            return Json(myEntities.FBIs);
        }

        [Route("api/Fbi/GetAllRevised")]
        [HttpGet]
        public IHttpActionResult GetAllFbisRevised()
        {
            var stats = from stat in myRevisedEntities.FBIs
                        from year in myRevisedEntities.Years
                        where stat.YearID == year.YearID

                        select new
                        {
                            stat.ID,
                            year.YearID,
                            year.Year1,
                            stat.Murder,
                            stat.ViolentCrime,
                            stat.Robbery,
                            stat.Assault,
                            stat.PropertyCrime,
                            stat.Burglary,
                            stat.LarcenyTheft,
                            stat.MoterVehicleTheft
                        };
            return Json(stats);
        }

        [Route("api/Fbi/GetAllFbisAndCensus")]
        [HttpGet]
        public IHttpActionResult GetAllFbisAndCensus()
        {
            var stats = from fbi in myRevisedEntities.FBIs
                        from census in myRevisedEntities.CensusBureaux
                        from year in myRevisedEntities.Years
                        where fbi.YearID == year.YearID && fbi.YearID == census.YearID

                        select new
                        {
                            fbi.ID,
                            year.YearID,
                            year.Year1,
                            census.Population,
                            fbi.Murder,
                            fbi.ViolentCrime,
                            fbi.Robbery,
                            fbi.Assault,
                            fbi.PropertyCrime,
                            fbi.Burglary,
                            fbi.LarcenyTheft,
                            fbi.MoterVehicleTheft
                        };
            return Json(stats);
        }

    }
}
