using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTimeSheetManagement.Interface;
using WebTimeSheetManagement.Models;
using System.Linq.Dynamic;

namespace WebTimeSheetManagement.Concrete
{
    public class AssignRolesConcrete : IAssignRoles
    {
        public List<AdminModel> ListofAdmins()
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDBEntities"].ToString()))
            {
                con.Open();
                try
                {
                    var result = con.Query<AdminModel>("Usp_GetListofAdmins", null, null, true, 0, System.Data.CommandType.StoredProcedure).ToList();
                    result.Insert(0, new AdminModel { Name = "----Select----", RegistrationID = "" });
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<UserModel> ListofUser()
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDBEntities"].ToString()))
            {
                con.Open();
                try
                {
                    var result = con.Query<UserModel>("Usp_GetListofUsers", null, null, true, 0, System.Data.CommandType.StoredProcedure).ToList();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public int UpdateAssigntoAdmin(string AssignToAdminID, string UserID)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDBEntities"].ToString()))
            {
                con.Open();
                try
                {
                    var param = new DynamicParameters();
                    param.Add("@AssignTo", AssignToAdminID);
                    param.Add("@RegistrationID", UserID);
                    var result = con.Execute("Usp_UpdateAssignToUser", param, null, 0, System.Data.CommandType.StoredProcedure);
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public IQueryable<UserModel> ShowallRoles(string sortColumn, string sortColumnDir, string Search)
        {
            var _context = new DatabaseContext();

            var IQueryabletimesheet = (from AssignedRoles in _context.AssignedRoles
                                       join registration in _context.Registration on AssignedRoles.RegistrationID equals registration.RegistrationID
                                       join AssignedRolesAdmin in _context.Registration on AssignedRoles.AssignToAdmin equals AssignedRolesAdmin.RegistrationID
                                       select new UserModel
                                       {
                                           Name = registration.Name,
                                           AssignToAdmin = string.IsNullOrEmpty(AssignedRolesAdmin.Name) ? "*Not Assigned*" : AssignedRolesAdmin.Name.ToUpper(),
                                           RegistrationID = registration.RegistrationID

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

        public bool RemovefromUserRole(string RegistrationID)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDBEntities"].ToString()))
            {
                con.Open();
                try
                {
                    var param = new DynamicParameters();
                    param.Add("@RegistrationID", RegistrationID);
                    var result = con.Execute("Usp_UpdateUserRole", param, null, 0, System.Data.CommandType.StoredProcedure);
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<UserModel> GetListofUnAssignedUsers()
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDBEntities"].ToString()))
            {
                con.Open();
                try
                {
                    var result = con.Query<UserModel>("Usp_GetListofUnAssignedUsers", null, null, true, 0, System.Data.CommandType.StoredProcedure).ToList();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public bool SaveAssignedRoles(AssignRolesModel AssignRolesModel)
        {
            bool result = false;
            using (var _context = new DatabaseContext())
            {
                try
                {
                    for (int i = 0; i < AssignRolesModel.ListofUser.Count(); i++)
                    {
                        if (AssignRolesModel.ListofUser[i].selectedUsers)
                        {
                            AssignedRoles AssignedRoles = new AssignedRoles
                            {
                                AssignedRolesID = 0,
                                AssignToAdmin = AssignRolesModel.RegistrationID,
                                CreatedOn = DateTime.Now,
                                CreatedBy = AssignRolesModel.CreatedBy,
                                Status = "A",
                                RegistrationID = AssignRolesModel.ListofUser[i].RegistrationID
                            };

                            _context.AssignedRoles.Add(AssignedRoles);
                            _context.SaveChanges();
                        }
                    }

                    result = true;
                }
                catch (Exception)
                {
                    throw;
                }

                return result;
            }
        }

        public bool CheckIsUserAssignedRole(int RegistrationID)
        {
            var IsassignCount = 0;
            using (var _context = new DatabaseContext())
            {
                IsassignCount = (from assignUser in _context.AssignedRoles
                 where assignUser.RegistrationID == RegistrationID
                 select assignUser).Count();
            }

            if (IsassignCount>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
