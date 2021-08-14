using System;
using System.Collections.Generic;
using Library.Elements;
using System.Data.SqlClient;

namespace DBProc.CRUD
{
    /// <summary>
    /// Class for CRUD SumscriberDetail information
    /// </summary>
    public class SubscriberDetailCRUD : BasicAcsess<SubscriberDetail>
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

        /// <summary>
        /// Delete subscriber detail by id
        /// </summary>
        /// <param name="id">Subscriber detail id</param>
        public override void Delete(int id)
        {
            SqlCommand com = new SqlCommand("Delete from SubscriberDetails where SubscriberDetailId = @SubscriberDetailId", connection);

            com.Parameters.AddWithValue("@SubscriberDetailId", id);

            com.ExecuteNonQuery();
            com.Dispose();
        }

        /// <summary>
        /// Insert subscriber detail in db 
        /// </summary>
        /// <param name="obj">new subscriber detail</param>
        public override void Insert(SubscriberDetail obj)
        {
            SqlCommand com = new SqlCommand("Insert Into SubscriberDetails" +
                                         "(SubscriberId, BookId, DateOfTaking,BookReturn,BookCondition) Values(@SubscriberId,@BookId,@DateOfTaking,@BookReturn,@BookCondition)", connection);
            com.Parameters.AddWithValue("@SubscriberId", obj.SubscriberId);
            com.Parameters.AddWithValue("@BookId", obj.BookId);
            com.Parameters.AddWithValue("@DateOfTaking", obj.DateOfTaking);
            com.Parameters.AddWithValue("@BookReturn", obj.BookReturn);
            com.Parameters.AddWithValue("@BookCondition", obj.BookCondition);

            com.ExecuteNonQuery();
            com.Dispose();
        }
        /// <summary>
        /// Select all inform about subscriber detail
        /// </summary>
        /// <returns>Collection of subscriber details</returns>
        public override List<SubscriberDetail> Select()
        {
            creator.list.Clear();
            SqlCommand com = new SqlCommand($"SELECT * FROM SubscriberDetails", connection);
            var r = com.ExecuteReader();
            while (r.Read())
            {
                creator.FactoryCreate(Convert.ToInt32(r["SubscriberDetailId"]), Convert.ToInt32(r["SubscriberId"]), Convert.ToInt32(r["BookId"]), Convert.ToDateTime(r["DateOfTaking"]), Convert.ToBoolean(r["BookReturn"]), ParseEnum<Condition>(r["BookCondition"].ToString()));
            }
            r.Close();
            return creator.list;
        }

        /// <summary>
        /// Update information about subscriber detail
        /// </summary>
        /// <param name="obj">Subscriber detail</param>
        public override void Update(SubscriberDetail obj)
        {
            SqlCommand com = new SqlCommand("Update SubscriberDetails Set SubscriberId = @SubscriberId,  BookId = @BookId, DateOfTaking = @DateOfTaking, BookReturn = @BookReturn, BookCondition = @BookCondition  Where SubscriberDetailId = @SubscriberDetailId", connection);

            com.Parameters.AddWithValue("@SubscriberDetailId", obj.SubscriberDetailId);
            com.Parameters.AddWithValue("@SubscriberId", obj.SubscriberId);
            com.Parameters.AddWithValue("@BookId", obj.BookId);
            com.Parameters.AddWithValue("@DateOfTaking", obj.DateOfTaking);
            com.Parameters.AddWithValue("@BookReturn", obj.BookReturn);
            com.Parameters.AddWithValue("@BookCondition", obj.BookCondition);

            com.ExecuteNonQuery();
            com.Dispose();
        }
    }
}
