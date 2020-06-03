using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ISIT_420_ClassProject.Controllers
{
    public class CensusController : ApiController
    {
        ISIT420Entities myEntities = new ISIT420Entities();

        [Route("api/Census/GetAll")]
        [HttpGet]
        public IHttpActionResult GetAllCensus()
        {
            //var stats = from stat in myEntities.CensusBureaux
            //            select new
            //            {
            //                stat.ID,
            //                stat.Year,
            //                stat.Population
            //            };
            //return Json(stats);

            myEntities.Configuration.ProxyCreationEnabled = false;
            return Json(myEntities.CensusBureaux);
        }
    }
}
