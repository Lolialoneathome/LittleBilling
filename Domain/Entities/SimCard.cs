using Billing.Domain.Entities.Tariffs;
using System;
using System.Collections.Generic;

namespace Billing.Domain.Entities
{
    public class SimCard : IEntity
    {
        public int Id { get; }
        public string PhoneNumber { get; protected set; }
        public Balance Balance { get; protected set; }
        public Client Client { get; protected set; }
        public Tariff Tariff { get; protected set; }
        public bool IsFree => (Client == null);
        protected internal SimCard(string phoneNumber)
        {
            //checks 
            PhoneNumber = phoneNumber;
            Balance = new Balance();
        }

        public readonly IList<Service> Services = new List<Service>();

        public void SetClient(Client client)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            Client = client;
        }

        public void ResetClient()
        {
            Client = null;
        }

        public void ChangePhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public void SetTariff(Tariff tariff)
        {
            if (tariff == null)
                throw new ArgumentNullException(nameof(tariff));

            Tariff = tariff;
        }


        public void AddService(Service service)
        {

        }

        public void RemoveService(Service service)
        {

        }

    }
}
