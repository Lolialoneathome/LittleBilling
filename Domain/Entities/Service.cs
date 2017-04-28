
using System;

namespace Billing.Domain.Entities
{
    public class Service
    {
        public readonly string Name;
        public int CostOnDay { get; protected set; }

        protected internal Service(string name)
        {
            //check empty name

            Name = name;
        }

        public void ChangeCost(int cost)
        {
            if (cost < 0)
                throw new InvalidOperationException(" Service cost cannot be negative ");

            CostOnDay = cost;
        }

        public DateTime? From { get; private set; }
        public DateTime? To { get; private set; }

        public void Activate()
        {
            From = DateTime.UtcNow;
        }

        public void Deactivate()
        {
            To = DateTime.UtcNow;
        }

    }
}
