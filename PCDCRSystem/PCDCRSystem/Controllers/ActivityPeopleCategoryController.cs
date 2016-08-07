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
    public class ActivityPeopleCategoryController : Controller
    {
        // GET: ActivityPeopleCategory
        public ActionResult PeopleCategory()
        {
            return View();
        }

      

        private ActivityPeopleCategorySerivce ActivityPeopleCategorySerivce;


        public ActivityPeopleCategoryController()
        {

            ActivityPeopleCategorySerivce = new ActivityPeopleCategorySerivce(new PCDCREntities());


        }
        public ActionResult ActivitiesCategory_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(ActivityPeopleCategorySerivce.Read().ToDataSourceResult(request));
        }


        // Insert New
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult ActivitiesCategory_Create([DataSourceRequest] DataSourceRequest request, ActivityPeopleCategoryViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                ActivityPeopleCategorySerivce.Create(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult ActivitiesCategory_Update([DataSourceRequest] DataSourceRequest request, ActivityPeopleCategoryViewModel db)
        {
            if (db != null && ModelState.IsValid)
            {
                ActivityPeopleCategorySerivce.Update(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult ActivitiesCategory_Destroy([DataSourceRequest] DataSourceRequest request, ActivityPeopleCategoryViewModel db)
        {
            if (db != null)
            {
                ActivityPeopleCategorySerivce.Destroy(db);
            }

            return Json(new[] { db }.ToDataSourceResult(request, ModelState));
        }
    }
}