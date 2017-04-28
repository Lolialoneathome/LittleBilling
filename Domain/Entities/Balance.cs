using System;

namespace Billing.Domain.Entities
{
    public class Balance
    {
        public decimal Money { get; private set; }

        protected internal Balance()
        {
            Money = 0;
        }

        public void PutMoney(decimal money)
        {
            if (money < 0)
                throw new ArgumentOutOfRangeException(nameof(money));

            Money += money;
        }

        public void TakeMoney(decimal money)
        {
            if (money < 0)
                throw new ArgumentOutOfRangeException(nameof(money));

            Money -= money;
        }

    }
}
