using System;
using System.Linq;
using WebTimeSheetManagement.Interface;
using WebTimeSheetManagement.Models;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Entity.SqlServer;
using System.Linq.Dynamic;

namespace WebTimeSheetManagement.Concrete
{
    public class ExpenseConcrete : IExpense
    {
        public int AddExpense(ExpenseModel ExpenseModel)
        {
            try
            {
                using (var _context = new DatabaseContext())
                {
                    ExpenseModel.HotelBills = ExpenseModel.HotelBills == null ? 0 : ExpenseModel.HotelBills;
                    ExpenseModel.TravelBills = ExpenseModel.TravelBills == null ? 0 : ExpenseModel.TravelBills;
                    ExpenseModel.MealsBills = ExpenseModel.MealsBills == null ? 0 : ExpenseModel.MealsBills;
                    ExpenseModel.LandLineBills = ExpenseModel.LandLineBills == null ? 0 : ExpenseModel.LandLineBills;
                    ExpenseModel.TransportBills = ExpenseModel.TransportBills == null ? 0 : ExpenseModel.TransportBills;
                    ExpenseModel.MobileBills = ExpenseModel.MobileBills == null ? 0 : ExpenseModel.MobileBills;
                    ExpenseModel.Miscellaneous = ExpenseModel.Miscellaneous == null ? 0 : ExpenseModel.Miscellaneous;

                    _context.ExpenseModel.Add(ExpenseModel);
                    _context.SaveChanges();
                    int id = ExpenseModel.ExpenseID;
                    return id;
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        public bool CheckIsDateAlreadyUsed(DateTime? FromDate, DateTime? ToDate, int UserID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDBEntities"].ToString()))
                {
                    var param = new DynamicParameters();
                    param.Add("@FromDate", FromDate);
                    param.Add("@ToDate", ToDate);
                    param.Add("@UserID", UserID);

                    var result = con.Query<int>("Usp_CheckIsDateAlreadyUsed", param, null, false, 0, System.Data.CommandType.StoredProcedure).SingleOrDefault();
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<ExpenseModelView> ShowExpense(string sortColumn, string sortColumnDir, string Search, int UserID)
        {
            var _context = new DatabaseContext();

            var IQueryabletimesheet = (from expense in _context.ExpenseModel
                                       where expense.UserID == UserID
                                       select new ExpenseModelView
                                       {
                                           ExpenseID = expense.ExpenseID,
                                           FromDate = SqlFunctions.DateName("day", expense.FromDate).Trim() + "/" +
                   SqlFunctions.StringConvert((double)expense.FromDate.Value.Month).TrimStart() + "/" +
                   SqlFunctions.DateName("year", expense.FromDate),
                                           ToDate = SqlFunctions.DateName("day", expense.ToDate).Trim() + "/" +
                   SqlFunctions.StringConvert((double)expense.ToDate.Value.Month).TrimStart() + "/" +
                   SqlFunctions.DateName("year", expense.ToDate),

                                           CreatedOn = SqlFunctions.DateName("day", expense.CreatedOn).Trim() + "/" +
                   SqlFunctions.StringConvert((double)expense.CreatedOn.Value.Month).TrimStart() + "/" +
                   SqlFunctions.DateName("year", expense.CreatedOn),

                                           ExpenseStatus = expense.ExpenseStatus == 1 ? "Submitted" : expense.ExpenseStatus == 2 ? "Approved" : "Rejected",
                                           HotelBills = expense.HotelBills,
                                           LandLineBills = expense.LandLineBills,
                                           MealsBills = expense.MealsBills,
                                           Miscellaneous = expense.Miscellaneous,
                                           MobileBills = expense.MobileBills,
                                           PurposeorReason = expense.PurposeorReason,
                                           TotalAmount = expense.TotalAmount,
                                           TransportBills = expense.TransportBills,
                                           TravelBills = expense.TravelBills,
                                           VoucherID = expense.VoucherID,
                                       });

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                IQueryabletimesheet = IQueryabletimesheet.OrderBy(sortColumn + " " + sortColumnDir);
            }
            if (!string.IsNullOrEmpty(Search))
            {
                IQueryabletimesheet = IQueryabletimesheet.Where(m => m.FromDate == Search);
            }

            return IQueryabletimesheet;

        }

        public bool IsExpenseSubmitted(int ExpenseID, int UserID)
        {
            using (var _context = new DatabaseContext())
            {
                var data = (from expense in _context.ExpenseModel
                            where expense.ExpenseID == ExpenseID && expense.UserID == UserID
                            select expense).Count();

                if (data > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public int DeleteExpensetByExpenseID(int ExpenseID ,int UserID)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDBEntities"].ToString()))
                {
                    var param = new DynamicParameters();
                    param.Add("@ExpenseID", ExpenseID);
                    param.Add("@UserID", UserID);
                    return con.Execute("Usp_DeleteExpenseandDocuments", param, null, 0, System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IQueryable<ExpenseModelView> ShowAllExpense(string sortColumn, string sortColumnDir, string Search, int UserID)
        {
            var _context = new DatabaseContext();

            var IQueryabletimesheet = (from expense in _context.ExpenseModel
                                       join project in _context.ProjectMaster on expense.ProjectID equals project.ProjectID
                                       join registration in _context.Registration on expense.UserID equals registration.RegistrationID
                                       join AssignedRolesAdmin in _context.AssignedRoles on registration.RegistrationID equals AssignedRolesAdmin.RegistrationID
                                       where AssignedRolesAdmin.AssignToAdmin == UserID
                                       select new ExpenseModelView
                                       {
                                           ExpenseID = expense.ExpenseID,
                                           ProjectName = project.ProjectName,
                                           FromDate = SqlFunctions.DateName("day", expense.FromDate).Trim() + "/" +
                   SqlFunctions.StringConvert((double)expense.FromDate.Value.Month).TrimStart() + "/" +
                   SqlFunctions.DateName("year", expense.FromDate),
                                           ToDate = SqlFunctions.DateName("day", expense.ToDate).Trim() + "/" +
                   SqlFunctions.StringConvert((double)expense.ToDate.Value.Month).TrimStart() + "/" +
                   SqlFunctions.DateName("year", expense.ToDate),

                                           CreatedOn = SqlFunctions.DateName("day", expense.CreatedOn).Trim() + "/" +
                   SqlFunctions.StringConvert((double)expense.CreatedOn.Value.Month).TrimStart() + "/" +
                   SqlFunctions.DateName("year", expense.CreatedOn),

                                           ExpenseStatus = expense.ExpenseStatus == 1 ? "Submitted" : expense.ExpenseStatus == 2 ? "Approved" : "Rejected",
                                           HotelBills = expense.HotelBills,
                                           LandLineBills = expense.LandLineBills,
                                           MealsBills = expense.MealsBills,
                                           Miscellaneous = expense.Miscellaneous,
                                           MobileBills = expense.MobileBills,
                                           PurposeorReason = expense.PurposeorReason,
                                           TotalAmount = expense.TotalAmount,
                                           TransportBills = expense.TransportBills,
                                           TravelBills = expense.TravelBills,
                                           VoucherID = expense.VoucherID,
                                       });

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                IQueryabletimesheet = IQueryabletimesheet.OrderBy(sortColumn + " " + sortColumnDir);
            }
            if (!string.IsNullOrEmpty(Search))
            {
                IQueryabletimesheet = IQueryabletimesheet.Where(m => m.FromDate == Search);
            }

            return IQueryabletimesheet;

        }

        public ExpenseModelView ExpenseDetailsbyExpenseID(int ExpenseID)
        {
            try
            {
                using (DatabaseContext _context = new DatabaseContext())
                {

                    var resultExpense = (from expense in _context.ExpenseModel
                                         where expense.ExpenseID == ExpenseID
                                         join project in _context.ProjectMaster on expense.ProjectID equals project.ProjectID
                                         select new ExpenseModelView
                                         {
                                             ExpenseID = expense.ExpenseID,
                                             ProjectName = project.ProjectName,
                                             FromDate = SqlFunctions.DateName("day", expense.FromDate).Trim() + "/" +
                     SqlFunctions.StringConvert((double)expense.FromDate.Value.Month).TrimStart() + "/" +
                     SqlFunctions.DateName("year", expense.FromDate),
                                             ToDate = SqlFunctions.DateName("day", expense.ToDate).Trim() + "/" +
                     SqlFunctions.StringConvert((double)expense.ToDate.Value.Month).TrimStart() + "/" +
                     SqlFunctions.DateName("year", expense.ToDate),

                                             CreatedOn = SqlFunctions.DateName("day", expense.CreatedOn).Trim() + "/" +
                     SqlFunctions.StringConvert((double)expense.CreatedOn.Value.Month).TrimStart() + "/" +
                     SqlFunctions.DateName("year", expense.CreatedOn),

                                             ExpenseStatus = expense.ExpenseStatus == 1 ? "Submitted" : expense.ExpenseStatus == 2 ? "Approved" : "Rejected",
                                             HotelBills = expense.HotelBills,
                                             LandLineBills = expense.LandLineBills,
                                             MealsBills = expense.MealsBills,
                                             Miscellaneous = expense.Miscellaneous,
                                             MobileBills = expense.MobileBills,
                                             PurposeorReason = expense.PurposeorReason,
                                             TotalAmount = expense.TotalAmount,
                                             TransportBills = expense.TransportBills,
                                             TravelBills = expense.TravelBills,
                                             VoucherID = expense.VoucherID,
                                             Comment = expense.Comment
                                         }).FirstOrDefault();

                    return resultExpense;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateExpenseStatus(ExpenseApprovalModel ExpenseApprovalModel, int ExpenseStatus)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDBEntities"].ToString()))
            {
                con.Open();
                SqlTransaction sql = con.BeginTransaction();

                try
                {
                    var param = new DynamicParameters();
                    param.Add("@ExpenseID", ExpenseApprovalModel.ExpenseID);
                    param.Add("@Comment", ExpenseApprovalModel.Comment);
                    param.Add("@ExpenseStatus", ExpenseStatus);
                    var result = con.Execute("Usp_UpdateExpenseStatus", param, sql, 0, System.Data.CommandType.StoredProcedure);
                    if (result > 0)
                    {
                        sql.Commit();
                        return true;
                    }
                    else
                    {
                        sql.Rollback();
                        return false;
                    }
                }
                catch (Exception)
                {
                    sql.Rollback();
                    throw;
                }
            }
        }

        public void InsertExpenseAuditLog(ExpenseAuditTB expenseaudittb)
        {
            try
            {
                using (var _context = new DatabaseContext())
                {
                    _context.ExpenseAuditTB.Add(expenseaudittb);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DisplayViewModel GetExpenseAuditCountByAdminID(string AdminID)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDBEntities"].ToString()))
            {
                var param = new DynamicParameters();
                param.Add("@AdminID", AdminID);
                return con.Query<DisplayViewModel>("Usp_GetExpenseAuditCountByAdminID", param, null, true, 0, System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public IQueryable<ExpenseModelView> ShowAllSubmittedExpense(string sortColumn, string sortColumnDir, string Search, int UserID)
        {
            var _context = new DatabaseContext();

            var IQueryabletimesheet = (from expense in _context.ExpenseModel
                                       join expenseaudittb in _context.ExpenseAuditTB on expense.ExpenseID equals expenseaudittb.ExpenseID
                                       join project in _context.ProjectMaster on expense.ProjectID equals project.ProjectID
                                       join registration in _context.Registration on expense.UserID equals registration.RegistrationID
                                       join AssignedRolesAdmin in _context.AssignedRoles on registration.RegistrationID equals AssignedRolesAdmin.RegistrationID
                                       where AssignedRolesAdmin.AssignToAdmin == UserID && expenseaudittb.Status == 1
                                       select new ExpenseModelView
                                       {
                                           ExpenseID = expense.ExpenseID,
                                           ProjectName = project.ProjectName,
                                           FromDate = SqlFunctions.DateName("day", expense.FromDate).Trim() + "/" +
                   SqlFunctions.StringConvert((double)expense.FromDate.Value.Month).TrimStart() + "/" +
                   SqlFunctions.DateName("year", expense.FromDate),
                                           ToDate = SqlFunctions.DateName("day", expense.ToDate).Trim() + "/" +
                   SqlFunctions.StringConvert((double)expense.ToDate.Value.Month).TrimStart() + "/" +
                   SqlFunctions.DateName("year", expense.ToDate),

                                           CreatedOn = SqlFunctions.DateName("day", expense.CreatedOn).Trim() + "/" +
                   SqlFunctions.StringConvert((double)expense.CreatedOn.Value.Month).TrimStart() + "/" +
                   SqlFunctions.DateName("year", expense.CreatedOn),

                                           ExpenseStatus = expense.ExpenseStatus == 1 ? "Submitted" : expense.ExpenseStatus == 2 ? "Approved" : "Rejected",
                                           HotelBills = expense.HotelBills,
                                           LandLineBills = expense.LandLineBills,
                                           MealsBills = expense.MealsBills,
                                           Miscellaneous = expense.Miscellaneous,
                                           MobileBills = expense.MobileBills,
                                           PurposeorReason = expense.PurposeorReason,
                                           TotalAmount = expense.TotalAmount,
                                           TransportBills = expense.TransportBills,
                                           TravelBills = expense.TravelBills,
                                           VoucherID = expense.VoucherID,
                                       });

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                IQueryabletimesheet = IQueryabletimesheet.OrderBy(sortColumn + " " + sortColumnDir);
            }
            if (!string.IsNullOrEmpty(Search))
            {
                IQueryabletimesheet = IQueryabletimesheet.Where(m => m.FromDate == Search);
            }

            return IQueryabletimesheet;

        }


        public IQueryable<ExpenseModelView> ShowAllApprovedExpense(string sortColumn, string sortColumnDir, string Search, int UserID)
        {
            var _context = new DatabaseContext();

            var IQueryabletimesheet = (from expense in _context.ExpenseModel
                                       join expenseaudittb in _context.ExpenseAuditTB on expense.ExpenseID equals expenseaudittb.ExpenseID
                                       join project in _context.ProjectMaster on expense.ProjectID equals project.ProjectID
                                       join registration in _context.Registration on expense.UserID equals registration.RegistrationID
                                       join AssignedRolesAdmin in _context.AssignedRoles on registration.RegistrationID equals AssignedRolesAdmin.RegistrationID
                                       where AssignedRolesAdmin.AssignToAdmin == UserID && expenseaudittb.Status == 2
                                       select new ExpenseModelView
                                       {
                                           ExpenseID = expense.ExpenseID,
                                           ProjectName = project.ProjectName,
                                           FromDate = SqlFunctions.DateName("day", expense.FromDate).Trim() + "/" +
                   SqlFunctions.StringConvert((double)expense.FromDate.Value.Month).TrimStart() + "/" +
                   SqlFunctions.DateName("year", expense.FromDate),
                                           ToDate = SqlFunctions.DateName("day", expense.ToDate).Trim() + "/" +
                   SqlFunctions.StringConvert((double)expense.ToDate.Value.Month).TrimStart() + "/" +
                   SqlFunctions.DateName("year", expense.ToDate),

                                           CreatedOn = SqlFunctions.DateName("day", expense.CreatedOn).Trim() + "/" +
                   SqlFunctions.StringConvert((double)expense.CreatedOn.Value.Month).TrimStart() + "/" +
                   SqlFunctions.DateName("year", expense.CreatedOn),

                                           ExpenseStatus = expense.ExpenseStatus == 1 ? "Submitted" : expense.ExpenseStatus == 2 ? "Approved" : "Rejected",
                                           HotelBills = expense.HotelBills,
                                           LandLineBills = expense.LandLineBills,
                                           MealsBills = expense.MealsBills,
                                           Miscellaneous = expense.Miscellaneous,
                                           MobileBills = expense.MobileBills,
                                           PurposeorReason = expense.PurposeorReason,
                                           TotalAmount = expense.TotalAmount,
                                           TransportBills = expense.TransportBills,
                                           TravelBills = expense.TravelBills,
                                           VoucherID = expense.VoucherID,
                                       });

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                IQueryabletimesheet = IQueryabletimesheet.OrderBy(sortColumn + " " + sortColumnDir);
            }
            if (!string.IsNullOrEmpty(Search))
            {
                IQueryabletimesheet = IQueryabletimesheet.Where(m => m.FromDate == Search);
            }

            return IQueryabletimesheet;

        }

        public IQueryable<ExpenseModelView> ShowAllRejectedExpense(string sortColumn, string sortColumnDir, string Search, int UserID)
        {
            var _context = new DatabaseContext();

            var IQueryabletimesheet = (from expense in _context.ExpenseModel
                                       join expenseaudittb in _context.ExpenseAuditTB on expense.ExpenseID equals expenseaudittb.ExpenseID
                                       join project in _context.ProjectMaster on expense.ProjectID equals project.ProjectID
                                       join registration in _context.Registration on expense.UserID equals registration.RegistrationID
                                       join AssignedRolesAdmin in _context.AssignedRoles on registration.RegistrationID equals AssignedRolesAdmin.RegistrationID
                                       where AssignedRolesAdmin.AssignToAdmin == UserID && expenseaudittb.Status == 3
                                       select new ExpenseModelView
                                       {
                                           ExpenseID = expense.ExpenseID,
                                           ProjectName = project.ProjectName,
                                           FromDate = SqlFunctions.DateName("day", expense.FromDate).Trim() + "/" +
                   SqlFunctions.StringConvert((double)expense.FromDate.Value.Month).TrimStart() + "/" +
                   SqlFunctions.DateName("year", expense.FromDate),
                                           ToDate = SqlFunctions.DateName("day", expense.ToDate).Trim() + "/" +
                   SqlFunctions.StringConvert((double)expense.ToDate.Value.Month).TrimStart() + "/" +
                   SqlFunctions.DateName("year", expense.ToDate),

                                           CreatedOn = SqlFunctions.DateName("day", expense.CreatedOn).Trim() + "/" +
                   SqlFunctions.StringConvert((double)expense.CreatedOn.Value.Month).TrimStart() + "/" +
                   SqlFunctions.DateName("year", expense.CreatedOn),

                                           ExpenseStatus = expense.ExpenseStatus == 1 ? "Submitted" : expense.ExpenseStatus == 2 ? "Approved" : "Rejected",
                                           HotelBills = expense.HotelBills,
                                           LandLineBills = expense.LandLineBills,
                                           MealsBills = expense.MealsBills,
                                           Miscellaneous = expense.Miscellaneous,
                                           MobileBills = expense.MobileBills,
                                           PurposeorReason = expense.PurposeorReason,
                                           TotalAmount = expense.TotalAmount,
                                           TransportBills = expense.TransportBills,
                                           TravelBills = expense.TravelBills,
                                           VoucherID = expense.VoucherID,
                                       });

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                IQueryabletimesheet = IQueryabletimesheet.OrderBy(sortColumn + " " + sortColumnDir);
            }
            if (!string.IsNullOrEmpty(Search))
            {
                IQueryabletimesheet = IQueryabletimesheet.Where(m => m.FromDate == Search);
            }

            return IQueryabletimesheet;

        }

        public DisplayViewModel GetExpenseAuditCountByUserID(string UserID)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDBEntities"].ToString()))
            {
                var param = new DynamicParameters();
                param.Add("@UserID", UserID);
                return con.Query<DisplayViewModel>("Usp_GetExpenseAuditCountByUserID", param, null, true, 0, System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public bool UpdateExpenseAuditStatus(int ExpenseID, string Comment, int Status)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDBEntities"].ToString()))
            {
                con.Open();
                SqlTransaction sql = con.BeginTransaction();

                try
                {
                    var param = new DynamicParameters();
                    param.Add("@ExpenseID", ExpenseID);
                    param.Add("@Comment", Comment);
                    param.Add("@Status", Status);
                    var result = con.Execute("Usp_ChangeExpenseStatus", param, sql, 0, System.Data.CommandType.StoredProcedure);
                    if (result > 0)
                    {
                        sql.Commit();
                        return true;
                    }
                    else
                    {
                        sql.Rollback();
                        return false;
                    }
                }
                catch (Exception)
                {
                    sql.Rollback();
                    throw;
                }
            }
        }

        public bool IsExpenseALreadyProcessed(int ExpenseID)
        {
            using (var _context = new DatabaseContext())
            {
                var data = (from timesheet in _context.ExpenseAuditTB
                            where timesheet.ExpenseID == ExpenseID && timesheet.Status != 1
                            select timesheet).Count();

                if (data > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public IQueryable<ExpenseModelView> ShowExpenseStatus(string sortColumn, string sortColumnDir, string Search, int UserID, int ExpenseStatus)
        {
            var _context = new DatabaseContext();

            var IQueryabletimesheet = (from expense in _context.ExpenseModel
                                       join expenseaudittb in _context.ExpenseAuditTB on expense.ExpenseID equals expenseaudittb.ExpenseID
                                       join project in _context.ProjectMaster on expense.ProjectID equals project.ProjectID
                                       join registration in _context.Registration on expense.UserID equals registration.RegistrationID
                                       join AssignedRolesAdmin in _context.AssignedRoles on registration.RegistrationID equals AssignedRolesAdmin.RegistrationID
                                       where expense.UserID == UserID && expenseaudittb.Status == ExpenseStatus
                                       select new ExpenseModelView
                                       {
                                           ExpenseID = expense.ExpenseID,
                                           ProjectName = project.ProjectName,
                                           FromDate = SqlFunctions.DateName("day", expense.FromDate).Trim() + "/" +
                   SqlFunctions.StringConvert((double)expense.FromDate.Value.Month).TrimStart() + "/" +
                   SqlFunctions.DateName("year", expense.FromDate),
                                           ToDate = SqlFunctions.DateName("day", expense.ToDate).Trim() + "/" +
                   SqlFunctions.StringConvert((double)expense.ToDate.Value.Month).TrimStart() + "/" +
                   SqlFunctions.DateName("year", expense.ToDate),

                                           CreatedOn = SqlFunctions.DateName("day", expense.CreatedOn).Trim() + "/" +
                   SqlFunctions.StringConvert((double)expense.CreatedOn.Value.Month).TrimStart() + "/" +
                   SqlFunctions.DateName("year", expense.CreatedOn),

                                           ExpenseStatus = expense.ExpenseStatus == 1 ? "Submitted" : expense.ExpenseStatus == 2 ? "Approved" : "Rejected",
                                           HotelBills = expense.HotelBills,
                                           LandLineBills = expense.LandLineBills,
                                           MealsBills = expense.MealsBills,
                                           Miscellaneous = expense.Miscellaneous,
                                           MobileBills = expense.MobileBills,
                                           PurposeorReason = expense.PurposeorReason,
                                           TotalAmount = expense.TotalAmount,
                                           TransportBills = expense.TransportBills,
                                           TravelBills = expense.TravelBills,
                                           VoucherID = expense.VoucherID,
                                       });

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                IQueryabletimesheet = IQueryabletimesheet.OrderBy(sortColumn + " " + sortColumnDir);
            }
            if (!string.IsNullOrEmpty(Search))
            {
                IQueryabletimesheet = IQueryabletimesheet.Where(m => m.FromDate == Search);
            }

            return IQueryabletimesheet;

        }
    

    }
}
