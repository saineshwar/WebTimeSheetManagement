using EventApplicationCore.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebTimeSheetManagement.Concrete;
using WebTimeSheetManagement.Filters;
using WebTimeSheetManagement.Helpers;
using WebTimeSheetManagement.Interface;
using WebTimeSheetManagement.Models;

namespace WebTimeSheetManagement.Controllers
{
    [ValidateSuperAdminSession]
    public class SuperAdminController : Controller
    {
        private IRegistration _IRegistration;
        private IRoles _IRoles;
        private IAssignRoles _IAssignRoles;
        private ICacheManager _ICacheManager;
        private IUsers _IUsers;
        private IProject _IProject;
        

        public SuperAdminController()
        {
            _IRegistration = new RegistrationConcrete();
            _IRoles = new RolesConcrete();
            _IAssignRoles = new AssignRolesConcrete();
            _ICacheManager = new CacheManager();
            _IUsers = new UsersConcrete();
            _IProject = new ProjectConcrete();
        }

        // GET: SuperAdmin
        public ActionResult Dashboard()
        {
            try
            {

                var adminCount = _ICacheManager.Get<object>("AdminCount");

                if (adminCount == null)
                {
                    var admincount = _IUsers.GetTotalAdminsCount();
                    _ICacheManager.Add("AdminCount", admincount);
                    ViewBag.AdminCount = admincount;
                }
                else
                {
                    ViewBag.AdminCount = adminCount;
                }

                var usersCount = _ICacheManager.Get<object>("UsersCount");

                if (usersCount == null)
                {
                    var userscount = _IUsers.GetTotalUsersCount();
                    _ICacheManager.Add("UsersCount", userscount);
                    ViewBag.UsersCount = userscount;
                }
                else
                {
                    ViewBag.UsersCount = usersCount;
                }

                var projectCount = _ICacheManager.Get<object>("ProjectCount");

                if (projectCount == null)
                {
                    var projectcount = _IProject.GetTotalProjectsCounts();
                    _ICacheManager.Add("ProjectCount", projectcount);
                    ViewBag.ProjectCount = projectcount;
                }
                else
                {
                    ViewBag.ProjectCount = projectCount;
                }

                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public ActionResult CreateAdmin()
        {
            return View(new Registration());
        }

        [HttpPost]
        public ActionResult CreateAdmin(Registration registration)
        {

            try
            {
                var isUsernameExists = _IRegistration.CheckUserNameExists(registration.Username);

                if (isUsernameExists)
                {
                    ModelState.AddModelError("", errorMessage: "Username Already Used try unique one!");
                }
                else
                {
                    registration.CreatedOn = DateTime.Now;
                    registration.RoleID = _IRoles.getRolesofUserbyRolename("Admin");
                    registration.Password = EncryptionLibrary.EncryptText(registration.Password);
                    registration.ConfirmPassword = EncryptionLibrary.EncryptText(registration.ConfirmPassword);
                    if (_IRegistration.AddUser(registration) > 0)
                    {
                        TempData["MessageRegistration"] = "Data Saved Successfully!";
                        return RedirectToAction("CreateAdmin");
                    }
                    else
                    {
                        return View("CreateAdmin", registration);
                    }
                }

                return RedirectToAction("Dashboard");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult AssignRoles()
        {
            try
            {
                AssignRolesModel assignRolesModel = new AssignRolesModel();
                assignRolesModel.ListofAdmins = _IAssignRoles.ListofAdmins();
                assignRolesModel.ListofUser = _IAssignRoles.GetListofUnAssignedUsers();
                return View(assignRolesModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult AssignRoles(AssignRolesModel objassign)
        {
            try
            {
                if (objassign.ListofUser == null)
                {
                    TempData["MessageErrorRoles"] = "There are no Users to Assign Roles";
                    objassign.ListofAdmins = _IAssignRoles.ListofAdmins();
                    objassign.ListofUser = _IAssignRoles.GetListofUnAssignedUsers();
                    return View(objassign);
                }


                var SelectedCount = (from User in objassign.ListofUser
                                     where User.selectedUsers == true
                                     select User).Count();

                if (SelectedCount == 0)
                {
                    TempData["MessageErrorRoles"] = "You have not Selected any User to Assign Roles";
                    objassign.ListofAdmins = _IAssignRoles.ListofAdmins();
                    objassign.ListofUser = _IAssignRoles.GetListofUnAssignedUsers();
                    return View(objassign);
                }

                if (ModelState.IsValid)
                {
                    objassign.CreatedBy = Convert.ToInt32(Session["SuperAdmin"]);
                    _IAssignRoles.SaveAssignedRoles(objassign);
                    TempData["MessageRoles"] = "Roles Assigned Successfully!";
                }

                objassign = new AssignRolesModel();
                objassign.ListofAdmins = _IAssignRoles.ListofAdmins();
                objassign.ListofUser = _IAssignRoles.GetListofUnAssignedUsers();

                return RedirectToAction("AssignRoles");
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}