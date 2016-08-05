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
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult ProjectManagement()
        {
             PopulatePrograms();
            return View();
           
        }
        private void PopulatePrograms()
        {
            var dataContext = new PCDCREntities();
            var programs = dataContext.Programs_Table
                        .Select(c => new ProgramsViewModel
                        {
                            ProgramID = c.ID,
                            ProgramName = c.ProgramName
                        })
                        .OrderBy(e => e.ProgramID);

            ViewData["programs"] = programs;
            ViewData["defaultProgram"] = programs.First();
        }
        private ProjectService ProjectService;
     

        public ProjectController()
        {

            ProjectService = new ProjectService(new PCDCREntities());
       

        }
        public ActionResult Project_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(ProjectService.Read().ToDataSourceResult(request));
        }
        public JsonResult GetPrograms()
        {
            return Json(ProjectService.ReadPrograms(), JsonRequestBehavior.AllowGet);
        }

        // Insert New
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult EditingInline_Create([DataSourceRequest] DataSourceRequest request, ProjectViewModel product)
        {
            if (product != null && ModelState.IsValid)
            {
                ProjectService.Create(product);
            }

            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult EditingInline_Update([DataSourceRequest] DataSourceRequest request, ProjectViewModel product)
        {
            if (product != null && ModelState.IsValid)
            {
                ProjectService.Update(product);
            }

            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        
        public ActionResult EditingInline_Destroy([DataSourceRequest] DataSourceRequest request, ProjectViewModel project)
        {
            if (project != null)
            {
                ProjectService.Destroy(project);
            }

            return Json(new[] { project }.ToDataSourceResult(request, ModelState));
        }

        /// <summary>
        /// Project Control
        /// التحكم في مستخدمين المشاريع
        /// </summary>
        /// <returns></returns>

     
    }
}