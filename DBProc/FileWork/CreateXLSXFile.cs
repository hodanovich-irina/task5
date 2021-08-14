using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace DBProc.FileWork
{
    /// <summary>
    /// Class for writing report to XLSX-file
    /// </summary>
    public class CreateXLSXFile
    {
        /// <summary>
        /// Method for create table in .xlsx file
        /// </summary>
        /// <param name="mas">String array</param>
        /// <param name="path">Path and file name</param>
        /// <param name="c">Numbers columns</param>
        private static void CreateExcelDifferentColumn(string[] mas, string path, int c)
        {
            Excel.Application xlApp = new Excel.Application();

            if (xlApp == null)
            {
                Console.WriteLine("Excel is not properly installed!!");
                return;
            }

            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            int ind;
            int row = 1;
            for (int i = 1; i <= mas.Length; i += c)
            {
                ind = 1;
                for (int j = i; j < i + c; j++)
                {
                    var excelcells = (Excel.Range)xlWorkSheet.Cells[row, ind];
                    excelcells.Value2 = mas[j - 1];
                    ind++;
                }
                row++;
            }
            string path1 = @"D:\AllTasks\task5\" + path;
            xlWorkBook.SaveAs(path1, Excel.XlFileFormat.xlOpenXMLWorkbook, misValue,
            misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
        }
        /// <summary>
        /// Inner class for work with report
        /// </summary>
        public static class WorkWithReport
        {
            /// <summary>
            /// Create file with information about borrowing books in Excel
            /// </summary>
            /// <param name="fileName">Name of file</param>
            public static void CreateInformationAboutBorrowingBooksExcel(string fileName)
            {
                string path = fileName + ".xlsx";
                CreateReport create = new CreateReport();
                CreateExcelDifferentColumn(create.InformationAboutBorrowingBooks(), path, 2);
            }

            /// <summary>
            /// Create file with information about borrowing books by subscriber in Excel
            /// </summary>
            /// <param name="start">Start of the period</param>
            /// <param name="end">End of the period</param>
            /// <param name="fileName">Name of file</param>
            public static void CreateInformationAboutBorrowingBooksBySubscriberExcel(DateTime start, DateTime end, string fileName)
            {
                string path = fileName + ".xlsx";
                CreateReport create = new CreateReport();
                CreateExcelDifferentColumn(create.InformationAboutBorrowingBooksBySubscriber(start, end), path, 3);
            }

            /// <summary>
            /// Create file with information about borrowed books by genre in Excel
            /// </summary>
            /// <param name="fileName">Name of file</param>
            public static void CreateInformationAboutBorrowedBooksByGenreExcel(string fileName)
            {
                string path = fileName + ".xlsx";
                CreateReport create = new CreateReport();
                CreateExcelDifferentColumn(create.InformationAboutBorrowedBooksByGenre(), path, 2);
            }
        }

    }
}
