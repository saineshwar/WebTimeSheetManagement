using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTimeSheetManagement.Models
{
    public class RegistrationViewDetailsModel
    {
        public string EmployeeID { get; set; }
        public int RegistrationID { get; set; }
        public string Name { get; set; }
        public string Mobileno { get; set; }
        public string EmailID { get; set; }
        public string Username { get; set; }
        public string Birthdate { get; set; }
        public string DateofJoining { get; set; }
        public string Gender { get; set; }    
    }
}
