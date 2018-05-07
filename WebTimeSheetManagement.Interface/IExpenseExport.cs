using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTimeSheetManagement.Interface
{
    public interface IExpenseExport
    {
        DataSet GetReportofExpense(DateTime? FromDate, DateTime? ToDate, int UserID);
        DataSet GetAllReportofExpense(DateTime? FromDate, DateTime? ToDate);
    }
}
