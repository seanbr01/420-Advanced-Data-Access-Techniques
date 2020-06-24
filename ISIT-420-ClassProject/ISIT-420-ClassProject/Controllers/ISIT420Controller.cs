using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ISIT_420_ClassProject.Controllers
{
    public class ISIT420Controller : ApiController
    {
        ISIT420_RevisedEntities myRevisedEntities = new ISIT420_RevisedEntities();

        [Route("api/ISIT420/GetAllFbi")]
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

        [Route("api/ISIT420/GetAllCensus")]
        [HttpGet]
        public IHttpActionResult GetAllCensusRevised()
        {
            var stats = from stat in myRevisedEntities.CensusBureaux
                        from year in myRevisedEntities.Years
                        where stat.YearID == year.YearID

                        select new
                        {
                            year.Year1,
                            stat.ID,
                            year.YearID,
                            stat.Population
                        };
            return Json(stats);
        }

        [Route("api/ISIT420/GetAllYears")]
        [HttpGet]
        public IHttpActionResult GetAllYears()
        {
            var stats = from years in myRevisedEntities.Years
                        from fbi in myRevisedEntities.FBIs
                        from census in myRevisedEntities.CensusBureaux
                        where fbi.YearID == years.YearID && fbi.YearID == census.YearID

                        select new
                        {
                            years.YearID,
                            years.Year1,
                        };
            return Json(stats);
        }

        [Route("api/ISIT420/GetAllFbisAndCensus")]
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

        [Route("api/ISIT420/GetFristLast")]
        [HttpGet]
        public IHttpActionResult GetFristLast()
        {
            var stats = from fbi in myRevisedEntities.FBIs
                        from census in myRevisedEntities.CensusBureaux
                        from year in myRevisedEntities.Years
                        where fbi.YearID == year.YearID && fbi.YearID == census.YearID && year.Year1 == 2016// || year.Year1 == 2016

                        select new
                        {
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

        [Route("api/ISIT420/GetByYear/{year:int}")]
        [HttpGet]
        public IHttpActionResult GetByYear(int year)
        {
            var stats = from fbi in myRevisedEntities.FBIs
                        from census in myRevisedEntities.CensusBureaux
                        from years in myRevisedEntities.Years
                        where fbi.YearID == years.YearID && fbi.YearID == census.YearID && years.YearID == year

                        select new
                        {
                            years.Year1,
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

        [Route("api/ISIT420/GetAllPopulationVersusMurder")]
        [HttpGet]
        public IHttpActionResult GetAllPopulationVersusMurder()
        {
            var stats = from fbi in myRevisedEntities.FBIs
                        from census in myRevisedEntities.CensusBureaux
                        from year in myRevisedEntities.Years
                        where fbi.YearID == year.YearID && fbi.YearID == census.YearID

                        select new
                        {
                            year.Year1,
                            census.Population,
                            fbi.Murder,
                        };
            return Json(stats);
        }

        [Route("api/ISIT420/GetAllPopulationVersusViolentCrime")]
        [HttpGet]
        public IHttpActionResult GetAllPopulationVersusViolentCrime()
        {
            var stats = from fbi in myRevisedEntities.FBIs
                        from census in myRevisedEntities.CensusBureaux
                        from year in myRevisedEntities.Years
                        where fbi.YearID == year.YearID && fbi.YearID == census.YearID

                        select new
                        {
                            year.Year1,
                            census.Population,
                            fbi.ViolentCrime,
                        };
            return Json(stats);
        }

    }
}
