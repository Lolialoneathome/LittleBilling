using Billing.Domain.Entities;
using Billing.Domain.Entities.Tariffs;
using Billing.Domain.Repositories;
using System;

namespace Billing.Domain.Services
{
    public class SimCardService
    {
        protected readonly IRepository<SimCard> _simCardRepo;

        public SimCardService(IRepository<SimCard> simCardRepo)
        {
            _simCardRepo = simCardRepo;
        }

        public void AddSimCard(string phoneNumber, int startBalance = 0)
        {
            SimCard simCard = new SimCard(phoneNumber);
            simCard.Balance.PutMoney(startBalance);
            _simCardRepo.Add(simCard);
        }

        public void SellSimCard(SimCard simCard, Client client, Tariff tariff)
        {
            simCard.SetTariff(tariff);
            simCard.SetClient(client);
        }

        public void AddService(SimCard simCard, Service service)
        {

        }

    }
}