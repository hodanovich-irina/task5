using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBProc.CRUD;
using Library.Elements;

namespace DBProc.FileWork
{
    public class CreateReport
    {
        BasicAcsess<Book> books = new BookCRUD();
        BasicAcsess<Subscriber> subscribers = new SubscriberCRUD();
        BasicAcsess<SubscriberDetail> subscriberDetails = new SubscriberDetailCRUD();

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
