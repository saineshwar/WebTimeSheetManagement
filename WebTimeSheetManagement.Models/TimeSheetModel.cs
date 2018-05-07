using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTimeSheetManagement.Models
{
    [NotMapped]
    public class TimeSheetModel
    {
        public DateTime hdtext1 { get; set; }
        public DateTime hdtext2 { get; set; }
        public DateTime hdtext3 { get; set; }
        public DateTime hdtext4 { get; set; }
        public DateTime hdtext5 { get; set; }
        public DateTime hdtext6 { get; set; }
        public DateTime hdtext7 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text1_p1 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text2_p1 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text3_p1 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text4_p1 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text5_p1 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text6_p1 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "P0 to 24")]
        public int? text7_p1 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        public int? texttotal_p1 { get; set; }

        [StringLength(50, ErrorMessage = "Length Exceeds")]
        public string Description_p1 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text1_p2 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text2_p2 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text3_p2 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text4_p2 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text5_p2 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text6_p2 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text7_p2 { get; set; }


        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        public int? texttotal_p2 { get; set; }

        [StringLength(50, ErrorMessage = "Length Exceeds")]
        public string Description_p2 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text1_p3 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text2_p3 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text3_p3 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text4_p3 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text5_p3 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text6_p3 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text7_p3 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        public int? texttotal_p3 { get; set; }

        [StringLength(50, ErrorMessage = "Length Exceeds")]
        public string Description_p3 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text1_p4 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text2_p4 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text3_p4 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text4_p4 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text5_p4 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text6_p4 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text7_p4 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        public int? texttotal_p4 { get; set; }

        [StringLength(50, ErrorMessage = "Length Exceeds")]
        public string Description_p4 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text1_p5 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text2_p5 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text3_p5 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text4_p5 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text5_p5 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text6_p5 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text7_p5 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        public int? texttotal_p5 { get; set; }

        [StringLength(50, ErrorMessage = "Length Exceeds")]
        public string Description_p5 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text1_p6 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text2_p6 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text3_p6 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text4_p6 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text5_p6 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text6_p6 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        [Range(0, 24, ErrorMessage = "0 to 24")]
        public int? text7_p6 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Enter Only Numbers")]
        public int? texttotal_p6 { get; set; }

        [StringLength(50, ErrorMessage = "Length Exceeds")]
        public string Description_p6 { get; set; }

        public string DaysofWeek1 { get; set; }
        public string DaysofWeek2 { get; set; }
        public string DaysofWeek3 { get; set; }
        public string DaysofWeek4 { get; set; }
        public string DaysofWeek5 { get; set; }
        public string DaysofWeek6 { get; set; }
        public string DaysofWeek7 { get; set; }

        [Required(ErrorMessage = "Choose Project")]
        public int? ProjectID1 { get; set; }
        public int? ProjectID2 { get; set; }
        public int? ProjectID3 { get; set; }
        public int? ProjectID4 { get; set; }
        public int? ProjectID5 { get; set; }
        public int? ProjectID6 { get; set; }
        public int? ProjectID7 { get; set; }

    }
}
