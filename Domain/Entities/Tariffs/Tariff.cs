namespace Billing.Domain.Entities.Tariffs
{
    public class Tariff : ITariff
    {
        public readonly string Name;
        public int Id { get; }
        public ITarifficationRule TarificationRule { get; set; }

        public Tariff(string name)
        {
            //check name

            Name = name;

        }

        public bool IsActive { get; protected set; }


        public void SetTarificationRule(ITarifficationRule tarificationRule)
        {
            //check rule null
            TarificationRule = tarificationRule;
        }

        public void ActivateTariff()
        {
            IsActive = true;
        }

        public void DeactiviteTariff()
        {
            IsActive = false;
        }

    }
}
