using Library.Elements;
using DBProc.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProc.DBFilling
{
    /// <summary>
    /// Class for work with tables
    /// </summary>
    public class WorkWithTable : IFilling, IFillingByDelegate
    {
        /// <summary>
        /// Delegate for filling tabels
        /// </summary>
        public delegate void DelegateForFilling();
        /// <summary>
        /// Event for filling tables
        /// </summary>
        public event DelegateForFilling FillingTables;

        /// <summary>
        /// Empty constructor
        /// </summary>
        public WorkWithTable()
        {
            FillingTables += InsertDateInTableBooks;
            FillingTables += InsertDateInTableSubscriberDetails;
            FillingTables += InsertDateInTableSubscribers;
        }
        /// <summary>
        /// Method for insert date in table Books
        /// </summary>
        public void InsertDateInTableBooks()
        {
            BasicAcsess<Book> books = new BookCRUD();
            books.Insert(new Book(0, "Strugatsky", "Snail on the slope", BookGenre.Fantastic));
            books.Insert(new Book(0, "Strugatsky", "Roadside Picnic", BookGenre.Fantastic));
            books.Insert(new Book(0, "George Orwell", "1984", BookGenre.Fantastic));
            books.Insert(new Book(0, "Umberto Eco", "Rose name", BookGenre.Detective));
            books.Insert(new Book(0, "Alex Michaelides", "Virgins", BookGenre.Detective));
            books.Insert(new Book(0, "Daniel Defoe", "Robinson Crusoe", BookGenre.Adventures));
            books.Insert(new Book(0, "Jack London", "Sea wolf", BookGenre.Adventures));
            books.Insert(new Book(0, "Prosper Merimee", "Carmen", BookGenre.Novel));
            books.Insert(new Book(0, "Truman Capote", "Summer cruise", BookGenre.Novel));
            books.Insert(new Book(0, "Thomas Mann", "Death in Venice", BookGenre.Novel));
            books.Insert(new Book(0, "Stephen William Hawking", "A brief history of time", BookGenre.Scientific));
            books.Insert(new Book(0, "Nikolai Albertovich Kuhn", "Legends and myths of Ancient Greece", BookGenre.Folklore));
            books.Insert(new Book(0, "George Bernard Shaw", " Pygmalion", BookGenre.Humor));
            books.Insert(new Book(0, "Sergey Dovlatov", " Suitcase", BookGenre.Humor));
            books.Insert(new Book(0, "Vladimir Dal", "Explanatory Dictionary of the Living Great Russian Language", BookGenre.Reference));
        }

        /// <summary>
        /// Method for insert date in table Subscribers
        /// </summary>
        public void InsertDateInTableSubscribers() 
        {
            BasicAcsess<Subscriber> subscribers = new SubscriberCRUD();
            subscribers.Insert(new Subscriber(0, "Petrov", "Daniil", "Petrovich", SubscriberSex.male, new DateTime(2001, 10, 20)));
            subscribers.Insert(new Subscriber(0, "Vasilenko", "Alexsandr", "Victorovich", SubscriberSex.male, new DateTime(1993, 9, 12)));
            subscribers.Insert(new Subscriber(0, "Zhuk", "Artem", "Vasilievich", SubscriberSex.male, new DateTime(2003, 11, 6)));
            subscribers.Insert(new Subscriber(0, "Syxarko", "Vladislav", "Vitalievich", SubscriberSex.male, new DateTime(2005, 10, 10)));
            subscribers.Insert(new Subscriber(0, "Korzh", "Ekaterina", "Stepanovna", SubscriberSex.female, new DateTime(1999, 12, 7)));
            subscribers.Insert(new Subscriber(0, "Zayatc", "Alesya", "Sergeevna", SubscriberSex.female, new DateTime(2002, 3, 14)));
            subscribers.Insert(new Subscriber(0, "Popok", "Aleksandra", "Petrovna", SubscriberSex.female, new DateTime(2001, 1, 13)));
            subscribers.Insert(new Subscriber(0, "Mitskevich", "Elizabet", "Andreevna", SubscriberSex.female, new DateTime(2004, 5, 27)));
        }
        /// <summary>
        /// Method for insert date in table SubscriberDetails
        /// </summary>
        public void InsertDateInTableSubscriberDetails() 
        {
            BasicAcsess<SubscriberDetail> subscriberDetails = new SubscriberDetailCRUD();
            subscriberDetails.Insert(new SubscriberDetail(0, 1, 2, new DateTime(2021, 1, 11), true, Condition.good));
            subscriberDetails.Insert(new SubscriberDetail(0, 5, 6, new DateTime(2021, 1, 12), true, Condition.bad));
            subscriberDetails.Insert(new SubscriberDetail(0, 1, 4, new DateTime(2021, 5, 22), false, Condition.good));
            subscriberDetails.Insert(new SubscriberDetail(0, 4, 4, new DateTime(2021, 6, 6), false, Condition.normal));
            subscriberDetails.Insert(new SubscriberDetail(0, 3, 5, new DateTime(2021, 7, 24), false, Condition.bad));
            subscriberDetails.Insert(new SubscriberDetail(0, 2, 1, new DateTime(2021, 7, 25), true, Condition.normal));
            subscriberDetails.Insert(new SubscriberDetail(0, 1, 7, new DateTime(2021, 7, 29), true, Condition.bad));
            subscriberDetails.Insert(new SubscriberDetail(0, 14, 2, new DateTime(2021, 8, 3), false, Condition.good));
            subscriberDetails.Insert(new SubscriberDetail(0, 11, 6, new DateTime(2021, 8, 12), false, Condition.normal));
            subscriberDetails.Insert(new SubscriberDetail(0, 5, 5, new DateTime(2021, 8, 13), false, Condition.bad));

        }
        /// <summary>
        /// Method for start filling tables
        /// </summary>
        public void StartFilling()
        {
            FillingTables?.Invoke();
        }
    }
}
