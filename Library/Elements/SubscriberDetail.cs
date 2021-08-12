using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Elements
{
    public enum Condition 
    {
        good = 1,
        normal,
        bad
    }
    /// <summary>
    /// SubscriberDetail description
    /// </summary>
    public class SubscriberDetail
    {
        public int SubscriberDetailId { get; set; }
        public int BookId { get; set; }
        public int SubscriberId { get; set; }
        public DateTime DateOfTaking { get; set; }
        public bool BookReturn { get; set; }
        public Condition BookCondition { get; set; }
    }
}
