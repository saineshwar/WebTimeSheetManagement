using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTimeSheetManagement.Models;

namespace WebTimeSheetManagement.Interface
{
    public interface ITimeSheet
    {
        int AddTimeSheetMaster(TimeSheetMaster TimeSheetMaster);
        int AddTimeSheetDetail(TimeSheetDetails TimeSheetDetails);
        bool CheckIsDateAlreadyUsed(DateTime FromDate, int UserID);
        IQueryable<TimeSheetMasterView> ShowTimeSheet(string sortColumn, string sortColumnDir, string Search, int UserID);
        List<TimeSheetDetailsView> TimesheetDetailsbyTimeSheetMasterID(int UserID, int TimeSheetMasterID);
        int DeleteTimesheetByTimeSheetMasterID(int TimeSheetMasterID, int UserID);
        IQueryable<TimeSheetMasterView> ShowAllTimeSheet(string sortColumn, string sortColumnDir, string Search, int UserID);
        List<TimeSheetDetailsView> TimesheetDetailsbyTimeSheetMasterID(int TimeSheetMasterID);
        List<GetPeriods> GetPeriodsbyTimeSheetMasterID(int TimeSheetMasterID);
        List<GetProjectNames> GetProjectNamesbyTimeSheetMasterID(int TimeSheetMasterID);
        bool UpdateTimeSheetStatus(TimeSheetApproval timesheetapprovalmodel, int Status);
        void InsertTimeSheetAuditLog(TimeSheetAuditTB timesheetaudittb);
        int DeleteTimesheetByOnlyTimeSheetMasterID(int TimeSheetMasterID);
        int? InsertDescription(DescriptionTB DescriptionTB);
        DisplayViewModel GetTimeSheetsCountByAdminID(string AdminID);
        IQueryable<TimeSheetMasterView> ShowAllApprovedTimeSheet(string sortColumn, string sortColumnDir, string Search, int UserID);
        IQueryable<TimeSheetMasterView> ShowAllRejectTimeSheet(string sortColumn, string sortColumnDir, string Search, int UserID);
        IQueryable<TimeSheetMasterView> ShowAllSubmittedTimeSheet(string sortColumn, string sortColumnDir, string Search, int UserID);
        DisplayViewModel GetTimeSheetsCountByUserID(string UserID);
        IQueryable<TimeSheetMasterView> ShowTimeSheetStatus(string sortColumn, string sortColumnDir, string Search, int UserID, int TimeSheetStatus);
        bool UpdateTimeSheetAuditStatus(int TimeSheetID, string Comment, int Status);
        bool IsTimesheetALreadyProcessed(int TimeSheetID);
    }
}
