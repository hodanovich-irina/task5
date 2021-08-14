using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Elements
{
    /// <summary>
    /// Enum of condition view
    /// </summary>
    public enum Condition 
    {
        /// <summary>
        /// good
        /// </summary>
        good = 1,
        /// <summary>
        /// normal
        /// </summary>
        normal,
        /// <summary>
        /// bad
        /// </summary>
        bad
    }
    /// <summary>
    /// SubscriberDetail description
    /// </summary>
    public class SubscriberDetail
    {
        /// <summary>
        /// SubscriberDetail id
        /// </summary>
        public int SubscriberDetailId { get; set; }
        /// <summary>
        /// Subscriber id
        /// </summary>
        public int SubscriberId { get; set; }

        /// <summary>
        /// Book id
        /// </summary>
        public int BookId { get; set; }
        /// <summary>
        /// Date of taking book
        /// </summary>
        public DateTime DateOfTaking { get; set; }

        /// <summary>
        /// book retern(true or false)
        /// </summary>
        public bool BookReturn { get; set; }

        /// <summary>
        /// Book condition
        /// </summary>
        public Condition BookCondition { get; set; }

        /// <summary>
        /// Constructor with params
        /// </summary>
        /// <param name="SubscriberDetailId">SubscriberDetail id</param>
        /// <param name="SubscriberId">Subscriber id</param>
        /// <param name="BookId">Book id</param>
        /// <param name="DateOfTaking">Date of taking book</param>
        /// <param name="BookReturn">Book return</param>
        /// <param name="BookCondition">Book condition</param>
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
