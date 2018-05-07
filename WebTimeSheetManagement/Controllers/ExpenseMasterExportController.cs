using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebTimeSheetManagement.Concrete;
using WebTimeSheetManagement.Filters;
using WebTimeSheetManagement.Interface;
using WebTimeSheetManagement.Models;

namespace WebTimeSheetManagement.Controllers
{
    [ValidateSuperAdminSession]
    public class ExpenseMasterExportController : Controller
    {

        IExpenseExport _IExpenseExport;
        public ExpenseMasterExportController()
        {
            _IExpenseExport = new ExpenseExportConcrete();
        }

        // GET: ExpenseExport
        public ActionResult Report()
        {
            return View(new ExpenseExcelExportModel());
        }

        // GET: TimeSheetExport
        [HttpPost]
        public ActionResult ExportToExcel(ExpenseExcelExportModel objexpense)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {

                if (!ModelState.IsValid)
                {
                    return View("Report", objexpense);
                }

                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("ProjectName", typeof(string));
                dt.Columns.Add("PurposeorReason", typeof(string));
                dt.Columns.Add("TotalAmount", typeof(string));
                dt.Columns.Add("Status", typeof(string));
                dt.Columns.Add("Comment", typeof(string));
                dt.Columns.Add("FromDate", typeof(string));
                dt.Columns.Add("ToDate", typeof(string));
                dt.Columns.Add("VoucherID", typeof(string));
                dt.Columns.Add("HotelBills", typeof(string));
                dt.Columns.Add("TravelBills", typeof(string));
                dt.Columns.Add("MealsBills", typeof(string));
                dt.Columns.Add("LandLineBills", typeof(string));
                dt.Columns.Add("TransportBills", typeof(string));
                dt.Columns.Add("MobileBills", typeof(string));
                dt.Columns.Add("Miscellaneous", typeof(string));
                dt.Columns.Add("CreatedOn", typeof(string));

                var singlelist = _IExpenseExport.GetAllReportofExpense(objexpense.FromDate, objexpense.ToDate);

                if (singlelist != null)
                {
                    if (singlelist.Tables.Count > 0)
                    {
                        if (singlelist.Tables[0].Rows.Count == 0)
                        {
                            TempData["NoExportMessage"] = "No Data to Export";
                            return View("Report");
                        }
                        else
                        {
                            for (int i = 0; i < singlelist.Tables[0].Rows.Count; i++)
                            {

                                DataRow row = dt.NewRow();
                                row["Name"] = Convert.ToString(singlelist.Tables[0].Rows[i]["Name"]);
                                row["ProjectName"] = Convert.ToString(singlelist.Tables[0].Rows[i]["ProjectName"]);
                                row["PurposeorReason"] = Convert.ToString(singlelist.Tables[0].Rows[i]["PurposeorReason"]);
                                row["Status"] = Convert.ToString(singlelist.Tables[0].Rows[i]["Status"]);
                                row["Comment"] = Convert.ToString(singlelist.Tables[0].Rows[i]["Comment"]);
                                row["FromDate"] = Convert.ToString(singlelist.Tables[0].Rows[i]["FromDate"]);
                                row["ToDate"] = Convert.ToString(singlelist.Tables[0].Rows[i]["ToDate"]);
                                row["VoucherID"] = Convert.ToString(singlelist.Tables[0].Rows[i]["VoucherID"]);
                                row["HotelBills"] = Convert.ToString(singlelist.Tables[0].Rows[i]["HotelBills"]);
                                row["TravelBills"] = Convert.ToString(singlelist.Tables[0].Rows[i]["TravelBills"]);
                                row["MealsBills"] = Convert.ToString(singlelist.Tables[0].Rows[i]["MealsBills"]);
                                row["LandLineBills"] = Convert.ToString(singlelist.Tables[0].Rows[i]["LandLineBills"]);
                                row["TransportBills"] = Convert.ToString(singlelist.Tables[0].Rows[i]["TransportBills"]);
                                row["MobileBills"] = Convert.ToString(singlelist.Tables[0].Rows[i]["MobileBills"]);
                                row["Miscellaneous"] = Convert.ToString(singlelist.Tables[0].Rows[i]["Miscellaneous"]);
                                row["TotalAmount"] = Convert.ToString(singlelist.Tables[0].Rows[i]["TotalAmount"]);
                                row["CreatedOn"] = Convert.ToString(singlelist.Tables[0].Rows[i]["CreatedOn"]);
                                dt.Rows.Add(row);
                            }

                            ds.Tables.Add(dt);
                            var gv = new GridView();
                            gv.DataSource = ds;
                            gv.DataBind();
                            Response.ClearContent();
                            Response.Buffer = true;
                            Response.AddHeader("content-disposition", "attachment; filename=ExpenseSheet.xls");
                            Response.ContentType = "application/ms-excel";
                            Response.Charset = "";
                            StringWriter objStringWriter = new StringWriter();
                            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
                            gv.RenderControl(objHtmlTextWriter);
                            Response.Output.Write(objStringWriter.ToString());
                            Response.Flush();
                            Response.End();
                            return View("Report");
                        }
                    }
                }

                TempData["NoExportMessage"] = "No Data to Export";
                return View("Report");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ds.Dispose();
            }
        }
    }
}