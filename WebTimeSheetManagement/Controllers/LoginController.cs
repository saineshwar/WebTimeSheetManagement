using EventApplicationCore.Library;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTimeSheetManagement.Concrete;
using WebTimeSheetManagement.Interface;
using WebTimeSheetManagement.Models;
using CaptchaMvc;
using CaptchaMvc.HtmlHelpers;
using WebTimeSheetManagement.Helpers;

namespace WebTimeSheetManagement.Controllers
{
    public class LoginController : Controller
    {
        private ILogin _ILogin;
        private IAssignRoles _IAssignRoles;
        private ICacheManager _ICacheManager;
        public LoginController()
        {
            _ILogin = new LoginConcrete();
            _IAssignRoles = new AssignRolesConcrete();
            _ICacheManager = new CacheManager();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            try
            {
                if (!this.IsCaptchaValid("Captcha is not valid"))
                {
                    ViewBag.errormessage = "Error: captcha entered is not valid.";

                    return View(loginViewModel);
                }

                if (!string.IsNullOrEmpty(loginViewModel.Username) && !string.IsNullOrEmpty(loginViewModel.Password))
                {
                    var Username = loginViewModel.Username;
                    var password = EncryptionLibrary.EncryptText(loginViewModel.Password);

                    var result = _ILogin.ValidateUser(Username, password);

                    if (result != null)
                    {
                        if (result.RegistrationID == 0 || result.RegistrationID < 0)
                        {
                            ViewBag.errormessage = "Entered Invalid Username and Password";
                        }
                        else
                        {
                            var RoleID = result.RoleID;
                            remove_Anonymous_Cookies(); //Remove Anonymous_Cookies

                            Session["RoleID"] = Convert.ToString(result.RoleID);
                            Session["Username"] = Convert.ToString(result.Username);
                            if (RoleID == 1)
                            {
                                Session["AdminUser"] = Convert.ToString(result.RegistrationID);

                                if (result.ForceChangePassword == 1)
                                {
                                    return RedirectToAction("ChangePassword", "UserProfile");
                                }

                                return RedirectToAction("Dashboard", "Admin");
                            }
                            else if (RoleID == 2)
                            {
                                if (!_IAssignRoles.CheckIsUserAssignedRole(result.RegistrationID))
                                {
                                    ViewBag.errormessage = "Approval Pending";
                                    return View(loginViewModel);
                                }

                                Session["UserID"] = Convert.ToString(result.RegistrationID);

                                if (result.ForceChangePassword == 1)
                                {
                                    return RedirectToAction("ChangePassword", "UserProfile");
                                }

                                return RedirectToAction("Dashboard", "User");
                            }
                            else if (RoleID == 3)
                            {
                                Session["SuperAdmin"] = Convert.ToString(result.RegistrationID);
                                return RedirectToAction("Dashboard", "SuperAdmin");
                            }
                        }
                    }
                    else
                    {
                        ViewBag.errormessage = "Entered Invalid Username and Password";
                        return View(loginViewModel);
                    }
                }
                return View(loginViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {

            try
            {
                if (!string.IsNullOrEmpty(Convert.ToString(Session["SuperAdmin"])))
                {
                    _ICacheManager.Clear("AdminCount");
                    _ICacheManager.Clear("UsersCount");
                    _ICacheManager.Clear("ProjectCount");
                }

                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
                Response.Cache.SetNoStore();

                HttpCookie Cookies = new HttpCookie("WebTime");
                Cookies.Value = "";
                Cookies.Expires = DateTime.Now.AddHours(-1);
                Response.Cookies.Add(Cookies);
                HttpContext.Session.Clear();
                Session.Abandon();
                return RedirectToAction("Login", "Login");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [NonAction]
        public void remove_Anonymous_Cookies()
        {
            try
            {

                if (Request.Cookies["WebTime"] != null)
                {
                    var option = new HttpCookie("WebTime");
                    option.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(option);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
