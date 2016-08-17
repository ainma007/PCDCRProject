using Kendo.Mvc.UI;
using PCDCRSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;


using PCDCRSystem.Models;
using Kendo.Mvc.UI;

namespace PCDCRSystem.Controllers
{
    public class HomeController : Controller
    {

    
        public ActionResult Index()
        {
            PopulatePrograms();
            return View();
        }

        private ProjectControlService ProjectControlService;
        private ProjectService ProjectService;
        public HomeController()
        {
            ProjectControlService = new ProjectControlService(new PCDCREntities());
            ProjectService = new ProjectService(new PCDCREntities());
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
        public ActionResult Project_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(ProjectService.Read().ToDataSourceResult(request));
        }


        public ActionResult ProjectControl_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(ProjectControlService.ReadprojectForUser().Where(u => u.MYUserID==int.Parse(Session["UserID"].ToString())).ToDataSourceResult(request));
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

      
    }
}
