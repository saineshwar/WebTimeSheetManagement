using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTimeSheetManagement.Concrete;
using WebTimeSheetManagement.Filters;
using WebTimeSheetManagement.Interface;
using WebTimeSheetManagement.Models;

namespace WebTimeSheetManagement.Controllers
{
    [ValidateUserSession]
    public class ExpenseController : Controller
    {
        IExpense _IExpense;
        IDocument _IDocument;
        IProject _IProject;
        IUsers _IUsers;
        public ExpenseController()
        {
            _IExpense = new ExpenseConcrete();
            _IProject = new ProjectConcrete();
            _IDocument = new DocumentConcrete();
            _IUsers = new UsersConcrete();
        }

        // GET: Expense
        public ActionResult Add()
        {
            return View(new ExpenseModel());
        }

        [HttpPost]
        public ActionResult Add(ExpenseModel expensemodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Documents Documents = new Documents();

                    if (_IExpense.CheckIsDateAlreadyUsed(expensemodel.FromDate, expensemodel.ToDate, Convert.ToInt32(Session["UserID"])))
                    {
                        ModelState.AddModelError("", "Date you have choosen is already used !");
                        return View(expensemodel);
                    }
                    else
                    {
                        expensemodel.ExpenseID = 0;
                        expensemodel.CreatedOn = DateTime.Now;
                        expensemodel.ExpenseStatus = 1;
                        expensemodel.UserID = Convert.ToInt32(Session["UserID"]);

                        var ExpenseID = _IExpense.AddExpense(expensemodel);
                        if (ExpenseID > 0)
                        {
                            if (Request.Files != null)
                            {
                                foreach (string requestFile in Request.Files)
                                {
                                    HttpPostedFileBase file = Request.Files[requestFile];
                                    {
                                        if (file.ContentLength > 0)
                                        {
                                            string _FileName = Path.GetFileName(file.FileName);
                                            Documents.DocumentID = 0;
                                            Documents.DocumentName = _FileName;
                                            using (var binaryReader = new BinaryReader(file.InputStream))
                                            {
                                                byte[] FileSize = binaryReader.ReadBytes(file.ContentLength);
                                                Documents.DocumentBytes = FileSize;
                                                Documents.CreatedOn = DateTime.Now;
                                            }


                                            Documents.ExpenseID = ExpenseID;
                                            Documents.UserID = Convert.ToInt32(Session["UserID"]);
                                            if (Path.GetExtension(file.FileName) == ".zip" || Path.GetExtension(file.FileName) == ".rar")
                                            {
                                                Documents.DocumentType = "Multi";
                                            }
                                            else
                                            {
                                                Documents.DocumentType = "Single";
                                            }

                                            _IDocument.AddDocument(Documents);
                                        }

                                        TempData["ExpenseMessage"] = "Data Saved Successfully";
                                    }
                                }
                            }
                            _IExpense.InsertExpenseAuditLog(InsertExpenseAudit(ExpenseID, 1));
                        }
                        else
                        {
                            ModelState.AddModelError("", "Please Upload Required Attachments");
                            return View(expensemodel);
                        }

                        ModelState.Clear();
                        return View(new ExpenseModel());
                    }
                }
                return View(new ExpenseModel());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JsonResult ListofProjects()
        {
            try
            {
                var listofProjects = _IProject.GetListofProjects();
                return Json(listofProjects, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private ExpenseAuditTB InsertExpenseAudit(int ExpenseID, int Status)
        {
            try
            {
                ExpenseAuditTB objAuditTB = new ExpenseAuditTB();
                objAuditTB.ApprovaExpenselLogID = 0;
                objAuditTB.ExpenseID = ExpenseID;
                objAuditTB.Status = Status;
                objAuditTB.CreatedOn = DateTime.Now;
                objAuditTB.Comment = string.Empty;
                objAuditTB.ApprovalUser = _IUsers.GetAdminIDbyUserID(Convert.ToInt32(Session["UserID"]));
                objAuditTB.ProcessedDate = DateTime.Now;
                objAuditTB.UserID = Convert.ToInt32(Session["UserID"]);
                return objAuditTB;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}