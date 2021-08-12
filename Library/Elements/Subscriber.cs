using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Elements
{
    /// <summary>
    /// View of sex
    /// </summary>
    public enum SubscriberSex
    {
        /// <summary>
        /// male view
        /// </summary>
        male=1,
        /// <summary>
        /// female view
        /// </summary>
        female
    }
    /// <summary>
    /// Subscriber description
    /// </summary>
    public class Subscriber
    {
        /// <summary>
        /// Subscriber Id
        /// </summary>
        public int SubscriberId { get; set; }

        /// <summary>
        /// Subscriber surname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Subscriber name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Subscriber middle name
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Subscriber sex
        /// </summary>
        public SubscriberSex Sex { get; set; }

        /// <summary>
        /// Subscriber date of birth
        /// </summary>
        public DateTime DateOfBirth { get; set; }


        /// <summary>
        /// Constructor with parametrs
        /// </summary>
        /// <param name="SubscriberId">Subscriber id</param>
        /// <param name="Surname">Subscriber surname</param>
        /// <param name="Name">Subscriber name</param>
        /// <param name="MiddleName">Subscriber middlename</param>
        /// <param name="Sex">Subscriber sex</param>
        /// <param name="DateOfBirth">Subscriber date of birth</param>
        public Subscriber(int SubscriberId,string Surname, string Name, string MiddleName, SubscriberSex Sex, DateTime DateOfBirth)
        {
            this.SubscriberId = SubscriberId;
            this.Surname = Surname;
            this.Name = Name;
            this.MiddleName = MiddleName;
            this.Sex = Sex;
            this.DateOfBirth = DateOfBirth;
        }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Subscriber()
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
            Subscriber subscriber = obj as Subscriber;
            if (subscriber == null)
                return false;
            if (SubscriberId != subscriber.SubscriberId || Surname != subscriber.Surname || Name != subscriber.Name || MiddleName != subscriber.MiddleName || Sex != subscriber.Sex || DateOfBirth != subscriber.DateOfBirth)
                return false;
            return true;
        }
        /// <summary>
        /// Override method ToString()
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return "Subscriber: " + SubscriberId + " " + Surname + " " + Name + " " + MiddleName + " " + Sex.ToString() + " " + DateOfBirth.ToString();
        }

        /// <summary>
        /// Method overriding GetHashCode()
        /// </summary>
        /// <returns>Hash-code</returns>
        public override int GetHashCode()
        {
            return SubscriberId;
        }
    }
}
