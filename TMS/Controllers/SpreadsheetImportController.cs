using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using Syncfusion.XlsIO;
using System.Data;
using System.Collections;
using System.Reflection;
using System.Web.Script.Serialization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using Syncfusion.XlsIO.Implementation;
using Syncfusion.JavaScript.Shared.Serializer;
using Syncfusion.JavaScript.Models;
using Syncfusion.EJ.Export;
using Syncfusion.XlsIO.Implementation.Collections;

namespace TMS.Controllers
{
    public class SpreadsheetImportController : Controller
    {
        // GET: SpreadsheetImport
        public ActionResult Index()
        {
            ViewBag.FileNameList = GetDDdata();
            return View();
        }

        public ActionResult ImportSMC()
        {
            ViewBag.FileNameList = GetDDdata();
            return View();
        }
        //File Open
        //[AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ImportXLFileInSpreadsheet(string filename)
        {
            ImportRequest importRequest = new ImportRequest();
            string filePath;//= Server.MapPath("~/Files/" + filename);// @"C:\Software Development\InfoTronics\MASCIS\mascis_tools_14-05-2018\ESC Lab tool Sector 4 & 5   2017.xlsx";// Server.MapPath("~/Files/" + filename);
            filePath = @"C:\Software Development\InfoTronics\MASCIS\mascis_tools_14-05-2018\" + filename;
            ////Stream fileStream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read);
            //Stream fileStream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read);
            //importRequest.FileStream = fileStream;
            //var spreadsheetData = Spreadsheet.Open(importRequest);
            //fileStream.Close();

            //Get the data into a list
            List<SMCData> list = new List<SMCData>();
            list = this.ConvertData(filePath);

            //return Content(spreadsheetData);
            return Json(list, JsonRequestBehavior.AllowGet);
            //return Json(list);
        }

        //File Open
        // [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OpenXLFileInSpreadsheet(string filename)
        {
            ImportRequest importRequest = new ImportRequest();
            string filePath;//= Server.MapPath("~/Files/" + filename);// @"C:\Software Development\InfoTronics\MASCIS\mascis_tools_14-05-2018\ESC Lab tool Sector 4 & 5   2017.xlsx";// Server.MapPath("~/Files/" + filename);
            filePath = @"C:\Software Development\InfoTronics\MASCIS\mascis_tools_14-05-2018\" + filename;
            //Stream fileStream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read);
            Stream fileStream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read);
            importRequest.FileStream = fileStream;
            var spreadsheetData = Spreadsheet.Open(importRequest);
            fileStream.Close();

