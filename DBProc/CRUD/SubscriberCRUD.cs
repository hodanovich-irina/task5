﻿using System;
using System.Collections.Generic;
using Library.Elements;
using System.Data.SqlClient;

namespace DBProc.CRUD
{
    /// <summary>
    /// Class for CRUD Subscriber information
    /// </summary>
    public class SubscriberCRUD : BasicAcsess<Subscriber>
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
        /// Delete subscriber by id
        /// </summary>
        /// <param name="id">Subscriber id</param>
        public override void Delete(int id)
        {
            SqlCommand com = new SqlCommand("Delete from Subscribers where SubscriberId = @SubscriberId", connection);

            com.Parameters.AddWithValue("@SubscriberId", id);

            com.ExecuteNonQuery();
            com.Dispose();
        }

        /// <summary>
        /// Insert subscriber in db 
        /// </summary>
        /// <param name="obj">new subscriber</param>
        public override void Insert(Subscriber obj)
        {
            SqlCommand com = new SqlCommand("Insert Into Subscribers" +
                                         "(Surname,Name,MiddleName, Sex, DateOfBirth) Values(@Surname,@Name,@MiddleName,@Sex,@DateOfBirth)", connection);
            com.Parameters.AddWithValue("@Surname", obj.Surname);
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@MiddleName", obj.MiddleName);
            com.Parameters.AddWithValue("@Sex", obj.Sex);
            com.Parameters.AddWithValue("@DateOfBirth", obj.DateOfBirth);

            com.ExecuteNonQuery();
            com.Dispose();
        }

        /// <summary>
        /// Select all inform about subscriber 
        /// </summary>
        /// <returns>Collection of subscribers</returns>
        public override List<Subscriber> Select()
        {
            creator.list.Clear();
            SqlCommand com = new SqlCommand($"SELECT * FROM Subscribers", connection);
            var r = com.ExecuteReader();
            while (r.Read())
            {
                creator.FactoryCreate(Convert.ToInt32(r["SubscriberId"]), r["Surname"].ToString(), r["Name"].ToString(), r["MiddleName"].ToString(), ParseEnum<SubscriberSex>(r["Sex"].ToString()), Convert.ToDateTime(r["DateOfBirth"]));
            }
            r.Close();
            return creator.list;

        }
        /// <summary>
        /// Update information about subscriber
        /// </summary>
        /// <param name="obj">Subscriber</param>
        public override void Update(Subscriber obj)
        {
            SqlCommand com = new SqlCommand("Update Subscribers Set Surname = @Surname,  Name = @Name, MiddleName = @MiddleName, Sex = @Sex, DateOfBirth = @DateOfBirth  Where SubscriberId = @SubscriberId", connection);

            com.Parameters.AddWithValue("@SubscriberId", obj.SubscriberId); 
            com.Parameters.AddWithValue("@Surname", obj.Surname);
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@MiddleName", obj.MiddleName);
            com.Parameters.AddWithValue("@Sex", obj.Sex);
            com.Parameters.AddWithValue("@DateOfBirth", obj.DateOfBirth);

            com.ExecuteNonQuery();
            com.Dispose();
        }
    }
}
