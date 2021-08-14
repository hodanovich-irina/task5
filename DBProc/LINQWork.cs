using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBProc.CRUD;
using Library.Elements;

namespace DBProc
{
    /// <summary>
    /// Class for linq
    /// </summary>
    public class LINQWork
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
        /// Method for find The most popular author
        /// </summary>
        /// <returns>String with author name</returns>
        public string TheMostPopularAuthor()
        {
            var res = from b in books.Select()
                      from sd in subscriberDetails.Select()
                      where b.BookId == sd.BookId 
                      group b by b.Author into v
                      select new { Name = v.Key, Kol = v.Count() };

            var z = (res.Select(x => x).Where(x => x.Kol >= res.Max(o => o.Kol))).ToArray();
            string author = z[0].Name;
           
            return author;
        }

        /// <summary>
        /// Method for find the most reading subscriber
        /// </summary>
        /// <returns>Subscriber</returns>
        public Subscriber TheMostReadingSubscriber()
        {
            var res = from s in subscribers.Select()
                      from sd in subscriberDetails.Select()
                      where s.SubscriberId == sd.SubscriberId 
                      group sd by sd.SubscriberId into v
                      select new { Id = v.Key, Kol = v.Count() };
            var z = (res.Select(x => x).Where(x => x.Kol >= res.Max(o => o.Kol))).ToArray();

            int id = z[0].Id;
            var subscriber = (from s in subscribers.Select()
                             where s.SubscriberId == id
                             select s).First();
            return subscriber;
        }

        /// <summary>
        /// Method for find the most popular genre
        /// </summary>
        /// <returns>Genre</returns>
        public BookGenre TheMostPopularGenre()
        {
            var res = from b in books.Select()
                      from sd in subscriberDetails.Select()
                      where b.BookId == sd.BookId
                      group b by b.Genre into v
                      select new { Genre = v.Key, Kol = v.Count() };

            var z = (res.Select(x => x).Where(x => x.Kol >= res.Max(o => o.Kol))).ToArray();
            BookGenre genre = z[0].Genre;

            return genre;
        }
        /// <summary>
        /// Method for find recovery books
        /// </summary>
        /// <returns>Collection of recovery books</returns>
        public List<Book> RecoveryBooks()
        {
            var res = (from b in books.Select()
                      from sd in subscriberDetails.Select()
                      where b.BookId == sd.BookId && sd.BookCondition == Condition.bad
                      select b).Distinct().ToList();

            return res;
        }
    }
}
