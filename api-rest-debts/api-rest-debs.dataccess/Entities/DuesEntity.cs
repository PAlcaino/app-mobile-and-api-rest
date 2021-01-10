using System;
namespace apirestdebs.dataccess.Entities
{
    public class DuesEntity
    {
        public Guid Id { get; set; }

        public Guid IdDebt { get; set; }

        public double Amount { get; set; }

        public DateTimeOffset StartedAt { get; set; }

        public DateTimeOffset ExpiredAt { get; set; }
    }
}
