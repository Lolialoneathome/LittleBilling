using System;

namespace Billing.Domain.Entities.Tariffs
{
    public class Tariff : ITariff
    {
        public readonly string Name;
        public int Id { get; }
        public int SubscriptionFee { get; protected set; }

        public ITarifficationRule TarificationRule { get; set; }

        public Tariff(string name, int subscriptionFee = 0)
        {
            //check name

            Name = name;

        }

        public bool IsActive { get; protected set; }


        public void SetTarificationRule(ITarifficationRule tarificationRule)
        {
            //check rule null
            TarificationRule = tarificationRule;
        }

        public void ActivateTariff()
        {
            IsActive = true;
        }

        public void DeactiviteTariff()
        {
            IsActive = false;
        }

        public void SetSubscriptionFee(int subscriptionFee)
        {
            if (subscriptionFee < 0)
                throw new InvalidOperationException(" Subscription Fee cannot be negative ");

            SubscriptionFee = subscriptionFee;
        }

    }
}
