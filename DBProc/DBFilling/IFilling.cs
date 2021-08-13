using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProc.DBFilling
{
    public interface IFilling
    {
        void InsertDateInTableBooks();
        void InsertDateInTableSubscribers();
        void InsertDateInTableSubscriberDetails();
    }
}
