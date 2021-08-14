using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProc.DBFilling
{
    /// <summary>
    /// Interface for method for call event
    /// </summary>
    public interface IFillingByDelegate
    {
        /// <summary>
        /// Method for star filling tables
        /// </summary>
        void StartFilling();

    }
}
