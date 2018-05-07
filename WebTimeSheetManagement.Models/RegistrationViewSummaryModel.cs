using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTimeSheetManagement.Models
{
    [NotMapped]
    public class RegistrationViewSummaryModel
    {
        public int RegistrationID { get; set; }
        public string Name { get; set; }
        public string Mobileno { get; set; }
        public string EmailID { get; set; }
        public string Username { get; set; }
        public string AssignToAdmin { get; set; }
        
    }
}
