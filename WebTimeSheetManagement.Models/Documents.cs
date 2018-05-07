using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTimeSheetManagement.Models
{
    public class Documents
    {
        [Key]
        public int DocumentID { get; set; }
        public string DocumentName { get; set; }
        public byte[] DocumentBytes { get; set; }
        public int UserID { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ExpenseID { get; set; }
        public string DocumentType { get; set; }
        
    }
}
