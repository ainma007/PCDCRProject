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
            return View();
        }

        public JsonResult AllProjects([DataSourceRequest] DataSourceRequest request)
        {
            using (PCDCREntities db = new PCDCREntities())
            {
                var q = db.Projects_table.ToList();
                return Json(q.ToDataSourceResult(request));
            }
        }


        // Insert New
        public JsonResult Create_Project([DataSourceRequest] DataSourceRequest request, Projects_table project)
        {
            using (PCDCREntities db = new PCDCREntities())
            {
                if (project != null && ModelState.IsValid)
                {
                    Projects_table p = new Projects_table();



                    p.ProjectName = project.ProjectName;
                    p.StartDate = project.StartDate;
                    p.EndDate = project.EndDate;
                    p.ProjectStatus = project.ProjectStatus;

                    p.ProgrameID = project.ProgrameID;




                    db.Projects_table.Add(p);
                    db.SaveChanges();
                    project.ID = p.ID;
                }

                return Json(new[] { project }.ToDataSourceResult(request, ModelState));
            }
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult Update_Project([DataSourceRequest] DataSourceRequest request, Projects_table project)
        {
            using (PCDCREntities db = new PCDCREntities())
            {
                if (project != null && ModelState.IsValid)
                {
                    Projects_table p = db.Projects_table.Single(c => c.ID == project.ID);

                    p.ProjectName = project.ProjectName;
                    p.StartDate = project.StartDate;
                    p.EndDate = project.EndDate;
                    p.ProjectStatus = project.ProjectStatus;

                    p.ProgrameID = project.ProgrameID;

                }
                db.SaveChanges();
                return Json(ModelState.IsValid ? true : ModelState.ToDataSourceResult());
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult Delete_Project([DataSourceRequest] DataSourceRequest request, Projects_table project)
        {
            using (PCDCREntities db = new PCDCREntities())
            {
                if (project != null && ModelState.IsValid)
                {
                    Projects_table p = db.Projects_table.Single(c => c.ID == project.ID);
                    db.Projects_table.Remove(p);
                }

                db.SaveChanges();
                return Json(ModelState.IsValid ? true : ModelState.ToDataSourceResult());
            }
        }

    }
}