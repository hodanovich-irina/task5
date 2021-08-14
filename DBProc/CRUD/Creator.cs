using System;
using System.Collections.Generic;

namespace DBProc.CRUD
{
    /// <summary>
    /// Class for reliaze Fabrics method
    /// </summary>
    /// <typeparam name="T">type element</typeparam>
    public class Creator<T>
    {
        /// <summary>
        /// collections elements
        /// </summary>
        public List<T> list { get; set; }
        /// <summary>
        /// Inicialize collections
        /// </summary>
        public Creator()
        {
            list = new List<T>();
        }

        /// <summary>
        /// Method to create object
        /// </summary>
        /// <param name="objs">Object</param>
        public void FactoryCreate(params object[] objs)
        {
            list.Add((T)Activator.CreateInstance(typeof(T), objs));
        }
    }
}
