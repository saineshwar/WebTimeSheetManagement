using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTimeSheetManagement.Models;

namespace WebTimeSheetManagement.Interface
{
    public interface ILogin
    {
        Registration ValidateUser(string userName, string passWord);
        bool UpdatePassword(string NewPassword, int UserID);
        string GetPasswordbyUserID(int UserID);
    }
}
