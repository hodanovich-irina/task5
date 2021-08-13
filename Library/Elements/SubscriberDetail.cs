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
        public int SubscriberId { get; set; }

        public int BookId { get; set; }
        public DateTime DateOfTaking { get; set; }
        public bool BookReturn { get; set; }
        public Condition BookCondition { get; set; }

        public SubscriberDetail(int SubscriberDetailId,  int SubscriberId, int BookId, DateTime DateOfTaking, bool BookReturn, Condition BookCondition)
        {
            this.SubscriberDetailId = SubscriberDetailId;
            this.SubscriberId = SubscriberId;
            this.BookId = BookId;
            this.DateOfTaking = DateOfTaking;
            this.BookReturn = BookReturn;
            this.BookCondition = BookCondition;
        }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public SubscriberDetail()
        {
        }
        /// <summary>
        /// Method overriding Equals()
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>True or false</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            SubscriberDetail subscriberDetail = obj as SubscriberDetail;
            if (subscriberDetail == null)
                return false;
            if (SubscriberDetailId != subscriberDetail.SubscriberDetailId ||  SubscriberId != subscriberDetail.SubscriberId || BookId != subscriberDetail.BookId  || DateOfTaking != subscriberDetail.DateOfTaking || BookReturn != subscriberDetail.BookReturn || BookCondition != subscriberDetail.BookCondition)
                return false;
            return true;
        }
        /// <summary>
        /// Override method ToString()
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return "SubscriberDetail: " + SubscriberDetailId + " " + SubscriberId + " " + BookId  + " " + DateOfTaking.ToString() + " " + BookReturn.ToString();
        }

        /// <summary>
        /// Method overriding GetHashCode()
        /// </summary>
        /// <returns>Hash-code</returns>
        public override int GetHashCode()
        {
            return SubscriberDetailId;
        }
    }
}
