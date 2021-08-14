using System.Collections.Generic;
using System.Data.SqlClient;

namespace DBProc.CRUD
{
    /// <summary>
    /// Base abstract class for CRUD
    /// </summary>
    /// <typeparam name="T">type element</typeparam>
    public abstract class BasicAcsess<T>
    {

        /// <summary>
        /// Get instance
        /// </summary>
        private static SingletonDB singleton = SingletonDB.GetInstance;

        /// <summary>
        /// Connection to db
        /// </summary>
        protected SqlConnection connection = singleton.GetConnection();

        /// <summary>
        /// Object factory method
        /// </summary>
        protected Creator<T> creator = new Creator<T>();

        /// <summary>
        /// Select from db 
        /// </summary>
        /// <returns>List of object</returns>
        public abstract List<T> Select();
        /// <summary>
        /// Insert from db
        /// </summary>
        /// <param name="obj">new object</param>
        public abstract void Insert(T obj);
        /// <summary>
        /// Delete from db
        /// </summary>
        /// <param name="id">Id</param>
        public abstract void Delete(int id);
        /// <summary>
        /// Update from db
        /// </summary>
        /// <param name="obj">object</param>
        public abstract void Update(T obj);
        
    }
}
