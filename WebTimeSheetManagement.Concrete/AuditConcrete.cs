using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTimeSheetManagement.Interface;
using WebTimeSheetManagement.Models;

namespace WebTimeSheetManagement.Concrete
{
    public class AuditConcrete : IAudit
    {
        public void InsertAuditData(AuditTB audittb)
        {
            using (var _context = new DatabaseContext())
            {
                _context.AuditTB.Add(audittb);
                _context.SaveChanges();
            }
        }
    }
}
