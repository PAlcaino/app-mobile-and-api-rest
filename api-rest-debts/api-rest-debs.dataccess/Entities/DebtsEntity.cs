using System;
namespace apirestdebs.dataccess.Entities
{
    /// <summary>
    /// Entity for Debts
    /// </summary>
    public class DebtEntity
    {
        /// <summary>
        /// Gets or sets the debts identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the user identifier
        /// </summary>
        public Guid IdUser { get; set; }

        /// <summary>
        /// Gets or sets the debt's amount
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Gets or sets the debt's creation date time offset
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Get or sets the debt's expiration date time offset
        /// </summary>
        public DateTimeOffset ExpiredAt { get; set; }

        /// <summary>
        /// Gets or sets the dues amount
        /// </summary>
        public int Dues { get; set; }
    }
}
