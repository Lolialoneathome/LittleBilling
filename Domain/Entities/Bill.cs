using System;

namespace Billing.Domain.Entities
{
    public class Bill
    {
        public DateTime? Date { get; private set; }
        public int Value { get; protected set; }

        protected readonly SimCard _simCard;
        public Bill(SimCard simCard)
        {
            _simCard = simCard;
        }

        public void SetUpBill()
        {
            int preBill = _serviceBill();
            preBill += _simCard.Tariff.SubscriptionFee;

            Value = preBill;
        }

        protected int _serviceBill()
        {
            var result = 0;
            foreach (var service in _simCard.Services)
            {
                var serviceTo = (service.From == null) ? DateTime.UtcNow : service.From;

                if (serviceTo == service.From)
                {
                    result += service.CostOnDay;
                    continue;
                }
                result += service.CostOnDay * (serviceTo - service.From).Value.Days;
            }

            return result;
        }

    }
}
