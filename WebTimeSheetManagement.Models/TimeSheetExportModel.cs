using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTimeSheetManagement.Models
{
    public class TimeSheetExportModel
    {
        public int TimeSheetMasterID { get; set; }
        public int TotalHours { get; set; }
        public string Name { get; set; }
    }

    public class GetPeriods
    {
        public string Period { get; set; }
    }

    public class GetProjectNames
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
    }

    public class GetHours
    {
        public int Hours { get; set; }
    }

    public class TimeSheetExcelExportModel
    {
        [Display(Name = "TimeSheet From Date")]
        [Required(ErrorMessage = "Please Choose From Date")]
        public DateTime? FromDate { get; set; }

        [Display(Name = "TimeSheet To Date")]
        [Required(ErrorMessage = "Please Choose To Date")]
        public DateTime? ToDate { get; set; }
    }

    public class ExpenseExcelExportModel
    {
        [Display(Name = "Expense From Date")]
        [Required(ErrorMessage = "Please Choose From Date")]
        public DateTime? FromDate { get; set; }

        [Display(Name = "Expense To Date")]
        [Required(ErrorMessage = "Please Choose To Date")]
        public DateTime? ToDate { get; set; }
    }

    public class TimeSheetExportUserModel
    {
        [Display(Name = "TimeSheet From Date")]
        [Required(ErrorMessage = "Please Choose From Date")]
        public DateTime? FromDate { get; set; }

        [Display(Name = "TimeSheet To Date")]
        [Required(ErrorMessage = "Please Choose To Date")]
        public DateTime? ToDate { get; set; }

        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "Please Select Employee Name")]
        public int RegistrationID { get; set; }
    }

}
