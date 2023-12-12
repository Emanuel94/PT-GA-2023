using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaTecnicaFrontEnd.Controllers
{


    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
            
        }

        public JsonResult getArticulos ()
        {
            return new JsonResult
            {
                Data = null
            };
        }

        #region Private Methods
        

        #endregion 
    }
}