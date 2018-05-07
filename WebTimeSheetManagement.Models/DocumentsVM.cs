using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTimeSheetManagement.Models
{
    [NotMapped]
    public class DocumentsVM
    {
        public int DocumentID { get; set; }
        public string DocumentName { get; set; }
        public int ExpenseID { get; set; }
        public string DocumentType { get; set; }
    }
}
