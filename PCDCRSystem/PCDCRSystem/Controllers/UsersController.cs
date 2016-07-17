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
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult UserManegment()
        {
            return View();
        }

        public JsonResult TheUsers([DataSourceRequest] DataSourceRequest request)
        {
            using (PCDCREntities db = new PCDCREntities())
            {
                var q = db.Users_Table.ToList();
                return Json(q.ToDataSourceResult(request));
            }
        }


        // Insert New
        public JsonResult Create_User([DataSourceRequest] DataSourceRequest request, Users_Table usr)
        {
            using (PCDCREntities db = new PCDCREntities())
            {
                if (usr != null && ModelState.IsValid)
                {
                    Users_Table u = new Users_Table();

                    u.UserName = usr.UserName;
                    u.Password = usr.Password;
                    u.UserAddress = usr.UserAddress;
                    u.UserPhone = usr.UserPhone;
                    u.Status = usr.Status;
                    u.UserType = usr.UserType;

                    db.Users_Table.Add(u);
                    db.SaveChanges();
                    usr.ID = u.ID;
                }

                return Json(new[] { usr }.ToDataSourceResult(request, ModelState));
            }
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult Update_User([DataSourceRequest] DataSourceRequest request, Users_Table usr)
        {
            using (PCDCREntities db = new PCDCREntities())
            {
                if (usr != null && ModelState.IsValid)
                {
                    Users_Table u = db.Users_Table.Single(c => c.ID == usr.ID);


                    u.UserName = usr.UserName;
                    u.Password = usr.Password;
                    u.UserAddress = usr.UserAddress;
                    u.UserPhone = usr.UserPhone;
                    u.Status = usr.Status;
                    u.UserType = usr.UserType;

                }
                db.SaveChanges();
                return Json(ModelState.IsValid ? true : ModelState.ToDataSourceResult());
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult Delete_User([DataSourceRequest] DataSourceRequest request, Users_Table usr)
        {
            using (PCDCREntities db = new PCDCREntities())
            {
                if (usr != null && ModelState.IsValid)
                {
                    Users_Table u = db.Users_Table.Single(c => c.ID == usr.ID);
                    db.Users_Table.Remove(u);
                }

                db.SaveChanges();
                return Json(ModelState.IsValid ? true : ModelState.ToDataSourceResult());
            }
        }
    }
}