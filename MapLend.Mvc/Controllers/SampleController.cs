using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MapLend.Mvc.Infrastructure;

namespace MapLend.Mvc.Controllers
{
    [Authorize]
    public class SampleController : MapControllerBase
    {
        // GET: Sample
        public string Index()
        {
            return CurrentUser.Username;
        }
    }
}