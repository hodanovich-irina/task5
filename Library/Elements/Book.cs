using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Elements
{
    /// <summary>
    /// View of book genre
    /// </summary>
    public enum BookGenre
    {
        /// <summary>
        /// Detective
        /// </summary>
        Detective = 1,
        /// <summary>
        /// Fantastic
        /// </summary>
        Fantastic,
        /// <summary>
        /// Adventures
        /// </summary>
        Adventures,
        /// <summary>
        /// Novel
        /// </summary>
        Novel,
        /// <summary>
        /// Scientific book
        /// </summary>
        Scientific,
        /// <summary>
        /// Folklore
        /// </summary>
        Folklore,
        /// <summary>
        /// Humor
        /// </summary>
        Humor,
        /// <summary>
        /// Reference
        /// </summary>
        Reference
    }
    /// <summary>
    /// Book description
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Book Id
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Book author
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Book name
        /// </summary>
        public string BookName { get; set; }

        /// <summary>
        /// Book genre
        /// </summary>
        public BookGenre Genre { get; set; }


        /// <summary>
        /// Constructor with parametrs
        /// </summary>
        /// <param name="BookId">Book id</param>
        /// <param name="Author">Book author</param>
        /// <param name="BookName">Book name</param>
        /// <param name="Genre">Book genre</param>
        public Book(int BookId, string Author, string BookName, BookGenre Genre)
        {
            this.BookId = BookId;
            this.Author = Author;
            this.BookName = BookName;
            this.Genre = Genre;
        }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Book()
        {
        }

        /// <summary>
        /// Method overriding Equals()
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>True or false</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Book book = obj as Book;
            if (book == null)
                return false;
            if (BookId != book.BookId || Author != book.Author || BookName != book.BookName || Genre != book.Genre)
                return false;
            return true;
        }
        /// <summary>
        /// Override method ToString()
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return "Book: " + BookId + " " + Author + " " + BookName + " " + Genre.ToString();
        }

        /// <summary>
        /// Method overriding GetHashCode()
        /// </summary>
        /// <returns>Hash-code</returns>
        public override int GetHashCode()
        {
            return BookId;
        }
    }
}
