using System;

namespace Billing.Domain.Entities.Tariffs
{
    public class CallAreaTarificationRule : ITarifficationRule
    {
        public readonly int InternalCallCostMinute;
        public readonly int ExternalCallCostMinute;

        public CallAreaTarificationRule(int internalCallCostMinute, int externalCallCostMinute)
        {
            InternalCallCostMinute = internalCallCostMinute;
            ExternalCallCostMinute = externalCallCostMinute;
        }

        public void TarificateCall(Call call, CallArea area)
        {
            if (area == CallArea.Internal)
                _tarificateInternalCall(call);

            if (area == CallArea.External)
                _tarificateExternalCall(call);
        }

        private void _tarificateExternalCall(Call call)
        {
            call.SetCost(call.MinuteDuration * ExternalCallCostMinute);
        }

        private void _tarificateInternalCall(Call call)
        {
            if (call.MinuteDuration <= 30)
            {
                call.SetCost(0);
                return;
            }

            call.SetCost((call.MinuteDuration - 30) * InternalCallCostMinute);
        }

        public void TarifficateSms()
        {
            throw new NotImplementedException();
        }
    }
}
