using System;

namespace DDD
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
        public string PhoneNumber { get; protected set; }

        public void SetPhoneNumber(string phoneNumber)
        {
            if (PhoneNumber != null)
                throw new InvalidOperationException("Client already have phone number!");

            //need check
            PhoneNumber = phoneNumber;
        }


    }
}
