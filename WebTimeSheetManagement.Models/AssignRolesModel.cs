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
    public class AssignRolesModel
    {
        public List<AdminModel> ListofAdmins { get; set; }

        [Required(ErrorMessage = "Choose Admin")]
        public int RegistrationID { get; set; }
        public List<UserModel> ListofUser { get; set; }
        public int? AssignToAdmin { get; set; }
        public int? CreatedBy { get; set; }
        
    }

    [NotMapped]
    public class AdminModel
    {
        public string RegistrationID { get; set; }
        public string Name { get; set; }
    }

    [NotMapped]
    public class UserModel
    {
        public int RegistrationID { get; set; }
        public string Name { get; set; }
        public bool selectedUsers { get; set; }
        public string AssignToAdmin { get; set; }

    }
}
