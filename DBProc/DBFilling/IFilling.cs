namespace DBProc.DBFilling
{
    /// <summary>
    /// Interface for method for insert date in db
    /// </summary>
    public interface IFilling
    {
        /// <summary>
        /// Method for insert date in table Books
        /// </summary>
        void InsertDateInTableBooks();
        /// <summary>
        /// Method for insert date in table Subscribers
        /// </summary>
        void InsertDateInTableSubscribers();
        /// <summary>
        /// Method for insert date in table SubscriberDetails
        /// </summary>
        void InsertDateInTableSubscriberDetails();
    }
}
