
namespace Billing.Domain.Entities
{
    public class Service
    {
        public readonly string Name;
        public int Cost { get; set; }

        protected internal Service(string name)
        {
            //check empty name

            Name = name;
        }

        public void ChangeCost()
        {

        }


    }
}
