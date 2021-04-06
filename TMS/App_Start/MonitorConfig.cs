using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using System.IO;
//using Ionic.Zip;




 
using System.Web.Mvc;


using Syncfusion.XlsIO;
using System.Data;
using System.Collections;
using System.Reflection;
using System.Web.Script.Serialization;
 
using System.Security.Cryptography;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using Syncfusion.XlsIO.Implementation;
using Syncfusion.JavaScript.Shared.Serializer;
using Syncfusion.JavaScript.Models;
using Syncfusion.EJ.Export;
using Syncfusion.XlsIO.Implementation.Collections;

namespace TMS.App_Start
{
    public class MonitorConfig
    {
        public static void RegisterWatchers()
        {
            var fsw = new FileSystemWatcher
            {
               // Filter = "*.zip",
                Filter = "*.xl*",
                Path = ConfigurationManager.AppSettings["watchDirectoryPath"],
                EnableRaisingEvents = true,
                IncludeSubdirectories = false
            };

            fsw.Created += new FileSystemEventHandler(OnCreated);
        }

        static void OnCreated(object sender, FileSystemEventArgs e)
        {
            string excelToImport = e.FullPath;
            string unpackDirectory = ConfigurationManager.AppSettings["unpackDirectory"];

            List<SMCData> list = new List<SMCData>();
            list = ConvertData(excelToImport);


            //using (ZipFile zip = ZipFile.Read(zipToUnpack))
            //{
            //    foreach (ZipEntry ze in zip)
            //    {
            //        ze.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
            //    }
            //}
        }

        private static List<SMCData> ConvertData(string file)
        {
            string filePath= file;//= Server.MapPath("~/Files/" + fileName);
           // filePath = @"C:\Software Development\InfoTronics\MASCIS\mascis_tools_14-05-2018\" + file;

            List<SMCData> list = new List<SMCData>();
            SMCData smcobj = new SMCData();

            ExcelEngine excelEngine = new ExcelEngine();
            IWorkbook workbook = excelEngine.Excel.Workbooks.Open(file);
            IWorksheet worksheet = workbook.Worksheets[0];


            for (int row = 9; row <= worksheet.UsedRange.LastRow; row++)
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

}