using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTimeSheetManagement.Concrete;
using WebTimeSheetManagement.Filters;
using WebTimeSheetManagement.Interface;
using WebTimeSheetManagement.Models;

namespace WebTimeSheetManagement.Controllers
{
    [ValidateUserSession]
    public class AllTimeSheetController : Controller
    {
        IProject _IProject;
        ITimeSheet _ITimeSheet;
        public AllTimeSheetController()
        {
            _IProject = new ProjectConcrete();
            _ITimeSheet = new TimeSheetConcrete();
        }


        // GET: AllTimeSheet
        public ActionResult TimeSheet()
        {
            return View();
        }

        public ActionResult LoadTimeSheetData()
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
                var v = _ITimeSheet.ShowTimeSheet(sortColumn, sortColumnDir, searchValue, Convert.ToInt32(Session["UserID"]));
                recordsTotal = v.Count();
                var data = v.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActionResult Details(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return RedirectToAction("TimeSheet", "AllTimeSheet");
                }
                MainTimeSheetView objMT = new MainTimeSheetView();
                objMT.ListTimeSheetDetails = _ITimeSheet.TimesheetDetailsbyTimeSheetMasterID(Convert.ToInt32(Session["UserID"]), Convert.ToInt32(id));
                objMT.ListofProjectNames = _ITimeSheet.GetProjectNamesbyTimeSheetMasterID(Convert.ToInt32(id));
                objMT.ListofPeriods = _ITimeSheet.GetPeriodsbyTimeSheetMasterID(Convert.ToInt32(id));
                objMT.ListoDayofWeek = DayofWeek();
                objMT.TimeSheetMasterID = Convert.ToInt32(id);
                return View(objMT);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [NonAction]
        public List<string> DayofWeek()
        {
            List<string> li = new List<string>();
            li.Add("Sunday");
            li.Add("Monday");
            li.Add("Tuesday");
            li.Add("Wednesday");
            li.Add("Thursday");
            li.Add("Friday");
            li.Add("Saturday");
            li.Add("Total");
            return li;
        }


        public ActionResult SubmittedTimeSheet()
        {
            return View();
        }

        public ActionResult ApprovedTimeSheet()
        {
            return View();
        }

        public ActionResult RejectedTimeSheet()
        {
            return View();
        }


        public ActionResult LoadSubmittedTimeSheetData()
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
                var v = _ITimeSheet.ShowTimeSheetStatus(sortColumn, sortColumnDir, searchValue, Convert.ToInt32(Session["UserID"]),1);
                recordsTotal = v.Count();
                var data = v.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActionResult LoadRejectedTimeSheetData()
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
                var v = _ITimeSheet.ShowTimeSheetStatus(sortColumn, sortColumnDir, searchValue, Convert.ToInt32(Session["UserID"]), 3);
                recordsTotal = v.Count();
                var data = v.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActionResult LoadApprovedTimeSheetData()
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
                var v = _ITimeSheet.ShowTimeSheetStatus(sortColumn, sortColumnDir, searchValue, Convert.ToInt32(Session["UserID"]), 2);
                recordsTotal = v.Count();
                var data = v.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}