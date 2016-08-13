using Kendo.Mvc.UI;
using PCDCRSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;

namespace PCDCRSystem.Controllers
{
    public class UsersProjectController : Controller
    {
        // GET: UsersProject  
        private ProjectControlService ProjectControlService;
        public UsersProjectController()
        {
            ProjectControlService = new ProjectControlService(new PCDCREntities());
        }
        public ActionResult UsersProject()
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                PopulateProject();
                PopulateUsers();
                return View();
            }
            
        }

       
        public void PopulateProject()
        {
            var dataContext = new PCDCREntities();
            var projects = dataContext.Projects_table
                        .Select(c => new ProjectforeignKeyViewModel
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
                        .Select(c => new userforeignKeyViewModel
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
            return Json(ProjectControlService.Readproject().ToDataSourceResult(request));
        }



        public ActionResult ProjectControl_Create([DataSourceRequest] DataSourceRequest request, ProjectControlViewModel control)
        {
            if (control != null && ModelState.IsValid)
            {
                ProjectControlService.Createproject(control);
            }

            return Json(new[] { control }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult ProjectControl_Update([DataSourceRequest] DataSourceRequest request, ProjectControlViewModel control)
        {
            if (control != null && ModelState.IsValid)
            {
                ProjectControlService.Updateproject(control);
            }

            return Json(new[] { control }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult ProjectControl_Destroy([DataSourceRequest] DataSourceRequest request, ProjectControlViewModel control)
        {
            if (control != null)
            {
                ProjectControlService.Destroyproject(control);
            }

            return Json(new[] { control }.ToDataSourceResult(request, ModelState));
        }

        public JsonResult GetProject()
        {
            return Json(ProjectControlService.ReadProject(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult getUsers()
        {
            return Json(ProjectControlService.GetUseres(), JsonRequestBehavior.AllowGet);
        }
    }
}