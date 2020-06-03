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

        [Route("api/Fbi/GetAll")]
        [HttpGet]
        public IHttpActionResult GetAllFbis()
        {
            myEntities.Configuration.ProxyCreationEnabled = false;
            return Json(myEntities.FBIs);
        }
    }
}
