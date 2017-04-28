using Billing.Domain.Entities;
using Billing.Domain.Repositories;
using System;
using System.Linq;

namespace Billing.Domain.Services
{
    public class CallService
    {
        protected readonly IRepository<SimCard> _simCardRepo;
        protected readonly IRepository<Call> _callRepo;
        protected readonly TarificationService _tarificationService;

        public CallService(IRepository<SimCard> simCardRepo, IRepository<Call> callRepo)
        {
            _tarificationService = new TarificationService(simCardRepo, callRepo);
            _simCardRepo = simCardRepo;
            _callRepo = callRepo;
        }

        public void DoCall(string phoneNumberFrom, string phoneNumberTo)
        {
            SimCard simCard = _simCardRepo.All().SingleOrDefault(x => x.PhoneNumber == phoneNumberFrom);

            if (simCard == null)
                throw new ArgumentException("Sim Card by number not found!");

            if (simCard.Balance.Money < 0)
                throw new InvalidOperationException("Negative balance.");

            Call call = new Call(simCard, phoneNumberTo);
            _callRepo.Add(call);
        }

        public void EndCall(Call call)
        {
            if (call == null)
                throw new ArgumentException("Call not found!");
            if (call.State != CallState.InProgress)
                throw new InvalidOperationException("Call ended yet");

            call.End();

            _tarificationService.TarificateCall(call);
            call.SimCard.Balance.TakeMoney(call.Cost);
        }

    }
}
