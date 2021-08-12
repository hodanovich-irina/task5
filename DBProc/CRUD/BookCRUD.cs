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
            List<Book> books = new List<Book>();
            SqlCommand com = new SqlCommand($"SELECT * FROM Books", connection);
            var r = com.ExecuteReader();
            while (r.Read())
            {
                books.Add(Create(Convert.ToInt32(r["BookId"]), r["Author"].ToString(), r["BookName"].ToString(), r["Genre"].ToString()));
            }
            r.Close();
            return books;
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
