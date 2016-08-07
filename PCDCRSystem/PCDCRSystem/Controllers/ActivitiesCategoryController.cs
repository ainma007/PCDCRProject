using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using PCDCRSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCDCRSystem.Controllers
{
    public class ActivitiesCategoryController : Controller
    {
        // GET: ActivitiesCategory
        public ActionResult ActivitiesCategory()
        {
            return View();
        }

        private ActivitiesCategoryService ActivitiesCategoryService;


        public ActivitiesCategoryController()
        {

            ActivitiesCategoryService = new ActivitiesCategoryService(new PCDCREntities());


        }
        public ActionResult ActivitiesCategory_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(ActivitiesCategoryService.Read().ToDataSourceResult(request));
        }


        // Insert New
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult ActivitiesCategory_Create([DataSourceRequest] DataSourceRequest request, ActivitiesCategoryViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                ActivitiesCategoryService.Create(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult ActivitiesCategory_Update([DataSourceRequest] DataSourceRequest request, ActivitiesCategoryViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                ActivitiesCategoryService.Update(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult ActivitiesCategory_Destroy([DataSourceRequest] DataSourceRequest request, ActivitiesCategoryViewModel db)
        {
            if (db != null)
            {
                ActivitiesCategoryService.Destroy(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }
    }
}