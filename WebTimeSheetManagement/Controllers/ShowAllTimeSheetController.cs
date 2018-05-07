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
    [ValidateAdminSession]
    public class ShowAllTimeSheetController : Controller
    {

        IProject _IProject;
        IUsers _IUsers;
        ITimeSheet _ITimeSheet;
        public ShowAllTimeSheetController()
        {
            _IProject = new ProjectConcrete();
            _ITimeSheet = new TimeSheetConcrete();
            _IUsers = new UsersConcrete();
        }

        // GET: ShowAllTimeSheet
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

                var timesheetdata = _ITimeSheet.ShowAllTimeSheet(sortColumn, sortColumnDir, searchValue, Convert.ToInt32(Session["AdminUser"]));
                recordsTotal = timesheetdata.Count();
                var data = timesheetdata.Skip(skip).Take(pageSize).ToList();

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
                objMT.ListTimeSheetDetails = _ITimeSheet.TimesheetDetailsbyTimeSheetMasterID(Convert.ToInt32(id));
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

        public ActionResult Approval(TimeSheetApproval TimeSheetApproval)
        {
            try
            {
                if (TimeSheetApproval.Comment == null)
                {
                    return Json(false);
                }

                if (string.IsNullOrEmpty(Convert.ToString(TimeSheetApproval.TimeSheetMasterID)))
                {
                    return Json(false);
                }

                _ITimeSheet.UpdateTimeSheetStatus(TimeSheetApproval, 2); //Approve

                if (_ITimeSheet.IsTimesheetALreadyProcessed(TimeSheetApproval.TimeSheetMasterID))
                {
                    _ITimeSheet.UpdateTimeSheetAuditStatus(TimeSheetApproval.TimeSheetMasterID, TimeSheetApproval.Comment, 2);
                }
                else
                {
                    _ITimeSheet.InsertTimeSheetAuditLog(InsertTimeSheetAudit(TimeSheetApproval, 2));
                }


                return Json(true);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Rejected(TimeSheetApproval TimeSheetApproval)
        {
            try
            {
                if (TimeSheetApproval.Comment == null)
                {
                    return Json(false);
                }

                if (string.IsNullOrEmpty(Convert.ToString(TimeSheetApproval.TimeSheetMasterID)))
                {
                    return Json(false);
                }

                _ITimeSheet.UpdateTimeSheetStatus(TimeSheetApproval, 3); //Reject

                if (_ITimeSheet.IsTimesheetALreadyProcessed(TimeSheetApproval.TimeSheetMasterID))
                {
                    _ITimeSheet.UpdateTimeSheetAuditStatus(TimeSheetApproval.TimeSheetMasterID, TimeSheetApproval.Comment, 3);
                }
                else
                {
                    _ITimeSheet.InsertTimeSheetAuditLog(InsertTimeSheetAudit(TimeSheetApproval, 3));
                }


                return Json(true);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private TimeSheetAuditTB InsertTimeSheetAudit(TimeSheetApproval TimeSheetApproval, int Status)
        {
            try
            {
                TimeSheetAuditTB objAuditTB = new TimeSheetAuditTB();
                objAuditTB.ApprovalTimeSheetLogID = 0;
                objAuditTB.TimeSheetID = TimeSheetApproval.TimeSheetMasterID;
                objAuditTB.Status = Status;
                objAuditTB.CreatedOn = DateTime.Now;
                objAuditTB.Comment = TimeSheetApproval.Comment;
                objAuditTB.ApprovalUser = Convert.ToInt32(Session["AdminUser"]);
                objAuditTB.ProcessedDate = DateTime.Now;
                objAuditTB.UserID = _IUsers.GetUserIDbyTimesheetID(TimeSheetApproval.TimeSheetMasterID);
                return objAuditTB;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JsonResult Delete(int TimeSheetMasterID)
        {
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(TimeSheetMasterID)))
                {
                    return Json("Error", JsonRequestBehavior.AllowGet);
                }

                var data = _ITimeSheet.DeleteTimesheetByOnlyTimeSheetMasterID(TimeSheetMasterID);

                if (data > 0)
                {
                    return Json(data: true, behavior: JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(data: false, behavior: JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                throw;
            }
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

        public ActionResult LoadSubmittedTData()
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

                var timesheetdata = _ITimeSheet.ShowAllSubmittedTimeSheet(sortColumn, sortColumnDir, searchValue, Convert.ToInt32(Session["AdminUser"]));
                recordsTotal = timesheetdata.Count();
                var data = timesheetdata.Skip(skip).Take(pageSize).ToList();

                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActionResult LoadRejectedData()
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

                var timesheetdata = _ITimeSheet.ShowAllRejectTimeSheet(sortColumn, sortColumnDir, searchValue, Convert.ToInt32(Session["AdminUser"]));
                recordsTotal = timesheetdata.Count();
                var data = timesheetdata.Skip(skip).Take(pageSize).ToList();

                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActionResult LoadApprovedData()
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

                var timesheetdata = _ITimeSheet.ShowAllApprovedTimeSheet(sortColumn, sortColumnDir, searchValue, Convert.ToInt32(Session["AdminUser"]));
                recordsTotal = timesheetdata.Count();
                var data = timesheetdata.Skip(skip).Take(pageSize).ToList();

                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
            catch (Exception)
            {
                throw;
            }

        }

     


    }
}