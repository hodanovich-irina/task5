using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBProc.CRUD
{
    /// <summary>
    /// Class for connection 
    /// </summary>
    public sealed class SingletonDB
    {
        /// <summary>
        /// Connection string
        /// </summary>
        private static readonly string stringConnection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        /// <summary>
        /// Connection
        /// </summary>
        private readonly SqlConnection Connection = new SqlConnection(stringConnection);

        /// <summary>
        /// Instance
        /// </summary>
        private static SingletonDB Instance = null;

        /// <summary>
        /// Object for Lock
        /// </summary>
        private static readonly object ThreadLock = new object();

        /// <summary>
        /// Open connection
        /// </summary>
        private SingletonDB()
        {
            Connection.Open();
        }

        /// <summary>
        /// Method for get instance
        /// </summary>
        public static SingletonDB GetInstance
        {
            get
            {
                lock (ThreadLock)
                {
                    if (Instance == null)
                        Instance = new SingletonDB();

                    return Instance;
                }
            }
        }

        /// <summary>
        /// Get connection
        /// </summary>
        /// <returns>Connection with DB</returns>
        public SqlConnection GetConnection()
        {
            return Connection;
        }

        /// <summary>
        /// Close connection
        /// </summary>
        public void Dispose()
        {
            Connection.Close();
        }
    }
}
