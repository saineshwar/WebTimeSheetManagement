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
    public class TimeSheetController : Controller
    {
        IProject _IProject;
        ITimeSheet _ITimeSheet;
        IUsers _IUsers;
        public TimeSheetController()
        {
            _IProject = new ProjectConcrete();
            _ITimeSheet = new TimeSheetConcrete();
            _IUsers = new UsersConcrete();
        }

        // GET: TimeSheet
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(TimeSheetModel timesheetmodel)
        {
            try
            {
                if (timesheetmodel == null)
                {
                    ModelState.AddModelError("", "Values Posted Are Not Accurate");
                    return View();
                }

                TimeSheetMaster objtimesheetmaster = new TimeSheetMaster();
                objtimesheetmaster.TimeSheetMasterID = 0;
                objtimesheetmaster.UserID = Convert.ToInt32(Session["UserID"]);
                objtimesheetmaster.CreatedOn = DateTime.Now;
                objtimesheetmaster.FromDate = timesheetmodel.hdtext1;
                objtimesheetmaster.ToDate = timesheetmodel.hdtext7;
                objtimesheetmaster.TotalHours = CalculateTotalHours(timesheetmodel);
                objtimesheetmaster.TimeSheetStatus = 1;
                int TimeSheetMasterID = _ITimeSheet.AddTimeSheetMaster(objtimesheetmaster);

                var count = ProjectSelectCount(timesheetmodel);

                if (TimeSheetMasterID > 0)
                {
                    Save(timesheetmodel, TimeSheetMasterID);
                    SaveDescription(timesheetmodel, TimeSheetMasterID);
                    _ITimeSheet.InsertTimeSheetAuditLog(InsertTimeSheetAudit(TimeSheetMasterID, 1));
                }

                TempData["TimeCardMessage"] = "Data Saved Successfully";

                return RedirectToAction("Add", "TimeSheet");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JsonResult ListofProjects()
        {
            try
            {
                var listofProjects = _IProject.GetListofProjects();
                return Json(listofProjects, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [NonAction]
        private int? CalculateTotalHours(TimeSheetModel TimeSheetModel)
        {
            try
            {
                int? Total = 0;
                var val1 = TimeSheetModel.texttotal_p1 == null ? 0 : TimeSheetModel.texttotal_p1;
                var val2 = TimeSheetModel.texttotal_p2 == null ? 0 : TimeSheetModel.texttotal_p2;
                var val3 = TimeSheetModel.texttotal_p3 == null ? 0 : TimeSheetModel.texttotal_p3;
                var val4 = TimeSheetModel.texttotal_p4 == null ? 0 : TimeSheetModel.texttotal_p4;
                var val5 = TimeSheetModel.texttotal_p5 == null ? 0 : TimeSheetModel.texttotal_p5;
                var val6 = TimeSheetModel.texttotal_p6 == null ? 0 : TimeSheetModel.texttotal_p6;
                Total = val1 + val2 + val3 + val4 + val5 + val6;
                return Total;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [NonAction]
        private void SaveTimeSheetDetail(string DaysofWeek, int? Hours, DateTime? Period, int? ProjectID, int TimeSheetMasterID)
        {
            try
            {
                TimeSheetDetails objtimesheetdetails = new TimeSheetDetails();
                objtimesheetdetails.TimeSheetID = 0;
                objtimesheetdetails.DaysofWeek = DaysofWeek;
                objtimesheetdetails.Hours = Hours == null ? 0 : Hours;
                objtimesheetdetails.Period = Period;
                objtimesheetdetails.ProjectID = ProjectID;
                objtimesheetdetails.UserID = Convert.ToInt32(Session["UserID"]);
                objtimesheetdetails.CreatedOn = DateTime.Now;
                objtimesheetdetails.TimeSheetMasterID = TimeSheetMasterID;
                int TimeSheetID = _ITimeSheet.AddTimeSheetDetail(objtimesheetdetails);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JsonResult CheckIsDateAlreadyUsed(DateTime FromDate)
        {
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(FromDate)))
                {
                    return Json("Error", JsonRequestBehavior.AllowGet);
                }

                var data = _ITimeSheet.CheckIsDateAlreadyUsed(FromDate, Convert.ToInt32(Session["UserID"]));
                return Json(data, JsonRequestBehavior.AllowGet);
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

                var data = _ITimeSheet.DeleteTimesheetByTimeSheetMasterID(TimeSheetMasterID, Convert.ToInt32(Session["UserID"]));

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

        private int ProjectSelectCount(TimeSheetModel timesheetmodel)
        {
            try
            {
                int count = 0;
                if (timesheetmodel.ProjectID1 != null && (timesheetmodel.texttotal_p1 != null && timesheetmodel.texttotal_p1 != 0))
                {
                    count = count + 1;
                }

                if (timesheetmodel.ProjectID2 != null && (timesheetmodel.texttotal_p2 != null && timesheetmodel.texttotal_p2 != 0))
                {
                    count = count + 1;
                }

                if (timesheetmodel.ProjectID3 != null && (timesheetmodel.texttotal_p3 != null && timesheetmodel.texttotal_p3 != 0))
                {
                    count = count + 1;
                }

                if (timesheetmodel.ProjectID3 != null && (timesheetmodel.texttotal_p3 != null && timesheetmodel.texttotal_p3 != 0))
                {
                    count = count + 1;
                }

                if (timesheetmodel.ProjectID4 != null && (timesheetmodel.texttotal_p4 != null && timesheetmodel.texttotal_p4 != 0))
                {
                    count = count + 1;
                }

                if (timesheetmodel.ProjectID5 != null && (timesheetmodel.texttotal_p5 != null && timesheetmodel.texttotal_p5 != 0))
                {
                    count = count + 1;
                }

                if (timesheetmodel.ProjectID6 != null && (timesheetmodel.texttotal_p6 != null && timesheetmodel.texttotal_p6 != 0))
                {
                    count = count + 1;
                }

                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Save(TimeSheetModel timesheetmodel, int TimeSheetMasterID)
        {
            try
            {
                if (timesheetmodel.ProjectID1 != null && (timesheetmodel.texttotal_p1 != null && timesheetmodel.texttotal_p1 != 0))
                {
                    #region Project 1
                    var date1 = timesheetmodel.hdtext1;
                    var DaysofWeek1 = timesheetmodel.DaysofWeek1;
                    var value1 = timesheetmodel.text1_p1;
                    SaveTimeSheetDetail(DaysofWeek1, value1, date1, timesheetmodel.ProjectID1, TimeSheetMasterID);

                    var date2 = timesheetmodel.hdtext2;
                    var DaysofWeek2 = timesheetmodel.DaysofWeek2;
                    var value2 = timesheetmodel.text2_p1;
                    SaveTimeSheetDetail(DaysofWeek2, value2, date2, timesheetmodel.ProjectID1, TimeSheetMasterID);

                    var date3 = timesheetmodel.hdtext3;
                    var DaysofWeek3 = timesheetmodel.DaysofWeek3;
                    var value3 = timesheetmodel.text3_p1;
                    SaveTimeSheetDetail(DaysofWeek3, value3, date3, timesheetmodel.ProjectID1, TimeSheetMasterID);

                    var date4 = timesheetmodel.hdtext4;
                    var DaysofWeek4 = timesheetmodel.DaysofWeek4;
                    var value4 = timesheetmodel.text4_p1;
                    SaveTimeSheetDetail(DaysofWeek4, value4, date4, timesheetmodel.ProjectID1, TimeSheetMasterID);

                    var date5 = timesheetmodel.hdtext5;
                    var DaysofWeek5 = timesheetmodel.DaysofWeek5;
                    var value5 = timesheetmodel.text5_p1;
                    SaveTimeSheetDetail(DaysofWeek5, value5, date5, timesheetmodel.ProjectID1, TimeSheetMasterID);

                    var date6 = timesheetmodel.hdtext6;
                    var DaysofWeek6 = timesheetmodel.DaysofWeek6;
                    var value6 = timesheetmodel.text6_p1;
                    SaveTimeSheetDetail(DaysofWeek6, value6, date6, timesheetmodel.ProjectID1, TimeSheetMasterID);

                    var date7 = timesheetmodel.hdtext7;
                    var DaysofWeek7 = timesheetmodel.DaysofWeek7;
                    var value7 = timesheetmodel.text7_p1;
                    SaveTimeSheetDetail(DaysofWeek7, value7, date7, timesheetmodel.ProjectID1, TimeSheetMasterID);


                    #endregion
                }

                if (timesheetmodel.ProjectID2 != null && (timesheetmodel.texttotal_p2 != null && timesheetmodel.texttotal_p2 != 0))
                {
                    #region Project 2
                    var date1 = timesheetmodel.hdtext1;
                    var DaysofWeek1 = timesheetmodel.DaysofWeek1;
                    var value1 = timesheetmodel.text1_p2;
                    SaveTimeSheetDetail(DaysofWeek1, value1, date1, timesheetmodel.ProjectID2, TimeSheetMasterID);

                    var date2 = timesheetmodel.hdtext2;
                    var DaysofWeek2 = timesheetmodel.DaysofWeek2;
                    var value2 = timesheetmodel.text2_p2;
                    SaveTimeSheetDetail(DaysofWeek2, value2, date2, timesheetmodel.ProjectID2, TimeSheetMasterID);

                    var date3 = timesheetmodel.hdtext3;
                    var DaysofWeek3 = timesheetmodel.DaysofWeek3;
                    var value3 = timesheetmodel.text3_p2;
                    SaveTimeSheetDetail(DaysofWeek3, value3, date3, timesheetmodel.ProjectID2, TimeSheetMasterID);

                    var date4 = timesheetmodel.hdtext4;
                    var DaysofWeek4 = timesheetmodel.DaysofWeek4;
                    var value4 = timesheetmodel.text4_p2;
                    SaveTimeSheetDetail(DaysofWeek4, value4, date4, timesheetmodel.ProjectID2, TimeSheetMasterID);

                    var date5 = timesheetmodel.hdtext5;
                    var DaysofWeek5 = timesheetmodel.DaysofWeek5;
                    var value5 = timesheetmodel.text5_p2;
                    SaveTimeSheetDetail(DaysofWeek5, value5, date5, timesheetmodel.ProjectID2, TimeSheetMasterID);

                    var date6 = timesheetmodel.hdtext6;
                    var DaysofWeek6 = timesheetmodel.DaysofWeek6;
                    var value6 = timesheetmodel.text6_p2;
                    SaveTimeSheetDetail(DaysofWeek6, value6, date6, timesheetmodel.ProjectID2, TimeSheetMasterID);

                    var date7 = timesheetmodel.hdtext7;
                    var DaysofWeek7 = timesheetmodel.DaysofWeek7;
                    var value7 = timesheetmodel.text7_p2;
                    SaveTimeSheetDetail(DaysofWeek7, value7, date7, timesheetmodel.ProjectID2, TimeSheetMasterID);


                    #endregion
                }

                if (timesheetmodel.ProjectID3 != null && (timesheetmodel.texttotal_p3 != null && timesheetmodel.texttotal_p3 != 0))
                {
                    #region Project 3
                    var date1 = timesheetmodel.hdtext1;
                    var DaysofWeek1 = timesheetmodel.DaysofWeek1;
                    var value1 = timesheetmodel.text1_p3;
                    SaveTimeSheetDetail(DaysofWeek1, value1, date1, timesheetmodel.ProjectID3, TimeSheetMasterID);

                    var date2 = timesheetmodel.hdtext2;
                    var DaysofWeek2 = timesheetmodel.DaysofWeek2;
                    var value2 = timesheetmodel.text2_p3;
                    SaveTimeSheetDetail(DaysofWeek2, value2, date2, timesheetmodel.ProjectID3, TimeSheetMasterID);

                    var date3 = timesheetmodel.hdtext3;
                    var DaysofWeek3 = timesheetmodel.DaysofWeek3;
                    var value3 = timesheetmodel.text3_p3;
                    SaveTimeSheetDetail(DaysofWeek3, value3, date3, timesheetmodel.ProjectID3, TimeSheetMasterID);

                    var date4 = timesheetmodel.hdtext4;
                    var DaysofWeek4 = timesheetmodel.DaysofWeek4;
                    var value4 = timesheetmodel.text4_p3;
                    SaveTimeSheetDetail(DaysofWeek4, value4, date4, timesheetmodel.ProjectID3, TimeSheetMasterID);

                    var date5 = timesheetmodel.hdtext5;
                    var DaysofWeek5 = timesheetmodel.DaysofWeek5;
                    var value5 = timesheetmodel.text5_p3;
                    SaveTimeSheetDetail(DaysofWeek5, value5, date5, timesheetmodel.ProjectID3, TimeSheetMasterID);

                    var date6 = timesheetmodel.hdtext6;
                    var DaysofWeek6 = timesheetmodel.DaysofWeek6;
                    var value6 = timesheetmodel.text6_p3;
                    SaveTimeSheetDetail(DaysofWeek6, value6, date6, timesheetmodel.ProjectID3, TimeSheetMasterID);

                    var date7 = timesheetmodel.hdtext7;
                    var DaysofWeek7 = timesheetmodel.DaysofWeek7;
                    var value7 = timesheetmodel.text7_p3;
                    SaveTimeSheetDetail(DaysofWeek7, value7, date7, timesheetmodel.ProjectID3, TimeSheetMasterID);


                    #endregion
                }

                if (timesheetmodel.ProjectID4 != null && (timesheetmodel.texttotal_p4 != null && timesheetmodel.texttotal_p4 != 0))
                {
                    #region Project 4
                    var date1 = timesheetmodel.hdtext1;
                    var DaysofWeek1 = timesheetmodel.DaysofWeek1;
                    var value1 = timesheetmodel.text1_p4;
                    SaveTimeSheetDetail(DaysofWeek1, value1, date1, timesheetmodel.ProjectID4, TimeSheetMasterID);

                    var date2 = timesheetmodel.hdtext2;
                    var DaysofWeek2 = timesheetmodel.DaysofWeek2;
                    var value2 = timesheetmodel.text2_p4;
                    SaveTimeSheetDetail(DaysofWeek2, value2, date2, timesheetmodel.ProjectID4, TimeSheetMasterID);

                    var date3 = timesheetmodel.hdtext3;
                    var DaysofWeek3 = timesheetmodel.DaysofWeek3;
                    var value3 = timesheetmodel.text3_p4;
                    SaveTimeSheetDetail(DaysofWeek3, value3, date3, timesheetmodel.ProjectID4, TimeSheetMasterID);

                    var date4 = timesheetmodel.hdtext4;
                    var DaysofWeek4 = timesheetmodel.DaysofWeek4;
                    var value4 = timesheetmodel.text4_p4;
                    SaveTimeSheetDetail(DaysofWeek4, value4, date4, timesheetmodel.ProjectID4, TimeSheetMasterID);

                    var date5 = timesheetmodel.hdtext5;
                    var DaysofWeek5 = timesheetmodel.DaysofWeek5;
                    var value5 = timesheetmodel.text5_p4;
                    SaveTimeSheetDetail(DaysofWeek5, value5, date5, timesheetmodel.ProjectID4, TimeSheetMasterID);

                    var date6 = timesheetmodel.hdtext6;
                    var DaysofWeek6 = timesheetmodel.DaysofWeek6;
                    var value6 = timesheetmodel.text6_p4;
                    SaveTimeSheetDetail(DaysofWeek6, value6, date6, timesheetmodel.ProjectID4, TimeSheetMasterID);

                    var date7 = timesheetmodel.hdtext7;
                    var DaysofWeek7 = timesheetmodel.DaysofWeek7;
                    var value7 = timesheetmodel.text7_p4;
                    SaveTimeSheetDetail(DaysofWeek7, value7, date7, timesheetmodel.ProjectID4, TimeSheetMasterID);


                    #endregion
                }

                if (timesheetmodel.ProjectID5 != null && (timesheetmodel.texttotal_p5 != null && timesheetmodel.texttotal_p5 != 0))
                {
                    #region Project 5
                    var date1 = timesheetmodel.hdtext1;
                    var DaysofWeek1 = timesheetmodel.DaysofWeek1;
                    var value1 = timesheetmodel.text1_p5;
                    SaveTimeSheetDetail(DaysofWeek1, value1, date1, timesheetmodel.ProjectID5, TimeSheetMasterID);

                    var date2 = timesheetmodel.hdtext2;
                    var DaysofWeek2 = timesheetmodel.DaysofWeek2;
                    var value2 = timesheetmodel.text2_p5;
                    SaveTimeSheetDetail(DaysofWeek2, value2, date2, timesheetmodel.ProjectID5, TimeSheetMasterID);

                    var date3 = timesheetmodel.hdtext3;
                    var DaysofWeek3 = timesheetmodel.DaysofWeek3;
                    var value3 = timesheetmodel.text3_p5;
                    SaveTimeSheetDetail(DaysofWeek3, value3, date3, timesheetmodel.ProjectID5, TimeSheetMasterID);

                    var date4 = timesheetmodel.hdtext4;
                    var DaysofWeek4 = timesheetmodel.DaysofWeek4;
                    var value4 = timesheetmodel.text4_p5;
                    SaveTimeSheetDetail(DaysofWeek4, value4, date4, timesheetmodel.ProjectID5, TimeSheetMasterID);

                    var date5 = timesheetmodel.hdtext5;
                    var DaysofWeek5 = timesheetmodel.DaysofWeek5;
                    var value5 = timesheetmodel.text5_p5;
                    SaveTimeSheetDetail(DaysofWeek5, value5, date5, timesheetmodel.ProjectID5, TimeSheetMasterID);

                    var date6 = timesheetmodel.hdtext6;
                    var DaysofWeek6 = timesheetmodel.DaysofWeek6;
                    var value6 = timesheetmodel.text6_p5;
                    SaveTimeSheetDetail(DaysofWeek6, value6, date6, timesheetmodel.ProjectID5, TimeSheetMasterID);

                    var date7 = timesheetmodel.hdtext7;
                    var DaysofWeek7 = timesheetmodel.DaysofWeek7;
                    var value7 = timesheetmodel.text7_p5;
                    SaveTimeSheetDetail(DaysofWeek7, value7, date7, timesheetmodel.ProjectID5, TimeSheetMasterID);


                    #endregion
                }

                if (timesheetmodel.ProjectID6 != null && (timesheetmodel.texttotal_p6 != null && timesheetmodel.texttotal_p6 != 0))
                {
                    #region Project 6
                    var date1 = timesheetmodel.hdtext1;
                    var DaysofWeek1 = timesheetmodel.DaysofWeek1;
                    var value1 = timesheetmodel.text1_p6;
                    SaveTimeSheetDetail(DaysofWeek1, value1, date1, timesheetmodel.ProjectID6, TimeSheetMasterID);

                    var date2 = timesheetmodel.hdtext2;
                    var DaysofWeek2 = timesheetmodel.DaysofWeek2;
                    var value2 = timesheetmodel.text2_p6;
                    SaveTimeSheetDetail(DaysofWeek2, value2, date2, timesheetmodel.ProjectID6, TimeSheetMasterID);

                    var date3 = timesheetmodel.hdtext3;
                    var DaysofWeek3 = timesheetmodel.DaysofWeek3;
                    var value3 = timesheetmodel.text3_p6;
                    SaveTimeSheetDetail(DaysofWeek3, value3, date3, timesheetmodel.ProjectID6, TimeSheetMasterID);

                    var date4 = timesheetmodel.hdtext4;
                    var DaysofWeek4 = timesheetmodel.DaysofWeek4;
                    var value4 = timesheetmodel.text4_p6;
                    SaveTimeSheetDetail(DaysofWeek4, value4, date4, timesheetmodel.ProjectID6, TimeSheetMasterID);

                    var date5 = timesheetmodel.hdtext5;
                    var DaysofWeek5 = timesheetmodel.DaysofWeek5;
                    var value5 = timesheetmodel.text5_p6;
                    SaveTimeSheetDetail(DaysofWeek5, value5, date5, timesheetmodel.ProjectID6, TimeSheetMasterID);

                    var date6 = timesheetmodel.hdtext6;
                    var DaysofWeek6 = timesheetmodel.DaysofWeek6;
                    var value6 = timesheetmodel.text6_p6;
                    SaveTimeSheetDetail(DaysofWeek6, value6, date6, timesheetmodel.ProjectID6, TimeSheetMasterID);

                    var date7 = timesheetmodel.hdtext7;
                    var DaysofWeek7 = timesheetmodel.DaysofWeek7;
                    var value7 = timesheetmodel.text7_p6;
                    SaveTimeSheetDetail(DaysofWeek7, value7, date7, timesheetmodel.ProjectID6, TimeSheetMasterID);


                    #endregion
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void SaveDescription(TimeSheetModel timesheetmodel, int TimeSheetMasterID)
        {
            try
            {

                if (timesheetmodel.ProjectID1 != null)
                {
                    InsertDescriptionDetail(timesheetmodel.ProjectID1, TimeSheetMasterID, timesheetmodel.Description_p1);
                }

                if (timesheetmodel.ProjectID2 != null)
                {
                    InsertDescriptionDetail(timesheetmodel.ProjectID2, TimeSheetMasterID, timesheetmodel.Description_p2);
                }

                if (timesheetmodel.ProjectID3 != null)
                {
                    InsertDescriptionDetail(timesheetmodel.ProjectID3, TimeSheetMasterID, timesheetmodel.Description_p3);
                }

                if (timesheetmodel.ProjectID4 != null)
                {
                    InsertDescriptionDetail(timesheetmodel.ProjectID4, TimeSheetMasterID, timesheetmodel.Description_p4);
                }

                if (timesheetmodel.ProjectID5 != null)
                {
                    InsertDescriptionDetail(timesheetmodel.ProjectID5, TimeSheetMasterID, timesheetmodel.Description_p5);
                }

                if (timesheetmodel.ProjectID6 != null)
                {
                    InsertDescriptionDetail(timesheetmodel.ProjectID6, TimeSheetMasterID, timesheetmodel.Description_p6);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        private TimeSheetAuditTB InsertTimeSheetAudit(int TimeSheetMasterID, int Status)
        {
            try
            {
                TimeSheetAuditTB objAuditTB = new TimeSheetAuditTB();
                objAuditTB.ApprovalTimeSheetLogID = 0;
                objAuditTB.TimeSheetID = TimeSheetMasterID;
                objAuditTB.Status = Status;
                objAuditTB.CreatedOn = DateTime.Now;
                objAuditTB.Comment = string.Empty;
                objAuditTB.ApprovalUser = _IUsers.GetAdminIDbyUserID(Convert.ToInt32(Session["UserID"]));
                objAuditTB.ProcessedDate = DateTime.Now;
                objAuditTB.UserID = Convert.ToInt32(Session["UserID"]);
                return objAuditTB;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [NonAction]
        private void InsertDescriptionDetail(int? ProjectID, int TimeSheetMasterID, string Description)
        {
            try
            {
                DescriptionTB objtimesheetdetails = new DescriptionTB();
                objtimesheetdetails.DescriptionID = 0;
                objtimesheetdetails.ProjectID = ProjectID;
                objtimesheetdetails.UserID = Convert.ToInt32(Session["UserID"]);
                objtimesheetdetails.CreatedOn = DateTime.Now;
                objtimesheetdetails.TimeSheetMasterID = TimeSheetMasterID;
                objtimesheetdetails.Description = Description;
                int? TimeSheetID = _ITimeSheet.InsertDescription(objtimesheetdetails);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}