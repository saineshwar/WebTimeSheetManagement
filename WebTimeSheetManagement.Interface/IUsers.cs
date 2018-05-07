using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTimeSheetManagement.Models;

namespace WebTimeSheetManagement.Interface
{
    public interface IUsers
    {
        IQueryable<RegistrationViewSummaryModel> ShowallUsers(string sortColumn, string sortColumnDir, string Search);

        RegistrationViewDetailsModel GetUserDetailsByRegistrationID(int? RegistrationID);
        IQueryable<RegistrationViewSummaryModel> ShowallAdmin(string sortColumn, string sortColumnDir, string Search);

        RegistrationViewDetailsModel GetAdminDetailsByRegistrationID(int? RegistrationID);

        IQueryable<RegistrationViewSummaryModel> ShowallUsersUnderAdmin(string sortColumn, string sortColumnDir, string Search, int? RegistrationID);

        int GetTotalAdminsCount();
        int GetTotalUsersCount();
        int GetUserIDbyTimesheetID(int TimeSheetMasterID);
        int GetUserIDbyExpenseID(int ExpenseID);
        int GetAdminIDbyUserID(int UserID);
    }
}
