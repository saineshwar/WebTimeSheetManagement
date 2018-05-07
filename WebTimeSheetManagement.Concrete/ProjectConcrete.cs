using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTimeSheetManagement.Interface;
using WebTimeSheetManagement.Models;
using System.Linq.Dynamic;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace WebTimeSheetManagement.Concrete
{
    public class ProjectConcrete : IProject
    {
        public bool CheckProjectCodeExists(string ProjectCode)
        {
            try
            {
                using (var _context = new DatabaseContext())
                {
                    var result = (from user in _context.ProjectMaster
                                  where user.ProjectCode == ProjectCode
                                  select user).Count();

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

        public bool CheckProjectNameExists(string ProjectName)
        {
            try
            {
                using (var _context = new DatabaseContext())
                {
                    var result = (from user in _context.ProjectMaster
                                  where user.ProjectName == ProjectName
                                  select user).Count();

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

        public List<ProjectMaster> GetListofProjects()
        {
            try
            {
                using (var _context = new DatabaseContext())
                {
                    var listofProjects = (from project in _context.ProjectMaster
                                          select project).ToList();
                    return listofProjects;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int SaveProject(ProjectMaster ProjectMaster)
        {
            try
            {
                using (var _context = new DatabaseContext())
                {
                    _context.ProjectMaster.Add(ProjectMaster);
                    return _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<ProjectMaster> ShowProjects(string sortColumn, string sortColumnDir, string Search)
        {
            var _context = new DatabaseContext();

            var IQueryableproject = (from projectmaster in _context.ProjectMaster
                                     select projectmaster);

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                IQueryableproject = IQueryableproject.OrderBy(sortColumn + " " + sortColumnDir);
            }
            if (!string.IsNullOrEmpty(Search))
            {
                IQueryableproject = IQueryableproject.Where(m => m.ProjectName == Search || m.ProjectCode == Search);
            }

            return IQueryableproject;

        }

        public bool CheckProjectIDExistsInTimesheet(int ProjectID)
        {
            try
            {
                using (var _context = new DatabaseContext())
                {
                    var result = (from timesheet in _context.TimeSheetDetails
                                  where timesheet.ProjectID == ProjectID
                                  select timesheet).Count();

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

        public bool CheckProjectIDExistsInExpense(int ProjectID)
        {
            try
            {
                using (var _context = new DatabaseContext())
                {
                    var result = (from expense in _context.ExpenseModel
                                  where expense.ProjectID == ProjectID
                                  select expense).Count();

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

        public int ProjectDelete(int ProjectID)
        {
            try
            {
                using (var _context = new DatabaseContext())
                {
                    var project = (from expense in _context.ProjectMaster
                                   where expense.ProjectID == ProjectID
                                   select expense).SingleOrDefault(); ;

                    if (project != null)
                    {
                        _context.ProjectMaster.Remove(project);
                        int resultProject = _context.SaveChanges();
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GetTotalProjectsCounts()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDBEntities"].ToString()))
            {
                var Count = con.Query<int>("Usp_GetProjectCount", null, null, true, 0, System.Data.CommandType.StoredProcedure).FirstOrDefault();
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
