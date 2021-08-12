using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Elements;
using System.Data.SqlClient;

namespace DBProc.CRUD
{
    public class SubscriberCRUD : BasicAcsess<Subscriber>
    {
        public override void Delete(int id)
        {
            SqlCommand com = new SqlCommand("Delete from Subscribers where SubscriberId = @SubscriberId", connection);

            com.Parameters.AddWithValue("@SubscriberId", id);

            com.ExecuteNonQuery();
            com.Dispose();
        }

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

        public override List<Subscriber> Select()
        {
            List<Subscriber> subscribers = new List<Subscriber>();
            SqlCommand com = new SqlCommand($"SELECT * FROM Subscribers", connection);
            var r = com.ExecuteReader();
            while (r.Read())
            {
                subscribers.Add(Create(Convert.ToInt32(r["SubscriberId"]), r["Surname"].ToString(), r["Name"].ToString(), r["MiddleName"].ToString(), r["Sex"].ToString(), Convert.ToDateTime(r["DateOfBirth"])));
            }
            r.Close();
            return subscribers;
        }

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
