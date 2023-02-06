namespace VisitorManagement.Models
{
    /// <summary>
    /// Represents one specific customer
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Customer Name
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Customer Address
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Customer Contact number
        /// </summary>
        public string ContactNumber { get; set; }
        /// <summary>
        /// Customer Country
        /// </summary>
        public string Country { get; set; }
    }
}