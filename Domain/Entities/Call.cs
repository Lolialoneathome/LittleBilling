using System;

namespace Billing.Domain.Entities
{
    public class Call : IEntity
    {
        public int Id { get; }
        public readonly DateTime StartAt;
        public readonly SimCard SimCard;

        public readonly string _phoneNumberTo;
        public string _phoneNumberFrom => SimCard.PhoneNumber;
        public CallState State
        {
            get
            {
                return _getState();
            }
        }
        public int Cost { get; protected set; }
        private CallState _getState()
        {
            if (EndAt == null)
                return CallState.InProgress;

            return CallState.Ended;
        }

        protected internal Call(SimCard simCard, string phoneNumberTo)
        {
            StartAt = DateTime.UtcNow;
            SimCard = simCard;
            _phoneNumberTo = phoneNumberTo;
        }

        public DateTime? EndAt { get; protected set; }
        public int MinuteDuration => (EndAt - StartAt).Value.Seconds;

        public void End()
        {
            EndAt = DateTime.UtcNow;
        }


        public void SetCost(int cost)
        {
            if (cost < 0)
                throw new InvalidOperationException("Cost cannot be negative");

            Cost = cost;
        }

    }
}
