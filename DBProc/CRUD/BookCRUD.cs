using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Elements;
using System.Data.SqlClient;

namespace DBProc.CRUD
{
    public class BookCRUD : BasicAcsess<Book>
    {
        /// <summary>
        /// Convert string to enum
        /// </summary>
        /// <typeparam name="T">jeneric type</typeparam>
        /// <param name="value">string</param>
        /// <returns></returns>
        private static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public override void Delete(int id)
        {
            SqlCommand com = new SqlCommand("Delete from Books where BookId = @BookId", connection);

            com.Parameters.AddWithValue("@BookId", id);

            com.ExecuteNonQuery();
            com.Dispose();
        }

        public override void Insert(Book obj)
        {
            SqlCommand com = new SqlCommand("Insert Into Books" +
                             "(Author, BookName, Genre) Values(@Author,@BookName,@Genre)", connection);
            com.Parameters.AddWithValue("@Author", obj.Author);
            com.Parameters.AddWithValue("@BookName", obj.BookName);
            com.Parameters.AddWithValue("@Genre", obj.Genre);

            com.ExecuteNonQuery();
            com.Dispose();
        }

        public override List<Book> Select()
        {
            creator.list.Clear();
            SqlCommand com = new SqlCommand($"SELECT * FROM Books", connection);
            var r = com.ExecuteReader();
            while (r.Read())
            {
                creator.FactoryCreate(Convert.ToInt32(r["BookId"]), r["Author"].ToString(), r["BookName"].ToString(), ParseEnum<BookGenre>(r["Genre"].ToString()));
            }
            r.Close();
            return creator.list;

        }

        public override void Update(Book obj)
        {
            SqlCommand com = new SqlCommand("Update Books Set Author = @Author,  BookName = @BookName, Genre = @Genre Where BookId = @BookId", connection);

            com.Parameters.AddWithValue("@BookId", obj.BookId);
            com.Parameters.AddWithValue("@Author", obj.Author);
            com.Parameters.AddWithValue("@BookName", obj.BookName);
            com.Parameters.AddWithValue("@Genre", obj.Genre);

            com.ExecuteNonQuery();
            com.Dispose();
        }
    }
}
