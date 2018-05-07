using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTimeSheetManagement.Concrete;
using WebTimeSheetManagement.Filters;
using WebTimeSheetManagement.Interface;

namespace WebTimeSheetManagement.Controllers
{
    [ValidateSuperAdminSession]

    public class AllUsersController : Controller
    {
        private IUsers _IUsers;
        public AllUsersController()
        {
            _IUsers = new UsersConcrete();
        }

        // GET: AllUsers
        public ActionResult Users()
        {
            return View();
        }

        public ActionResult LoadUsersData()
        {
            try
            {
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
                var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;

                int recordsTotal = 0;

                var rolesData = _IUsers.ShowallUsers(sortColumn, sortColumnDir, searchValue);
                recordsTotal = rolesData.Count();
                var data = rolesData.Skip(skip).Take(pageSize).ToList();

                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult UserDetails(int? RegistrationID)
        {
            try
            {
                if (RegistrationID == null)
                {

                }
                var userDetailsResponse = _IUsers.GetUserDetailsByRegistrationID(RegistrationID);
                return PartialView("_UserDetails", userDetailsResponse);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult LoadAdminsData()
        {
            try
            {
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
                var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;

                int recordsTotal = 0;

                var rolesData = _IUsers.ShowallAdmin(sortColumn, sortColumnDir, searchValue);
                recordsTotal = rolesData.Count();
                var data = rolesData.Skip(skip).Take(pageSize).ToList();

                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult AdminDetails(int? RegistrationID)
        {
            try
            {
                if (RegistrationID == null)
                {

                }
                var userDetailsResponse = _IUsers.GetAdminDetailsByRegistrationID(RegistrationID);
                return PartialView("_UserDetails", userDetailsResponse);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}