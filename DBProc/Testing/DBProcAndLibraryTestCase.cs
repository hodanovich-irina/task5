using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DBProc;
using DBProc.CRUD;
using DBProc.DBFilling;
using DBProc.FileWork;
using DBProc.Testing;
using Library.Elements;


namespace DBProc.Testing
{
    /// <summary>
    /// Class for testing DBProc and Library
    /// </summary>
    [TestFixture]
    class DBProcAndLibraryTestCase
    {
        /// <summary>
        /// TestCase for Book CRUD
        /// </summary>
        [TestCase]
        public void TestMethodCRUDBook()
        {
            BasicAcsess<Book> b = new BookCRUD();
            Book book = new Book(0, "Strugatsky", "Roadside Picnic 1", BookGenre.Fantastic);

            b.Insert(book);
            var b1 = b.Select()[b.Select().Count - 1];
            Assert.AreEqual(book.BookName, b1.BookName);

            b1.BookName = "Roadside Picnic 2";
            b.Update(b1);
            var b2 = b.Select()[b.Select().Count - 1];
            Assert.AreEqual(b1, b2);

            b.Delete(b2.BookId);
        }
        /// <summary>
        /// TestCase for Subscriber CRUD
        /// </summary>
        [TestCase]
        public void TestMethodCRUDSubscriber()
        {
            BasicAcsess<Subscriber> s = new SubscriberCRUD();
            Subscriber subscriber = new Subscriber(0, "Petrov", "Daniil", "Petrovich", SubscriberSex.male, new DateTime(2001, 10, 20));

            s.Insert(subscriber);
            var s1 = s.Select()[s.Select().Count - 1];
            Assert.AreEqual(subscriber.Surname, s1.Surname);

            s1.Surname = "Popov";
            s.Update(s1);
            var s2 = s.Select()[s.Select().Count - 1];
            Assert.AreEqual(s1, s2);

            s.Delete(s2.SubscriberId);
        }
        /// <summary>
        /// TestCase for SubscriberDetail CRUD
        /// </summary>
        [TestCase]
        public void TestMethodCRUDSubscriberDetail()
        {
            BasicAcsess<SubscriberDetail> sd = new SubscriberDetailCRUD();
            SubscriberDetail subscriberDetail = new SubscriberDetail(0, 1, 2, new DateTime(2021, 1, 11), true, Condition.good);

            sd.Insert(subscriberDetail);
            var sd1 = sd.Select()[sd.Select().Count - 1];
            Assert.AreEqual(subscriberDetail.SubscriberId, sd1.SubscriberId);

            sd1.SubscriberId = 3;
            sd.Update(sd1);
            var sd2 = sd.Select()[sd.Select().Count - 1];
            Assert.AreEqual(sd1, sd2);

            sd.Delete(sd2.SubscriberDetailId);
        }
        /// <summary>
        /// TestCase for method TheMostPopularAuthor()
        /// </summary>
        [TestCase]
        public void TestMethodTheMostPopularAuthor()
        {
            LINQWork work = new LINQWork();
            string res = work.TheMostPopularAuthor();
            Assert.AreEqual(res, "Strugatsky");

        }
        /// <summary>
        /// TestCase for method TheMostPopularGenre()
        /// </summary>
        [TestCase]
        public void TestMethodTheMostPopularGenre()
        {
            LINQWork work = new LINQWork();
            BookGenre res = work.TheMostPopularGenre();
            Assert.AreEqual(res, BookGenre.Fantastic);

        }

        /// <summary>
        /// TestCase for method TheMostReadingSubscriber()
        /// </summary>
        [TestCase]
        public void TestMethodTheMostReadingSubscriber()
        {
            LINQWork work = new LINQWork();
            Subscriber res = work.TheMostReadingSubscriber();
            Assert.AreEqual(res.ToString(), "Subscriber: 2 Vasilenko Alexsandr Victorovich male 12.09.1993 0:00:00");
        }
        /// <summary>
        /// TestCase for method RecoveryBooks()
        /// </summary>
        [TestCase]
        public void TestMethodRecoveryBooks()
        {
            LINQWork work = new LINQWork();
            List<Book> res = work.RecoveryBooks();
            Assert.AreEqual(res.First().ToString(), "Book: 1 Strugatsky Snail on the slope Fantastic");
        }

        /// <summary>
        /// TestCase for create pdf-file and report
        /// </summary>
        [TestCase]
        public void TestMethodCreatePdfFileAndReport()
        {
            CreateReport report = new CreateReport();
            string[] res = report.InformationAboutBorrowedBooksByGenre();
            CreatePdfFile createPdfFile = new CreatePdfFile();
            createPdfFile.CreatePdf("D:/AllTasks/task5/Report1.pdf", res, 2);
            Assert.AreEqual(res[2], "Fantastic");
        }
        /// <summary>
        /// TestCase for create text-file and report
        /// </summary>
        [TestCase]
        public void TestMethodCreateTextFileAndReport()
        {
            CreateReport report = new CreateReport();
            string[] res = report.InformationAboutBorrowingBooks();
            CreateTextFile createTextFile = new CreateTextFile();
            createTextFile.CreateFile_txt("D:/AllTasks/task5/Report2.txt", res, 2);
            Assert.AreEqual(res[2], "Snail on the slope");
        }
        /// <summary>
        /// TestCase for create text-file and report, work with inner class
        /// </summary>
        [TestCase]
        public void TestMethodCreateXlsxFileAndReport()
        {
            CreateReport report = new CreateReport();
            string[] res = report.InformationAboutBorrowingBooksBySubscriber(new DateTime(2021, 5, 5), new DateTime(2021, 8, 5));
            CreateXLSXFile.WorkWithReport.CreateInformationAboutBorrowingBooksBySubscriberExcel(new DateTime(2021, 5, 5), new DateTime(2021, 8, 5), "Report3");
            Assert.AreEqual(res[4], "Virgins");
        }
        /// <summary>
        /// TestCase for Equals()
        /// </summary>
        [TestCase]
        public void TestMethodEquals()
        {
            Book book = new Book(0, "Strugatsky", "Roadside Picnic 1", BookGenre.Fantastic);
            Book book1 = new Book(0, "Strugatsky", "Roadside Picnic 1", BookGenre.Fantastic);
            var res = book.Equals(book1);

            Assert.IsTrue(res);
        }
        /// <summary>
        /// TestCase for GetHashCode()
        /// </summary>
        [TestCase]
        public void TestMethodGetHashCode()
        {
            Book book = new Book(10, "Strugatsky", "Roadside Picnic 1", BookGenre.Fantastic);
            int res = book.GetHashCode();
            Assert.AreEqual(10 ,res);
        }
    }
}
