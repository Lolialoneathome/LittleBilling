namespace DDD
{
    public class Agreement
    {
        public readonly Client Client;

        public readonly Tariff Tariff;

        protected internal Agreement(Client client, Tariff tarif)
        {
            //check null

            Client = client;
            Tariff = tarif;
        }


    }
}
