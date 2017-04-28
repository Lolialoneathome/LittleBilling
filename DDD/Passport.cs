using System;

namespace DDD
{
    public class Passport
    {
        public string Series { get; protected set; }

        public string Number { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Patronymic { get; protected set; }

        public Passport(string series, string number, string firstname, string lastname, string patronymic)
        {
            if (string.IsNullOrWhiteSpace(series))
                throw new ArgumentNullException(nameof(series));
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentNullException(nameof(number));
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
