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
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Enter Old Password")]
        [MinLength(7, ErrorMessage = "Minimum Password must be 7 in charaters")]
        public string OldPassword { get; set; }

        [MinLength(7, ErrorMessage = "Minimum Password must be 7 in charaters")]
        [Required(ErrorMessage = "Enter New Password")]
        public string NewPassword { get; set; }
    }
}
