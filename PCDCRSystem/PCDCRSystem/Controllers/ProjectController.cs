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
        private UserService UserService;
        private ProjectControlService ProjectControlService;

        public ProjectController()
        {
            ProjectControlService = new ProjectControlService(new PCDCREntities());

            ProjectService = new ProjectService(new PCDCREntities());
            UserService = new UserService(new PCDCREntities());

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

        public ActionResult UserControlProject()
        {
          PopulateProject();
          PopulateUsers();
            return View();

        }

        public void PopulateProject()
        {
            var dataContext = new PCDCREntities();
            var projects = dataContext.Projects_table
                        .Select(c => new ProjectViewModel
                        {
                            ProjectID = c.ID,
                            ProjectName = c.ProjectName
                        })
                        .OrderBy(e => e.ProjectID);

            ViewData["projects"] = projects;
            ViewData["defaultProject"] = projects.First();
        }

        public void PopulateUsers()
        {
            var dataContext = new PCDCREntities();
            var users = dataContext.Users_Table
                        .Select(c => new UserViewModel
                        {
                            UserID = c.ID,
                            FullName = c.FullName
                        })
                        .OrderBy(e => e.UserID);

            ViewData["users"] = users;
            ViewData["defaultUser"] = users.First();
        }

        public ActionResult ProjectControl_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(ProjectControlService.Read().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult ProjectControl_Create([DataSourceRequest] DataSourceRequest request, ProjectControlViewModel control)
        {
            if (control != null && ModelState.IsValid)
            {
                ProjectControlService.Create(control);
            }

            return Json(new[] { control }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult ProjectControl_Update([DataSourceRequest] DataSourceRequest request, ProjectControlViewModel control)
        {
            if (control != null && ModelState.IsValid)
            {
                ProjectControlService.Update(control);
            }

            return Json(new[] { control }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult ProjectControl_Destroy([DataSourceRequest] DataSourceRequest request, ProjectControlViewModel control)
        {
            if (control != null)
            {
                ProjectControlService.Destroy(control);
            }

            return Json(new[] { control }.ToDataSourceResult(request, ModelState));
        }

        public JsonResult GetProject()
        {
            return Json(ProjectControlService.ReadProject(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult getUsers()
        {
            return Json(UserService.Read(), JsonRequestBehavior.AllowGet);
        }
    }
}