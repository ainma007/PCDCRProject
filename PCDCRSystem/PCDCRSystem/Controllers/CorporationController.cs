using Kendo.Mvc.UI;
using PCDCRSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;

namespace PCDCRSystem.Controllers
{
    public class CorporationController : Controller
    {
        // GET: Corporation
        public ActionResult Corporation()
        {
            return View();
        }

        private CorporationService CorporationService;


        public CorporationController()
        {

            CorporationService = new CorporationService(new PCDCREntities());


        }
        public ActionResult Corporation_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(CorporationService.Read().ToDataSourceResult(request));
        }


        // Insert New
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Corporation_Create([DataSourceRequest] DataSourceRequest request, CorporationViewModel Corp)
        {
            if (Corp != null && ModelState.IsValid)
            {
                CorporationService.Create(Corp);
            }

            return Json(new[] { Corp }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Corporation_Update([DataSourceRequest] DataSourceRequest request, CorporationViewModel Corp)
        {
            if (Corp != null && ModelState.IsValid)
            {
                CorporationService.Update(Corp);
            }

            return Json(new[] { Corp }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Corporation_Destroy([DataSourceRequest] DataSourceRequest request, CorporationViewModel Corp)
        {
            if (Corp != null)
            {
                CorporationService.Destroy(Corp);
            }

            return Json(new[] { Corp }.ToDataSourceResult(request, ModelState));
        }
    }
}