            //Get the data into a list
            List<SMCData> list = new List<SMCData>();
            list = this.ConvertData(filePath);
            // return Content(spreadsheetData);
            ViewBag.smcData = list;
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        //File Save
        [AcceptVerbs(HttpVerbs.Post)]
        public void SaveSpreadsheetToServer(string fileName, string sheetModel, string sheetData)
        {
            if (fileName.Length > 0)
            {
                string filePath = Server.MapPath("~/Files/" + fileName);
                MemoryStream fileStream = (MemoryStream)Spreadsheet.Save(sheetModel, sheetData, ExportFormat.XLSX, ExcelVersion.Excel2013);
                ExcelEngine excelEngine = new ExcelEngine();
                IApplication application = excelEngine.Excel;

                fileStream.Position = 0; //Reset reader position
                IWorkbook workbook = application.Workbooks.Open(fileStream);
                workbook.SaveAs(filePath);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ReadWriteDBSpreadheetData(string fileName)
        {
            if (fileName.Length > 0)
            {
                string filePath = Server.MapPath("~/Files/" + fileName);
                filePath = @"C:\Software Development\InfoTronics\MASCIS\mascis_tools_14-05-2018\" + fileName;
                //FileStream stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read);
                //ExcelEngine excelEngine = new ExcelEngine();

                List<SMCData> list = new List<SMCData>();

                //IApplication application = excelEngine.Excel;
                //IWorkbook workbook = application.Workbooks.Open(stream);
                //IWorksheet worksheet = workbook.Worksheets[0]; //Sheet 1

                //worksheet.Range["A1"].Text = "Peter Wakabi modified the Values on the Server"; //A1 cell


                //for (int column = 1; column <= worksheet.UsedRange.LastColumn; column++)
                //    if (worksheet.Range[1, column].Value.ToLower() == "#")
                //        for (int row = 2; row <= worksheet.UsedRange.LastRow; row++)
                //            list.Add(new MailData() { MailID = worksheet.Range[row, column].Value.ToString() });
                //workbook.Close();
                //excelEngine.Dispose();

                list = this.ConvertData(filePath);

                //stream.Close();
                //workbook.SaveAs(filePath);
            }
            return Content("A1 cell modified & saved successfully. Please open the '" + fileName + "' to check it!");
        }

        private List<SMCData> ConvertData(string file)
        {
            string filePath;//= Server.MapPath("~/Files/" + fileName);
            filePath = @"C:\Software Development\InfoTronics\MASCIS\mascis_tools_14-05-2018\" + file;

            List<SMCData> list = new List<SMCData>();
            SMCData smcobj = new SMCData();

            ExcelEngine excelEngine = new ExcelEngine();
            IWorkbook workbook = excelEngine.Excel.Workbooks.Open(file);
            IWorksheet worksheet = workbook.Worksheets[0];


            for (int row = 10; row <= worksheet.UsedRange.LastRow; row++)
            {
                for (int column = 1; column <= worksheet.UsedRange.LastColumn; column++)
                {
                    switch (column)
                    {
                        case 1: // Serial No
                            //if (worksheet.Range[1, column].Value.ToLower() == "#")
                            if (worksheet.Range["A6"].Value.ToLower() == "#" && row >= 10 && row <= 93)
                            {
                                string serial = worksheet.Range[row, column].Value.ToString();
                                int serialnum;
                                if (int.TryParse(serial, out serialnum))
                                {
                                    smcobj.SerialNo = serialnum;
                                }
                            }

                            break;
                        case 2: // ProductCode
                            if (worksheet.Range["B6"].Value.ToUpper() == "PRODUCT CODE" && row >= 10 && row <= 93)
                            {
                                string coltext = worksheet.Range[row, column].Value.ToString();
                                int parsenum;
                                if (int.TryParse(coltext, out parsenum))
                                {
                                    smcobj.ProductCode = parsenum;
                                }
                            }

                            break;
                        case 3: // UoM
                            if (worksheet.Range["C6"].Value.ToUpper() == "DESCRIPTION" && row >= 10 && row <= 93)
                            {
                                smcobj.Desc = worksheet.Range[row, column].Value.ToString();
                            }

                            break;
                        case 4: // UOM
                            if (worksheet.Range["D6"].Value.ToUpper().TrimEnd() == "UOM" && row >= 10 && row <= 93)
                            {
                                smcobj.UoM = worksheet.Range[row, column].Value.ToString();
                            }
                            break;
                        case 5: // Opening Balance
                            if (worksheet.Range["E6"].Value.ToUpper().TrimEnd() == "OPENING BALANCE                                           At start of period" && row >= 10 && row <= 93)
                            {
                                string coltext = worksheet.Range[row, column].Value.ToString();
                                float parsenum;
                                if (float.TryParse(coltext, out parsenum))
                                {
                                    smcobj.OpeningBalance = parsenum;
                                }
                            }

                            break;

                        case 6:
                            if (worksheet.Range["F6"].Value.ToUpper() == "QTY RECEIVED" && row >= 10 && row <= 93)
                            {
                                string coltext = worksheet.Range[row, column].Value.ToString();
                                float parsenum;
                                if (float.TryParse(coltext, out parsenum))
                                {
                                    smcobj.QtyReceived = parsenum;
                                }
                            }

                            break;

                        case 7:
                            if (worksheet.Range["G6"].Value.ToUpper() == "CONSUMPTION" && row >= 10 && row <= 93)
                            {
                                string coltext = worksheet.Range[row, column].Value.ToString();
                                float parsenum;
                                if (float.TryParse(coltext, out parsenum))
                                {
                                    smcobj.Consumption = parsenum;
                                }
                            }

                            break;
                        case 8:
                            if (worksheet.Range["H6"].Value.ToUpper() == "LOSSES/" && row >= 10 && row <= 93)
                            {
                                string coltext = worksheet.Range[row, column].Value.ToString();
                                float parsenum;
                                if (float.TryParse(coltext, out parsenum))
                                {
                                    smcobj.Losses = parsenum;
                                }
                            }

                            break;
                        case 9:
                            if (worksheet.Range["I6"].Value.ToUpper() == "TOTAL CLOSING BALANCE" && row >= 10 && row <= 93)
                            {
                                string coltext = worksheet.Range[row, column].Value.ToString();
                                float parsenum;
                                if (float.TryParse(coltext, out parsenum))
                                {
                                    smcobj.ClosingBalance = parsenum;
                                }
                            }

                            break;
                        case 10:
                            if (worksheet.Range["J6"].Value.ToUpper() == "QUANTITY TO ORDER" && row >= 10 && row <= 93)
                            {
                                string coltext = worksheet.Range[row, column].Value.ToString();
                                float parsenum;
                                if (float.TryParse(coltext, out parsenum))
                                {
                                    smcobj.QtyOrder = parsenum;
                                }
                            }

                            break;

                        case 11:
                            if (worksheet.Range["K6"].Value.ToUpper() == "COMMENTS" && row >= 10 && row <= 93)
                            {
                                smcobj.Comments = worksheet.Range[row, column].Value.ToString();
                            }

                            break;
                    }
                }
                list.Add(smcobj);

            }
            workbook.Close();
            excelEngine.Dispose();
            return list;
        }

        public class MailData
        {
            public string MailID { get; set; }
        }


        public class SMCData
        {
            public int SerialNo { get; set; }
            public int ProductCode { get; set; }
            public string Desc { get; set; }
            public string UoM { get; set; }
            public float OpeningBalance { get; set; }
            public float QtyReceived { get; set; }
            public float Consumption { get; set; }
            public float Losses { get; set; }
            public float ClosingBalance { get; set; }
            public float QtyOrder { get; set; }
            public string Comments { get; set; }

        }


        [AcceptVerbs(HttpVerbs.Post)]
        public void ExportToExcel(string sheetModel, string sheetData, string password)
        {
            if (String.IsNullOrEmpty(password))
                Spreadsheet.Save(sheetModel, sheetData, "sample", ExportFormat.XLSX, ExcelVersion.Excel2013);
            else
                Spreadsheet.Save(sheetModel, sheetData, "sample", ExportFormat.XLSX, ExcelVersion.Excel2013, password);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public void ExportToCsv(string sheetModel, string sheetData)
        {
            Spreadsheet.Save(sheetModel, sheetData, "sample", ExportFormat.CSV);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Import(ImportRequest importRequest)
        {
            return Content(Spreadsheet.Open(importRequest));
        }

        public List<SelectListItem> GetDDdata()
        {
            List<SelectListItem> ddDataSource = new List<SelectListItem>();
            string[] files;//= Directory.GetFiles(Server.MapPath("~/Files"));
            files = Directory.GetFiles(@"C:\Software Development\InfoTronics\MASCIS\mascis_tools_14-05-2018\");
            for (int i = 0; i < files.Length; i++)
            {
                string fileName = Path.GetFileName(files[i]);
                ddDataSource.Add(new SelectListItem { Value = fileName, Text = fileName.Replace(".xlsx", "") });
            }
            return ddDataSource;
        }
    }
}