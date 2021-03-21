using System;

namespace debts_app.Models
{
    public class Debts
    {
        /// <summary>
        /// Gets or sets the debts identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the user identifier
        /// </summary>
        public Guid UserId { get; set; }

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

        /// <summary>
        /// Determines if the user is a client or a debt user
        /// </summary>
        public bool IsClient { get; set; }
    }
}
