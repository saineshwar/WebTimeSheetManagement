using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTimeSheetManagement.Models
{
    [Table("TimeSheetAuditTB")]
    public class TimeSheetAuditTB
    {
        [Key]
        public int ApprovalTimeSheetLogID { get; set; }
        public int ApprovalUser { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string Comment { get; set; }
        public int Status { get; set; }
        public int TimeSheetID { get; set; }
        public int UserID { get; set; }
    }

    [Table("ExpenseAuditTB")]
    public class ExpenseAuditTB
    {
        [Key]
        public int ApprovaExpenselLogID { get; set; }
        public int ApprovalUser { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string Comment { get; set; }
        public int Status { get; set; }
        public int ExpenseID { get; set; }
        public int UserID { get; set; }
    }



}
