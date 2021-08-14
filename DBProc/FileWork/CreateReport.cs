using System;
using System.Linq;
using DBProc.CRUD;
using Library.Elements;

namespace DBProc.FileWork
{
    /// <summary>
    /// Class for create report
    /// </summary>
    public class CreateReport
    {       
        /// <summary>
        /// Object CRUD for books
        /// </summary>
        BasicAcsess<Book> books = new BookCRUD();

        /// <summary>
        /// Object CRUD for subscribers
        /// </summary>
        BasicAcsess<Subscriber> subscribers = new SubscriberCRUD();

        /// <summary>
        /// Object CRUD for subscriber details
        /// </summary>
        BasicAcsess<SubscriberDetail> subscriberDetails = new SubscriberDetailCRUD();

        /// <summary>
        /// Method for create report with information about borrowing books
        /// </summary>
        /// <returns>Array of string</returns>
        public string[] InformationAboutBorrowingBooks() 
        {
            var list_in = (from b in books.Select()
                          from sd in subscriberDetails.Select()
                          where b.BookId == sd.BookId
                          group b by b.BookName into res
                          select new { BookName = res.Key, Count = res.Count() }).ToList();

            string[] mas = new string[list_in.Count * 2 + 2];
            mas[0] = "Book name: ";
            mas[1] = "Was issued (times): ";
            for (int i = 0, j = 2; i < list_in.Count; i++, j += 2)
            {
                mas[j] = list_in[i].BookName;
                mas[j + 1] = list_in[i].Count.ToString();
            }
            return mas;
        }

        /// <summary>
        /// Method for create report with information about borrowing books by sunscriber in the period
        /// </summary>
        /// <returns>Array of string</returns>
        public string[] InformationAboutBorrowingBooksBySubscriber(DateTime start, DateTime end) 
        {
            var list_in = (from b in books.Select()
                           from sd in subscriberDetails.Select()
                           from s in subscribers.Select()
                           where s.SubscriberId == sd.SubscriberId && sd.DateOfTaking >= start && sd.DateOfTaking <= end &&   b.BookId == sd.BookId
                           orderby sd.DateOfTaking
                           select new { Subscriber = s.Surname , Book = b.BookName, Date = sd.DateOfTaking }).ToList();

            string[] mas = new string[list_in.Count * 3 + 3];
            mas[0] = "Subscriber: ";
            mas[1] = "Book name: ";
            mas[2] = "Date of taking: ";
            for (int i = 0, j = 3; i < list_in.Count; i++, j += 3)
            {
                mas[j] = list_in[i].Subscriber;
                mas[j + 1] = list_in[i].Book;
                mas[j + 2] = list_in[i].Date.ToShortDateString().ToString();
            }
            return mas;
        }

        /// <summary>
        /// Method for create report with information about borrowed books by genre
        /// </summary>
        /// <returns>Array of string</returns>
        public string[] InformationAboutBorrowedBooksByGenre() 
        {
            var list_in = (from sd in subscriberDetails.Select()
                          from b in books.Select()
                          where sd.BookId == b.BookId
                          group b by b.Genre into res
                          select new { Genre = res.Key, Count = res.Count()}).ToList();


            string[] mas = new string[list_in.Count * 2 + 2];
            mas[0] = "Genre: ";
            mas[1] = "Was issued (times): ";
            for (int i = 0, j = 2; i < list_in.Count; i++, j += 2)
            {
                mas[j] = list_in[i].Genre.ToString();
                mas[j + 1] = list_in[i].Count.ToString();
            }
            return mas;
        }
    }
}
