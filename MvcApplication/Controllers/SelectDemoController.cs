using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication.Models;
using System.Diagnostics;

namespace MvcApplication.Controllers
{
    public class SelectDemoController : Controller
    {
        //
        // GET: /SelectDemo/

        public ActionResult Index()
        {
            var model = new SelectDemoModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(SelectDemoModel model)
        {
            Debug.WriteLine("SelectDemoController.Index(SelectDemoModel)");
            model.Message = string.Format("ModelState.IsValid: {0}", ModelState.IsValid);

            return View(model);
        }
    }
}
