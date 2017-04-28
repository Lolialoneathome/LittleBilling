using Billing.Domain.Entities;
using Billing.Domain.Entities.Tariffs;
using Billing.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Domain.Services
{
    public class TarificationService
    {
        protected readonly IRepository<SimCard> _simCardRepo;
        protected readonly IRepository<Call> _callRepository;

        public TarificationService(IRepository<SimCard> simCardRepo, IRepository<Call> callRepository)
        {
            _simCardRepo = simCardRepo;
            _callRepository = callRepository;
        }

        public void TarificateCall(Call call)
        {
            if (_simCardRepo.All().SingleOrDefault(x => x.PhoneNumber == call._phoneNumberTo) != null)
            {
                call.SimCard.Tariff.TarificationRule.TarificateCall(call, CallArea.Internal);
                return;
            }

            call.SimCard.Tariff.TarificationRule.TarificateCall(call, CallArea.External);
        }

    }
}
