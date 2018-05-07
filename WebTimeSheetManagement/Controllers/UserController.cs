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
    [ValidateUserSession]
    public class UserController : Controller
    {
        private ITimeSheet _ITimeSheet;
        private IExpense _IExpense;

        public UserController()
        {
            _ITimeSheet = new TimeSheetConcrete();
            _IExpense = new ExpenseConcrete();
        }


        // GET: User
        [HttpGet]
        public ActionResult Dashboard()
        {
            var timesheetResult = _ITimeSheet.GetTimeSheetsCountByUserID(Convert.ToString(Session["UserID"]));

            if (timesheetResult != null)
            {
                ViewBag.SubmittedTimesheetCount = timesheetResult.SubmittedCount;
                ViewBag.ApprovedTimesheetCount = timesheetResult.ApprovedCount;
                ViewBag.RejectedTimesheetCount = timesheetResult.RejectedCount;
            }
            else
            {
                ViewBag.SubmittedTimesheetCount = 0;
                ViewBag.ApprovedTimesheetCount = 0;
                ViewBag.RejectedTimesheetCount = 0;
            }


            var expenseResult = _IExpense.GetExpenseAuditCountByUserID(Convert.ToString(Session["UserID"]));

            if (expenseResult != null)
            {
                ViewBag.SubmittedExpenseCount = expenseResult.SubmittedCount;
                ViewBag.ApprovedExpenseCount = expenseResult.ApprovedCount;
                ViewBag.RejectedExpenseCount = expenseResult.RejectedCount;
            }
            else
            {
                ViewBag.SubmittedExpenseCount = 0;
                ViewBag.ApprovedExpenseCount = 0;
                ViewBag.RejectedExpenseCount = 0;
            }

            return View();
        }

    }
}