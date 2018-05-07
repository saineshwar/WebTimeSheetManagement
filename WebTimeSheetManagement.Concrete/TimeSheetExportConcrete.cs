using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WebTimeSheetManagement.Interface;
using WebTimeSheetManagement.Models;

namespace WebTimeSheetManagement.Concrete
{
    public class TimeSheetExportConcrete : ITimeSheetExport
    {
        public DataSet GetReportofTimeSheet(DateTime? FromDate, DateTime? ToDate, int UserID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDBEntities"].ToString()))
                {
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("Usp_GetReportofTimeSheet", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FromDate", FromDate);
                    cmd.Parameters.AddWithValue("@ToDate", ToDate);
                    cmd.Parameters.AddWithValue("@AssignTo", UserID);
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    return ds;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetWeekTimeSheetDetails(int TimeSheetMasterID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDBEntities"].ToString()))
                {
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("Usp_GetWeekTimeSheetDetails", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TimeSheetMasterID", TimeSheetMasterID);
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    return ds;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Registration> ListofEmployees(int UserID)
        {
            using (DatabaseContext _context = new DatabaseContext())
            {
                var listofemployee = (from registration in _context.Registration
                                      join AssignedRolesAdmin in _context.AssignedRoles on registration.RegistrationID equals AssignedRolesAdmin.RegistrationID
                                      where AssignedRolesAdmin.AssignToAdmin == UserID
                                      select registration).ToList();

                return listofemployee;
            }
        }

        public DataSet GetTimeSheetMasterIDTimeSheet(DateTime? FromDate, DateTime? ToDate, int UserID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDBEntities"].ToString()))
                {
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("Usp_GetTimeSheetMasterIDTimeSheet", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FromDate", FromDate);
                    cmd.Parameters.AddWithValue("@ToDate", ToDate);
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    return ds;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetTimeSheetMasterIDTimeSheet(DateTime? FromDate, DateTime? ToDate)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDBEntities"].ToString()))
                {
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("Usp_GetTimeSheetbyFromDateandToDateTimeSheet", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FromDate", FromDate);
                    cmd.Parameters.AddWithValue("@ToDate", ToDate);
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    return ds;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public string GetUsernamebyRegistrationID(int RegistrationID)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDBEntities"].ToString()))
            {
                con.Open();

                try
                {
                    var param = new DynamicParameters();
                    param.Add("@RegistrationID", RegistrationID);
                    var result = con.Query<string>("Usp_GetUsernamebyRegistrationID", param, null, true, 0, System.Data.CommandType.StoredProcedure).SingleOrDefault();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
