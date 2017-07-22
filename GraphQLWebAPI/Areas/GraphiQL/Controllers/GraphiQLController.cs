using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GraphQLWebAPI.Areas.GraphiQL.Controllers
{
    public class GraphiQLController : Controller
    {
        // GET: GraphiQL/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}