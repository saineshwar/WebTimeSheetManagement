using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebTimeSheetManagement.Models;

namespace WebTimeSheetManagement.Helpers
{
    public static class MethodonViews
    {
        public static List<GetHours> GetHoursbyTimeSheetMasterID(int TimeSheetMasterID, int ProjectID)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDBEntities"].ToString()))
            {
                con.Open();
                try
                {
                    var param = new DynamicParameters();
                    param.Add("@TimeSheetMasterID", TimeSheetMasterID);
                    param.Add("@ProjectID", ProjectID);
                    var result = con.Query<GetHours>("Usp_GetHoursbyTimeSheetMasterID", param, null, true, 0, System.Data.CommandType.StoredProcedure).ToList();
                    if (result.Count > 0)
                    {
                        return result;
                    }
                    else
                    {
                        return new List<GetHours>();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static string GetDescriptionbyTimeSheetMasterID(int TimeSheetMasterID, int ProjectID)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDBEntities"].ToString()))
            {
                con.Open();
                try
                {
                    var param = new DynamicParameters();
                    param.Add("@TimeSheetMasterID", TimeSheetMasterID);
                    param.Add("@ProjectID", ProjectID);
                    var result = con.Query<string>("GetDescriptionbyTimeSheetMasterID", param, null, true, 0, System.Data.CommandType.StoredProcedure).FirstOrDefault();
                    if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

    }
}