using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Elements;
using DBProc.CRUD;
using DBProc;
using DBProc.DBFilling;
using DBProc.FileWork;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            //BasicAcsess<SubscriberDetail> acsess = new SubscriberDetailCRUD();
            //Console.WriteLine();
         
            //foreach(var v in acsess.Select())
              //Console.WriteLine(v.ToString());
            LINQWork work = new LINQWork();
            Console.WriteLine(work.TheMostPopularAuthor());
            Console.WriteLine(work.TheMostPopularGenre());
            Console.WriteLine(work.TheMostReadingSubscriber());
            foreach(var v in work.RecoveryBooks())
            Console.WriteLine(v);
            //CreateReport createReport = new CreateReport();
            //foreach( var v in createReport.InformationAboutBorrowingBooks())
            //Console.WriteLine(v);
            //CreateXLSXFile.WorkWithReport.CreateInformationAboutBorrowingBooksExcel("prob122");
            //CreatePdfFile createTextFile = new CreatePdfFile();
            //createTextFile.CreatePdf("prob1.pdf", createReport.InformationAboutBorrowingBooksBySubscriber(new DateTime(2021,5,1), new DateTime(2021,9,13)),3);
            Console.ReadLine();



        }
    }
}
