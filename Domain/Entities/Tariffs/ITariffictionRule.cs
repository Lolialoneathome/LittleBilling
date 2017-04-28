namespace Billing.Domain.Entities.Tariffs
{
    public interface ITarifficationRule
    {
        void TarificateCall(Call call, CallArea area);
        void TarifficateSms();
    }
}
