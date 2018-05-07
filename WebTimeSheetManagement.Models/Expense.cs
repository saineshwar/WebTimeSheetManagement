using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTimeSheetManagement.Models
{
    [Table("Expense")]
    public class ExpenseModel
    {
        [Key]
        public int ExpenseID { get; set; }

        [Display(Name = "Project")]
        [Required(ErrorMessage = "Choose Project")]
        public int? ProjectID { get; set; }

        [Display(Name = "Purpose / Reason")]
        [Required(ErrorMessage = "Please Enter Purpose/Reason")]
        public string PurposeorReason { get; set; }
        public int ExpenseStatus { get; set; } //   1 [Submitted] ,2 [Approve]  3 [Reject] .

        [Display(Name = "Expense From Date")]
        [Required(ErrorMessage = "Please Choose From Date")]
        public DateTime? FromDate { get; set; }

        [Display(Name = "Expense To Date")]
        [Required(ErrorMessage = "Please Choose To Date")]
        public DateTime? ToDate { get; set; }
        public int UserID { get; set; }
        public DateTime? CreatedOn { get; set; }

        [Display(Name = "Expense ID / Voucher ID")]
        public string VoucherID { get; set; }

        [Display(Name = "Hotel")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        public int? HotelBills { get; set; }

        [Display(Name = "Travel")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        public int? TravelBills { get; set; }

        [Display(Name = "Meals")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        public int? MealsBills { get; set; }

        [Display(Name = "Land Line bills")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        public int? LandLineBills { get; set; }

        [Display(Name = "Transport expense")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        public int? TransportBills { get; set; }

        [Display(Name = "Mobile bills")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        public int? MobileBills { get; set; }

        [Display(Name = "Miscellaneous expense")]
        public int? Miscellaneous { get; set; }

        [Display(Name = "Total Amount")]
        public int? TotalAmount { get; set; }

        [NotMapped]
        [Display(Name = "Attachments")]
        public string FileName { get; set; }
        public string Comment { get; set; }

    }
}
