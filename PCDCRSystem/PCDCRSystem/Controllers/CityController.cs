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
    public class CityController : Controller
    {
        // GET: City
        public ActionResult Cities()
        {
            PopulateProvince();
            return View();
        }

        private void PopulateProvince()
        {
            var dataContext = new PCDCREntities();
            var province = dataContext.Province_Table
                        .Select(c => new ProvinceViewModel
                        {
                            ProvinceID = c.ID,
                            ProvinceName = c.ProvinceName
                        })
                        .OrderBy(e => e.ProvinceID);

            ViewData["province"] = province;
            ViewData["defaultProvince"] = province.First();
        }

        private CtiyService CtiyService;


        public CityController()
        {

            CtiyService = new CtiyService(new PCDCREntities());


        }
        public ActionResult city_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(CtiyService.Read().ToDataSourceResult(request));
        }
     

        // Insert New
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult city_Create([DataSourceRequest] DataSourceRequest request, CtiyViewModel city)
        {
            if (city != null && ModelState.IsValid)
            {
                CtiyService.Create(city);
            }

            return Json(new[] { city }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult city_Update([DataSourceRequest] DataSourceRequest request, CtiyViewModel city)
        {
            if (city != null && ModelState.IsValid)
            {
                CtiyService.Update(city);
            }

            return Json(new[] { city }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult city_Destroy([DataSourceRequest] DataSourceRequest request, CtiyViewModel city)
        {
            if (city != null)
            {
                CtiyService.Destroy(city);
            }

            return Json(new[] { city }.ToDataSourceResult(request, ModelState));
        }

        public JsonResult GetProvince()
        {
            return Json(CtiyService.ReadProvince(), JsonRequestBehavior.AllowGet);
        }
    }
}