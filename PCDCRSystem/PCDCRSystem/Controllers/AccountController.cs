using PCDCRSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCDCRSystem.Controllers
{
    public class AccountController : Controller
    {
        // LogIn
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Users_Table user)
        {

            if (ModelState.IsValid)
            {
                    try
                    {
                    using (PCDCREntities dc = new PCDCREntities())
                    {
                        // Check If Existed Or Not : 
                        var u = dc.Users_Table.Single(i => i.UserName == user.UserName
                                                                    && i.Password == user.Password);
                        if (u != null)
                        {
                            // Check If Already LogIned Or Not : 
                            bool CheckCurrentUser = IsOnLine(u.ID);
                            if (CheckCurrentUser == false)
                            {
                                // اذا كان المستخدم 
                                // OfLine 
                                //  يدخل على النظام
                                // ونسجل بياناته  في جدول 
                                LogHistory h = new LogHistory()
                                {
                                    UserId = u.ID,
                                    LogInTime = DateTime.Now,
                                    Status = "OnLine"

                                };
                                dc.LogHistory.Add(h);
                                dc.SaveChanges();

                              //  InformationClass.ListUsersOnLine.Add(h);

                                return RedirectToAction("LoggedIn");
                            }
                            else
                            {
                                //  اذا كان مسجل دخول  يعني OnLine
                                //

                                return RedirectToAction("LoggedIn");
                                // return View();


                            }


                        }
                    }

                    }
                    catch (Exception)
                    {
                    //اذا كان المستخدم اساسا مش موجود في جدول المستخدمين او كلمة المرور خطأ
                    ViewBag.Message = "Error";
                }
            }
            return View(user);
        }

        public ActionResult LoggedIn()
        {
            ViewBag.Message = "Welcome ";
            return View();
  
        }



        #region "      Check User Status     "
        // Abu Ehab 
        private bool IsOnLine(int id)
        {
            bool status = false;
            try
            {             
                PCDCREntities context = new PCDCREntities();
                var user = context.LogHistory.Single(i => i.UserId == id && i.Status == "OnLine");
                // If User Is  Already OnLine  Before :
                if(user != null)
                {
                    status = true;                   
                }
                return status;
            }
            catch (Exception)
            {
              return   status ;
            }
        
        }
        #endregion
    }
}