using System;

namespace Billing.Domain.Entities
{
    public class Client
    {

        public Client(Passport passport)
        {
            if (passport == null)
                throw new ArgumentNullException(nameof(passport));

            Passport = passport;
        }

        public Passport Passport { get; protected set; }


    }
}
