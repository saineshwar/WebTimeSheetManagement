using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTimeSheetManagement.Models;
using System.Linq.Dynamic;
using WebTimeSheetManagement.Interface;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace WebTimeSheetManagement.Concrete
{
    public class UsersConcrete : IUsers
    {
        public IQueryable<RegistrationViewSummaryModel> ShowallUsers(string sortColumn, string sortColumnDir, string Search)
        {
            var _context = new DatabaseContext();

            var IQueryabletimesheet = (from registration in _context.Registration
                                       join AssignedRoles in _context.AssignedRoles on registration.RegistrationID equals AssignedRoles.RegistrationID
                                       join AssignedRolesAdmin in _context.Registration on AssignedRoles.AssignToAdmin equals AssignedRolesAdmin.RegistrationID
                                       where registration.RoleID == 2
                                       select new RegistrationViewSummaryModel
                                       {
                                           Name = registration.Name,
                                           AssignToAdmin = string.IsNullOrEmpty(AssignedRolesAdmin.Name) ? "*Not Assigned*" : AssignedRolesAdmin.Name.ToUpper(),
                                           RegistrationID = registration.RegistrationID,
                                           EmailID = registration.EmailID,
                                           Mobileno = registration.Mobileno,
                                           Username = registration.Username
                                       });

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                IQueryabletimesheet = IQueryabletimesheet.OrderBy(sortColumn + " " + sortColumnDir);
            }
            if (!string.IsNullOrEmpty(Search))
            {
                IQueryabletimesheet = IQueryabletimesheet.Where(m => m.Name == Search);
            }

            return IQueryabletimesheet;

        }

        public RegistrationViewDetailsModel GetUserDetailsByRegistrationID(int? RegistrationID)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDBEntities"].ToString()))
            {
                con.Open();
                try
                {
                    var param = new DynamicParameters();
                    param.Add("@RegistrationID", RegistrationID);
                    return con.Query<RegistrationViewDetailsModel>("Usp_GetUserDetailsByRegistrationID", param, null, true, 0, System.Data.CommandType.StoredProcedure).SingleOrDefault();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public IQueryable<RegistrationViewSummaryModel> ShowallAdmin(string sortColumn, string sortColumnDir, string Search)
        {
            var _context = new DatabaseContext();

            var IQueryabletimesheet = (from registration in _context.Registration
                                       where registration.RoleID == 1
                                       select new RegistrationViewSummaryModel
                                       {
                                           Name = registration.Name,
                                           RegistrationID = registration.RegistrationID,
                                           EmailID = registration.EmailID,
                                           Mobileno = registration.Mobileno,
                                           Username = registration.Username
                                       });

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                IQueryabletimesheet = IQueryabletimesheet.OrderBy(sortColumn + " " + sortColumnDir);
            }
            if (!string.IsNullOrEmpty(Search))
            {
                IQueryabletimesheet = IQueryabletimesheet.Where(m => m.Name == Search);
            }

            return IQueryabletimesheet;

        }

        public RegistrationViewDetailsModel GetAdminDetailsByRegistrationID(int? RegistrationID)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDBEntities"].ToString()))
            {
                con.Open();
                try
                {
                    var param = new DynamicParameters();
                    param.Add("@RegistrationID", RegistrationID);
                    return con.Query<RegistrationViewDetailsModel>("Usp_GetAdminDetailsByRegistrationID", param, null, true, 0, System.Data.CommandType.StoredProcedure).SingleOrDefault();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public IQueryable<RegistrationViewSummaryModel> ShowallUsersUnderAdmin(string sortColumn, string sortColumnDir, string Search, int? RegistrationID)
        {
            var _context = new DatabaseContext();

            var IQueryabletimesheet = (from registration in _context.Registration
                                       join AssignedRoles in _context.AssignedRoles on registration.RegistrationID equals AssignedRoles.RegistrationID
                                       where registration.RoleID == 2 && AssignedRoles.AssignToAdmin == RegistrationID
                                       select new RegistrationViewSummaryModel
                                       {
                                           Name = registration.Name,
                                           RegistrationID = registration.RegistrationID,
                                           EmailID = registration.EmailID,
                                           Mobileno = registration.Mobileno,
                                           Username = registration.Username
                                       });

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                IQueryabletimesheet = IQueryabletimesheet.OrderBy(sortColumn + " " + sortColumnDir);
            }
            if (!string.IsNullOrEmpty(Search))
            {
                IQueryabletimesheet = IQueryabletimesheet.Where(m => m.Name == Search);
            }

            return IQueryabletimesheet;

        }

        public int GetTotalAdminsCount()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDBEntities"].ToString()))
            {
                var Count = con.Query<int>("Usp_GetAdminCount", null, null, true, 0, System.Data.CommandType.StoredProcedure).FirstOrDefault();
                if (Count > 0)
                {
                    return Count;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int GetTotalUsersCount()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDBEntities"].ToString()))
            {
                var Count = con.Query<int>("Usp_GetUsersCount", null, null, true, 0, System.Data.CommandType.StoredProcedure).FirstOrDefault();
                if (Count > 0)
                {
                    return Count;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int GetUserIDbyTimesheetID(int TimeSheetMasterID)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDBEntities"].ToString()))
            {
                var para = new DynamicParameters();
                para.Add("@TimeSheetMasterID", TimeSheetMasterID);
                var Count = con.Query<int>("GetUserIDbyTimeSheetID", para, null, true, 0, System.Data.CommandType.StoredProcedure).FirstOrDefault();
                if (Count > 0)
                {
                    return Count;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int GetUserIDbyExpenseID(int ExpenseID)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDBEntities"].ToString()))
            {
                var para = new DynamicParameters();
                para.Add("@ExpenseID", ExpenseID);
                var Count = con.Query<int>("GetUserIDbyExpenseID", para, null, true, 0, System.Data.CommandType.StoredProcedure).FirstOrDefault();
                if (Count > 0)
                {
                    return Count;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int GetAdminIDbyUserID(int UserID)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDBEntities"].ToString()))
            {
                var para = new DynamicParameters();
                para.Add("@UserID", UserID);
                var Count = con.Query<int>("Usp_GetAdminIDbyUserID", para, null, true, 0, System.Data.CommandType.StoredProcedure).FirstOrDefault();
                if (Count > 0)
                {
                    return Count;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
