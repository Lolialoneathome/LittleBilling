using System;

namespace Billing.Domain.Entities
{
    public class Passport
    {
        public int Series { get; protected set; }

        public int Number { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Patronymic { get; protected set; }

        public Passport(int series, int number, string firstname, string lastname, string patronymic)
        {
            if (string.IsNullOrWhiteSpace(firstname))
                throw new ArgumentNullException(nameof(firstname));
            if (string.IsNullOrWhiteSpace(lastname))
                throw new ArgumentNullException(nameof(lastname));
            if (string.IsNullOrWhiteSpace(patronymic))
                throw new ArgumentNullException(nameof(patronymic));

            Series = series;
            Number = number;
            FirstName = firstname;
            LastName = lastname;
            Patronymic = patronymic;
        }
    }
}
